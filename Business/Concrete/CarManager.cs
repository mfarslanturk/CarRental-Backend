using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;

        }

        public IResult Add(Car entity)
        {
            _carDal.Add(entity);
            return new SuccsessResult(Messages.Added);
        }

        public IResult Update(Car entity)
        {
            _carDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(Car entity)
        {
            _carDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccsessDataResult<List<Car>>(_carDal.GetAll().ToList());
        }

        public IDataResult<Car> GetById(int id)
        {

            return new SuccsessDataResult<Car>(_carDal.Get(c=>c.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetail()
        {
            return new SuccsessDataResult<List<CarDetailDto>>(_carDal.GetCarDetail().ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId)
        {
            var result = _carDal.GetCarDetail(c => c.Id == carId);
            return new SuccsessDataResult<List<CarDetailDto>>(result.ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
        {
            var result = _carDal.GetCarDetail(c => c.BrandId == brandId);
            return new SuccsessDataResult<List<CarDetailDto>>(result.ToList());
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
        {
            var result = _carDal.GetCarDetail(c => c.ColorId == colorId);
            return new SuccsessDataResult<List<CarDetailDto>>(result.ToList());
        }
    }
}
