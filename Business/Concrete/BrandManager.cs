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
    public class BrandManager : IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand entity)
        {
            _brandDal.Add(entity);
            return new SuccsessResult(Messages.Added);
            
        }

        public IResult Update(Brand entity)
        {
            _brandDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccsessDataResult<List<Brand>>(_brandDal.GetAll().ToList());
        }

    }
}
