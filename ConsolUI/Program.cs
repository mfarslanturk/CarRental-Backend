using System;
using System.Collections.Generic;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsolUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //IRentalService rentalservice = NinjectInstanceFactory.GetInstance<IRentalService>();
            //foreach (var rental in rentalservice.GetAll().Data)
            //{
            //    Console.WriteLine(rental.CarId);
            //}


        }
    }
}
