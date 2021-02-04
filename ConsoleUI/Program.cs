using Business.Concrete;
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
            CarManager carManager = new CarManager(new EfCarDal());
            //Car car = new Car() { Id = 13, BrandId = 4, ColorId = 5, CarName = "BuUs", DailyPrice = 44400, Description = "Ferrari", ModelYear = 2010 };
            //carManager.Add(car);
            foreach (var c in carManager.GetAll())
            {
                Console.WriteLine(c.CarName);
            }

            foreach (var c in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine(c.Description);
            }

            foreach (var c in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(c.DailyPrice);
            }
        }
    }
}
