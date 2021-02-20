using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            //try
            //{
                _customerDal.Add(customer);
                return new SuccessResult(Messages.CustomerAdded);
            //}
            //catch (Exception)
            //{
            //    return new ErrorResult(Messages.CustomerAdded);
            //}
        }

        public IResult Delete(Customer customer)
        {
            try
            {
                _customerDal.Delete(customer);
                return new SuccessResult(Messages.CustomerDeleted);
            }
            catch (Exception)
            {
                return new ErrorResult(Messages.CustomerError);
            }
        }

        public IDataResult<List<Customer>> GetAll()
        {
            try
            {
                return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
            }
            catch (Exception)
            {

                return new ErrorDataResult<List<Customer>>(Messages.CustomerError);
            }
        }

        public IDataResult<Customer> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Customer>(_customerDal.Get(customer => customer.Id == id));
            }
            catch (Exception)
            {

                return new ErrorDataResult<Customer>(Messages.CustomerError);
            }
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            //try
            //{
                _customerDal.Update(customer);
                return new SuccessResult(Messages.CustomerUpdated);
            //}
            //catch (Exception)
            //{
            //    return new ErrorResult(Messages.CustomerError);
            //}
        }
    }
}
