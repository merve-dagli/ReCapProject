using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear="2020", DailyPrice=250, Description=" TÜM ARAÇLARIMIZ RENT A CAR KASKOLUDUR. İLANDA BELİRTİLEN ARAÇ HARİCİNDE DİĞER ARAÇ SEÇENEKLERİMİZ İÇİN İLETİŞİM BİLGİLERİNDEN BİZLERE ULAŞABİLİRSİNİZ."},  
                new Car{CarId=2, BrandId=2, ColorId=1, ModelYear="2020", DailyPrice=300, Description=" ZENGİN ÇEŞİT VE YÜKSEK MODEL BAKIMLI ARAÇLARIMIZLA HİZMETİNİZDEYİZ."},
                new Car{CarId=3, BrandId=8, ColorId=5, ModelYear="2019", DailyPrice=285, Description=" TÜM ARAÇLARIMIZ RENT A CAR KASKOLUDUR. İLANDA BELİRTİLEN ARAÇ HARİCİNDE DİĞER ARAÇ SEÇENEKLERİMİZ İÇİN AŞAĞIDAKİ İLETİŞİM BİLGİLERİNDEN BİZLERE ULAŞABİLİRSİNİZ."},
                new Car{CarId=4, BrandId=55, ColorId=7, ModelYear="2018", DailyPrice=134, Description=" AYLIK KİRALAMADA YILLIK KİRALAMA FİYAT AVANTAJI ÜCRETSİZ AVRUPA YAKASI ADRESE TESLİM AYLIK 4000 TL"},
                new Car{CarId=5, BrandId=6, ColorId=10, ModelYear="2015", DailyPrice=133, Description=" AYLIK KİRALAMADA YILLIK KİRALAMA FİYAT AVANTAJI ÜCRETSİZ AVRUPA YAKASI ADRESE TESLİM AYLIK 4000 TL"},
                new Car{CarId=6, BrandId=98, ColorId=4, ModelYear="2018", DailyPrice=130, Description=" GÜNDEN OTO KİRALAMA."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carsToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByIColord(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;
        }
    }
}
