using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car entity);
        IResult Update(Car entity);
        IResult Delete(Car entity);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetById(int id);


        IDataResult<List<CarDetailDto>> GetAllCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int brandId);
    }
}
