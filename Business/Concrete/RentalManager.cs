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
using Core.CrossCuttingConcerns.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalsDal;

        public RentalManager(IRentalDal rentalsDal)
        {
            _rentalsDal = rentalsDal;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {

          
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

        public IDataResult<Rental> GetByRentalId(int id)
        {
            return new SuccessDataResult<Rental>(_rentalsDal.Get(r => r.RentalId == id));
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
