using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        public IResult Add(CarImage entity)
        {
            var result = BusinessRule.Run(CheckCarImageCount(entity.CarId));

            if (result != null)
                return result;


            _carImageDal.Add(entity);
            return new SuccsessResult(Messages.Added);

        }

        public IResult Update(CarImage entity)
        {
            _carImageDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(CarImage entity)
        {
            _carImageDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = _carImageDal.GetAll();
            return new SuccsessDataResult<List<CarImage>>(result.ToList());
        }

        public IDataResult<List<CarImage>> GetAllImageForCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            return new SuccsessDataResult<List<CarImage>>(result.ToList());
        }   

        private IResult CheckCarImageCount(int carId)
        {
            var result = _carImageDal.GetAll(c => c.Id == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceded);
            }

            return new SuccsessResult();
        }

    }

}
