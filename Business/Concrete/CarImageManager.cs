using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImagesDal,ICarService carService)
        {
            _carImageDal = carImagesDal;
            _carService = carService;
        }

        public IResult Add(CarImage carImages)
        {
            BusinessRules.Run(CheckCountPicturesOfCar(carImages.CarID));
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=> c.CarImageID == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCountPicturesOfCar(int carid)
        {
            var result = _carImageDal.GetAll(c=> c.CarID == carid).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CarPicturesLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
