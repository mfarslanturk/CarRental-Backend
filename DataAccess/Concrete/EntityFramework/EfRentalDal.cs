using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, EfCarRentalContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter=null)
        {
            using (EfCarRentalContext context = new EfCarRentalContext())
            {
                var result = from re in filter is null ? context.Rentals : context.Rentals.Where(filter)
                    join ca in context.Cars
                        on re.CarId equals ca.Id
                    join cu in context.Customers
                        on re.CustomerId equals cu.Id
                    join us in context.Users
                        on cu.UserId equals us.Id
                    join br in context.Brands on ca.BrandId equals br.BrandId 
                    select new RentalDetailDto
                    {
                        Id = re.Id,
                        CarId = ca.Id,
                        CarBrand = br.BrandName,
                        RentDate = re.RentDate,
                        ReturnDate = re.ReturnDate,
                        UserName = us.FirstName+" "+us.LastName
                    };

                return result.ToList();
            }
        }
    }
}
