using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customersDal)
        {
            _customerDal = customersDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(Customer customer)
        {
            if (customer.CustomerId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<List<Customer>> GetByCustomerId(int id)
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(c => c.CustomerId == id));
        }

        public IResult Update(Customer customer)
        {
            if (customer.CustomerId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _customerDal.Update(customer);
            return new SuccessResult(Messages.MessageUpdated);
        }
    }
}
