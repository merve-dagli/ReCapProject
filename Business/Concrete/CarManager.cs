using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carsDal)
        {
            _carDal = carsDal;
        }
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.MessageAdded);

        }

        public IResult Delete(Car car)
        {
            if (car.CarId.ToString() == null)
            {

                return new ErrorResult(Messages.MessageError);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.MessageDeleted);


        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            if (car.CarId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.MessageUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        IDataResult<Car> ICarService.GetByCarId(int carId)
        {
            Thread.Sleep(5000);
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        [TransactionScopeAspect]
        public IResult AddTransactionTest(Car car)
        {
            Add(car);
            if (car.DailyPrice < 10)
            {
                throw new Exception("");
            }
            Add(car);
            return null;
        }
    }
}
