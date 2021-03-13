﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, DatabaseContext>, IRentalDal
    {
        public List<RentalDetailDtos> GetRentalDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from r in context.RENTALS
                             join c in context.CARS
                             on r.CarID equals c.CarID
                             join b in context.BRANDS
                             on c.BrandID equals b.BrandID
                             join cu in context.CUSTOMERS
                             on r.CustomerID equals cu.CustomerID
                             join u in context.Users
                             on cu.UserID equals u.UserID
                             select new RentalDetailDtos
                             {
                                 RentalId = r.RentalID,
                                 BrandName = b.BrandName,
                                 FirstName= u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();

            }
        }
    }
}
