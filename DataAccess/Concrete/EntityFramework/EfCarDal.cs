using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, EfCarRentalContext>, ICarDal
    {
        public void AddList(List<Car> cars)
        {
            using (EfCarRentalContext context = new EfCarRentalContext())
            {
                foreach (var car in cars)
                {
                    var addedEntity = context.Entry(car);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
            }

        }

        public List<CarDetailDto> GetCarDetail(Expression<Func<Car, bool>> filter = null)
        {

            using (EfCarRentalContext context = new EfCarRentalContext())
            {

                var result = from c in filter is null ? context.Cars : context.Cars.Where(filter)
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 ModelYear = c.ModelYear,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 Id = c.Id,
                                 MainImagePath = context.CarImages.Where(cı => cı.CarId == c.Id && cı.MainImage==true).FirstOrDefault().ImagePath

                             };

                return result.ToList();
            }
        }
    }
}
