using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalDal : IEntityRepositoryBase<Rental>
    {
        List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null);
    }

}
