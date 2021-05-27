using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccsessResult(Messages.Added);
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);

        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccsessDataResult<List<Customer>>(_customerDal.GetAll().ToList());
        }

        public IDataResult<Customer> GetByUserId(int id)
        {
            return new SuccsessDataResult<Customer>(_customerDal.Get(c => c.UserId == id));
        }
    }
}
