using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear="2020", DailyPrice=250, Description=" TÜM ARAÇLARIMIZ RENT A CAR KASKOLUDUR. İLANDA BELİRTİLEN ARAÇ HARİCİNDE DİĞER ARAÇ SEÇENEKLERİMİZ İÇİN İLETİŞİM BİLGİLERİNDEN BİZLERE ULAŞABİLİRSİNİZ."},  
                new Car{Id=2, BrandId=2, ColorId=1, ModelYear="2020", DailyPrice=300, Description=" ZENGİN ÇEŞİT VE YÜKSEK MODEL BAKIMLI ARAÇLARIMIZLA HİZMETİNİZDEYİZ."},
                new Car{Id=3, BrandId=8, ColorId=5, ModelYear="2019", DailyPrice=285, Description=" TÜM ARAÇLARIMIZ RENT A CAR KASKOLUDUR. İLANDA BELİRTİLEN ARAÇ HARİCİNDE DİĞER ARAÇ SEÇENEKLERİMİZ İÇİN AŞAĞIDAKİ İLETİŞİM BİLGİLERİNDEN BİZLERE ULAŞABİLİRSİNİZ."},
                new Car{Id=4, BrandId=55, ColorId=7, ModelYear="2018", DailyPrice=134, Description=" AYLIK KİRALAMADA YILLIK KİRALAMA FİYAT AVANTAJI ÜCRETSİZ AVRUPA YAKASI ADRESE TESLİM AYLIK 4000 TL"},
                new Car{Id=5, BrandId=6, ColorId=10, ModelYear="2015", DailyPrice=133, Description=" AYLIK KİRALAMADA YILLIK KİRALAMA FİYAT AVANTAJI ÜCRETSİZ AVRUPA YAKASI ADRESE TESLİM AYLIK 4000 TL"},
                new Car{Id=6, BrandId=98, ColorId=4, ModelYear="2018", DailyPrice=130, Description=" GÜNDEN OTO KİRALAMA."}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carsToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carsToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByIColord(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList();
        }


        public void Update(Car car)
        {
            Car carsToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carsToUpdate.BrandId = car.BrandId;
            carsToUpdate.ColorId = car.ColorId;
            carsToUpdate.ModelYear = car.ModelYear;
            carsToUpdate.DailyPrice = car.DailyPrice;
            carsToUpdate.Description = car.Description;
        }
    }
}
