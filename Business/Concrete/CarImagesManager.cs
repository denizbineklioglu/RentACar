using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult Add(CarImages carImages)
        {
            BusinessRules.Run(CheckCountPicturesOfCar(carImages.ImagePath));
            _carImagesDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult();
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c=> c.CarImagesID == id));
        }

        public IResult Update(CarImages carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult();
        }

        private IResult CheckCountPicturesOfCar(string imagePath)
        {
            var result = _carImagesDal.GetAll(c=> c.ImagePath == imagePath).Count;
            if (result > 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
