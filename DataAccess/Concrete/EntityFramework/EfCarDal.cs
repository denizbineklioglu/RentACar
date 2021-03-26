using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in filter is null ? context.CARS : context.CARS.Where(filter)
                             join ca in context.COLORS
                             on c.ColorID equals ca.ColorID
                             join b in context.BRANDS
                             on c.BrandID equals b.BrandID
                             join cm in context.CarImages
                             on c.CarID equals cm.CarID
                             select new CarDetailDto
                             {
                                 CarId = c.CarID,
                                 CarName = c.CarName,
                                 ColorName = ca.ColorName,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ModelYear = c.ModelYear,
                                 ImagePath = cm.ImagePath,
                                 FindeksPoint  = c.FindeksPoint
                             };
                return result.ToList();
            }
            
        }
    }
}
