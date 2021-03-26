using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, DatabaseContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in context.Customers
                             join u in context.Users
                             on c.UserID equals u.UserId
                             select new CustomerDetailDto()
                             {
                                 CustomerID = c.CustomerID,
                                 CompanyName = c.CompanyName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName
                             };
                return result.ToList();
            }
        }

        public List<CustomerForFindeksPointDto> GetCustomerFindeksPoint(Expression<Func<Customer, bool>> filter = null)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from c in filter is null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on c.UserID equals u.UserId
                             select new CustomerForFindeksPointDto()
                             {
                                 CustomerID=c.CustomerID,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 FindeksPoint = c.FindeksPoint
                             };
                return result.ToList();

            }
        }
    }
}
