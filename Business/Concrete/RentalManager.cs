using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental entity)
        {
            var result = _rentalDal.GetAll(r => r.CarID == entity.CarID && (r.ReturnDate == null || r.ReturnDate > entity.RentDate)).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarInvalid);
            }
            else
            {
                _rentalDal.Add(entity);
                return new SuccessResult(Messages.Added);
            }
            
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=> r.RentalID==id),Messages.Listed);
        }

        public IDataResult<List<RentalDetailDtos>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDtos>>(_rentalDal.GetRentalDetails(), Messages.Listed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.Updated);
        }
    }
}
