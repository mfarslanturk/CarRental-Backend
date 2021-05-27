using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental entity);
        IResult Update(Rental entity);
        IResult Delete(Rental entity);
        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        IDataResult<List<RentalDetailDto>> GetRentalDetail();
    }
}
