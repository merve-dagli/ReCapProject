using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarServices
    {
        List<Car> GetAll();
        Car GetByCarId(int id);     
        public void Add(Car car);
        public void Delete(Car car);
        public void Update(Car car);
        List<CarDetailDto> GetCarDetails();
        
    }
}
