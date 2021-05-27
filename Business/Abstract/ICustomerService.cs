using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer entity);
        IResult Update(Customer entity);
        IResult Delete(Customer entity);
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByUserId(int id);
    }
}
