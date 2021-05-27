using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color entity);
        IResult Update(Color entity);
        IResult Delete(Color entity);
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> GetColorId(int id);
    }
}
