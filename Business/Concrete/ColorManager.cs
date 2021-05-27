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
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color entity)
        {
            _colorDal.Add(entity);
            return new SuccsessResult(Messages.Added);
        }

        public IResult Update(Color entity)
        {
            _colorDal.Update(entity);
            return new SuccsessResult(Messages.Updated);
        }

        public IResult Delete(Color entity)
        {
            _colorDal.Delete(entity);
            return new SuccsessResult(Messages.Deleted);

        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccsessDataResult<List<Color>>(_colorDal.GetAll().ToList());
        }

        public IDataResult<Color> GetColorId(int id)
        {
            return new SuccsessDataResult<Color>(_colorDal.Get(c => c.ColorId == id));
        }
    }
}
