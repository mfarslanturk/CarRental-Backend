using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImage entity);
        IResult Update(CarImage entity);
        IResult Delete(CarImage entity);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetAllImageForCarId(int carId);
    }   
}
