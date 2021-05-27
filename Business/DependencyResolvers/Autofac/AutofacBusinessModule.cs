using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Car
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<CarManager>().As<ICarService>();

            //Brand
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<BrandManager>().As<IBrandService>();
            
            //Color
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<ColorManager>().As<IColorService>();

            //Customer
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<CustomerManager>().As<ICustomerService>();

            //Rental
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();
            builder.RegisterType<RentalManager>().As<IRentalService>();

            //User
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            //Auth
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            //CarImage
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors
            (new ProxyGenerationOptions()
            {
                Selector = new AspectInterCeptorSelector()
            }).SingleInstance();


        }
    }
}
