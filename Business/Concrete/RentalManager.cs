using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        private IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {

            _rentalDal.Add(entity);
            return new SuccsessResult(Messages.Added);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var result = _rentalDal.GetAll().ToList();
            if (result.Count<=0)
            {
                return new SuccsessDataResult<List<Rental>>(result, Messages.Empty);
            }

            return new SuccsessDataResult<List<Rental>>(result);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccsessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccsessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails().ToList());
        }
    }

}
