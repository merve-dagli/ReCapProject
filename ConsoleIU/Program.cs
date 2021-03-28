using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleIU
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            //GetByIdTest();




            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car : " + car.ModelYear + " -- Price : " + car.DailyPrice + " -- Brand Name : " + car.BrandName + " -- Color Name : " + car.ColorName);
            }

        }

        private static void GetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetByBrandId(1);
            Console.WriteLine("Bulunan Id: " + result.BrandId + " -- Bulunan Marka Adı: " + result.BrandName);

            CarManager carManager = new CarManager(new EfCarDal());
            var result2 = carManager.GetByCarId(5);
            Console.WriteLine("Bulunan Id: " + result2.Id + " -- Bulunan Aracın Model Yılı: " + result2.ModelYear);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result3 = colorManager.GetByColorId(2);
            Console.WriteLine("Bulunan Id: " + result3.ColorId + " -- Bulunan Aracın Rengi: " + result3.ColorName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "BEIGE ANTIQUE MET", ColorCode = "129" });
            colorManager.Update(new Color { ColorId = 6, ColorName = "BEIGE ANTIQUE MET", ColorCode = "128" });
            colorManager.Delete(new Color { ColorId = 7 });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("Aracın Rengi: " + color.ColorName + " -- Aracın Renk Kodu: " + color.ColorCode);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Renault", BrandCountry = "İtalya" });
            brandManager.Update(new Brand { BrandId = 1006, BrandName = "Renault", BrandCountry = "Fransa" });
            brandManager.Delete(new Brand { BrandId = 1005 });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("Aracın Markası: " + brand.BrandName + " -- Aracın Ülkesi: " + brand.BrandCountry);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            carManager.Add(new Car { BrandId = 2, ColorId = 4, DailyPrice = 450, Description = "Sıfıra yakın!", ModelYear = "2021" });        
            carManager.Update(new Car {Id=1009, BrandId = 2, ColorId = 4, DailyPrice = 460, Description = "Sıfıra yakın!", ModelYear = "2021" });
            carManager.Delete(new Car { Id = 1012 });
           
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.ModelYear + " model aracınız günlük " + car.DailyPrice + " TL'dir. " + car.Description);
                Console.WriteLine(" ");
            }
            
        }
    }
}
