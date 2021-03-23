using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarServices
    {
        ICarDal _carsDal;

        public CarManager(ICarDal carsDal)
        {
            _carsDal = carsDal;
        }

        public List<Car> GetAll()
        {
            return _carsDal.GetAll();
        }
    }
}
