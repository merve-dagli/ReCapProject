using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public IResult Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.MessageAdded);
            }
            else
            {
                return new ErrorResult(Messages.DailyPriceInvalid);
            }
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

        public IDataResult<List<Car>>GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }


        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }


        public IResult Update(Car car)
        {
            if (car.CarId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.MessageUpdated);
        }

        IDataResult<Car> ICarService.GetByCarId(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }
    }
}
