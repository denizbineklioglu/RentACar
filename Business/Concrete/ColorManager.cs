using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IBaseService<Color>
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
            Console.WriteLine("Bilgileriniz başarıyla eklendi");
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
            Console.WriteLine("Bilgileriniz başarıyla silindi.");

        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c=> c.Id== id);
        }

        public void Update(Color entity)
        {
            _colorDal.Update(entity);
            Console.WriteLine("Bilgileriniz güncellendi.");
        }
    }
}
