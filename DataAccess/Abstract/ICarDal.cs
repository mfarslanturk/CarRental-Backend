using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepositoryBase<Car>
    {
        void AddList(List<Car> cars);
        List<CarDetailDto> GetCarDetail(Expression<Func<Car, bool>> filter = null);
    }
}
