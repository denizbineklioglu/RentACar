using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.CarName.Length > 2 && car.DailyPrice > 0)
            {
                _CarDal.Add(car);
                Console.WriteLine("Bilgileriniz başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Bilgilerinizi kontrol ediniz!");
            }
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _CarDal.GetAll(c=>c.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _CarDal.GetAll(c=>c.ColorId==id);
        }
    }
}
