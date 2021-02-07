using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 1,
                CarName = "HONDA",
                ColorId = 1,
                DailyPrice = 40000,
                Description = "Honda",
                ModelYear = 2000
            });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            carManager.GetById(14);

            foreach (var car in carManager.GetCarDetailDtos())
            {
                Console.WriteLine(car.CarName + " " + car.BrandName + " " + car.ColorName);
            }
        }
    }
}
