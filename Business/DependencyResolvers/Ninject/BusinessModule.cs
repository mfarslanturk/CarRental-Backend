using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace Business.DependencyResolvers.Ninject
{
    public class BusinessModule:NinjectModule
    {
        public override void Load()
        {
            Bind<ICarDal>().To<EfCarDal>();
            Bind<ICarService>().To<CarManager>();

            Bind<IColorDal>().To<EfColorDal>();
            Bind<IColorService>().To<ColorManager>();

            Bind<IBrandDal>().To<EfBrandDal>();
            Bind<IBrandService>().To<BrandManager>();

            Bind<ICustomerDal>().To<EfCustomerDal>();
            Bind<ICustomerService>().To<CustomerManager>();

            Bind<IUserDal>().To<EfUserDal>();
            Bind<IUserService>().To<UserManager>();


            Bind<IRentalDal>().To<EfRentalDal>();
            Bind<IRentalService>().To<RentalManager>();



        }
    }
}
