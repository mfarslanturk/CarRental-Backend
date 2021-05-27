using System;
using System.Collections.Generic;
using System.IO;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using DataAccess.UploadFileTool;
using DataAccess.UploadFileTool.ImageFiles;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, EfCarRentalContext>, ICarImageDal
    {
        
        public override void Add(CarImage entity)
        {
            entity.ImagePath = UploadPathFounder.CarImageSave(entity.Image).Result.ToString();
            entity.Date=DateTime.Now;
            base.Add(entity);
        }

        public override void Update(CarImage entity)
        {
            File.Delete(entity.ImagePath);
            entity.ImagePath = UploadPathFounder.CarImageSave(entity.Image).Result.ToString();
            entity.Date = DateTime.Now;
            base.Update(entity);
        }

        public override void Delete(CarImage entity)
        {
            var result = base.Get(c => c.Id == entity.Id);
            var path= Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + result.ImagePath);
            File.Delete(path);
            base.Delete(result);
        }
    }
}
