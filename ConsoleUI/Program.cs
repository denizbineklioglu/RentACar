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
            ColorTest();
            BrandTest();

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Mercedes" });
            brandManager.Delete(new Brand { Id = 6 });
            brandManager.Update(new Brand { Id = 6, BrandName = "Rolls Royce" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Purple" });
            colorManager.Delete(new Color { Id = 6 });
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
            
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
            carManager.Delete(new Car
            {
                Id=14
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
