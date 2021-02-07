using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : IBaseService<Car>,ICarService
    {
        ICarDal _CarDal;

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car entity)
        {
            if (entity.CarName.Length > 2 && entity.DailyPrice > 0)
            {
                _CarDal.Add(entity);
                Console.WriteLine("Bilgileriniz başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("Bilgilerinizi kontrol ediniz!");
            }
        }

        public void Delete(Car entity)
        {
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _CarDal.Get(c=> c.Id == id);
        }

        public List<CarDetailDto> GetCarDetailDtos()
        {
            return _CarDal.GetCarDetails();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _CarDal.GetAll(c=> c.BrandId==id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _CarDal.GetAll(c=> c.ColorId==id);
        }

        public void Update(Car entity)
        {
        }
    }
}
