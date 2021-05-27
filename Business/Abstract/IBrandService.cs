using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        IResult Add(Brand entity);
        IResult Update(Brand entity);
        IResult Delete(Brand entity);
        IDataResult<List<Brand>> GetAll();
    }
}
