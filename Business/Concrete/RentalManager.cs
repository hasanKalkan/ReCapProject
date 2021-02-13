using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarDal _carDal;
        public RentalManager(IRentalDal rentalDal, ICarDal carDal)
        {
            _rentalDal = rentalDal;
            _carDal = carDal;
        }
        public IResult Add(Rental rental, Car car)
        {
            if (car.IsAvailable == false)
            {
                return new ErrorResult(Messages.CarIsNotAvailable);
            }
            try
            {
                _rentalDal.Add(rental);
                car.IsAvailable = false;
                _carDal.Update(car);
                return new SuccessResult(Messages.RentalAdded);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.RentalError);
            }
        }

        public IResult Delete(Rental rental)
        {
            try
            {
                _rentalDal.Delete(rental);
                return new SuccessResult(Messages.RentalDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.RentalError);
            }
        }

        public IDataResult<List<Rental>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Rental>>(Messages.RentalError);
            }
        }

        public IDataResult<Rental> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.Id == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Rental>(Messages.RentalError);
            }
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            try
            {
                return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRetalDetails());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<RentalDetailDto>>(Messages.RentalError);
            }
        }

        public IResult Update(Rental rental)
        {
            try
            {
                _rentalDal.Update(rental);
                return new SuccessResult(Messages.RentalUpdated);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.RentalError);
            }
        }
    }
}
