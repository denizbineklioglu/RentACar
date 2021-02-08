using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBaseService<Brand>
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
            Console.WriteLine("Bilgileriniz başarıyla eklendi.");
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
            Console.WriteLine("Bilgileriniz başarıyla silindi.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b=> b.Id == id);
        }

        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
            Console.WriteLine("Bilgileriniz guncellendi.");
        }
    }
}
