using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator),Priority = 1)]
        [CacheRemoveAspect("IUserService.Get")]
        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccsessResult(Messages.Added);
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);
        }

        [CacheAspect(duration: 5)]
        public IDataResult<List<User>> GetAll()
        {
            return new SuccsessDataResult<List<User>>(_userDal.GetAll().ToList());
        }

        [CacheAspect(duration:5)]
        public IDataResult<User> GetById(int id)
        {
            return new SuccsessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        [CacheAspect(duration: 5)]
        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccsessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        [CacheAspect(duration: 5)]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccsessDataResult<List<OperationClaim>>(_userDal.GetClaims(user).ToList());
        }

    }
}
