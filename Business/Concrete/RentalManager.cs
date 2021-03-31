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
using System.Runtime.Serialization;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalsDal;

        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _rentalsDal.Add(rental);
            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(Rental rental)
        {
            if (rental.RentalId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _rentalsDal.Delete(rental);
            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll());
        }

        public IDataResult<List<Rental>> GetByRentalId(int id)
        {
            return new SuccessDataResult<List<Rental>>(_rentalsDal.GetAll(r => r.RentalId == id));
        }

        public IResult Update(Rental rental)
        {
            if (rental.RentalId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _rentalsDal.Update(rental);
            return new SuccessResult(Messages.MessageUpdated);
        }
    }
}
