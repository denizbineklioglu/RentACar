using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car {CarID=1,BrandID=1,ColorID=1,ModelYear=2000,DailyPrice=40000,Description="Audi"},
                new Car {CarID=2,BrandID=1,ColorID=2,ModelYear=2000,DailyPrice=50000,Description="Audi"},
                new Car {CarID=3,BrandID=2,ColorID=3,ModelYear=2011,DailyPrice=100000,Description="Honda"},
                new Car {CarID=4,BrandID=3,ColorID=4,ModelYear=2004,DailyPrice=400000,Description="BMW"},
                new Car {CarID=5,BrandID=4,ColorID=1,ModelYear=2009,DailyPrice=600000,Description="Ferrari"}
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarID==car.CarID);
            _cars.Remove(carToDelete);
        }

        public List<Car> Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByld(int id)
        {
            return _cars.Where(c => c.CarID == id).ToList();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        Car IEntityRepository<Car>.Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

       
    }
}
