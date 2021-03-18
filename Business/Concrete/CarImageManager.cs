using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Helpers;

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

        public IResult Add(IFormFile file,CarImage carImages)
        {
            carImages.ImagePath = FileHelper.Add(file);
            carImages.Date = DateTime.Now;
            _carImageDal.Add(carImages);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            FileHelper.Delete(carImage.ImagePath);
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

        public IDataResult<List<CarImage>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarID == carId));
        }

        public IResult Update(IFormFile file,CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.CarImageID == carImage.CarImageID).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        private IResult CheckCountPicturesOfCar(int carID)
        {
            var result = _carImageDal.GetAll(c=> c.CarID == carID).Count;
            if (result >= 5)
            {
               return new ErrorResult(Messages.CarPicturesLimitExceed);
            }
            return new SuccessResult();
        }
    }
}
