using Business.Concrete;
using Business.Constants;
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
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //DateTime dt1 = new DateTime(2021, 03, 15);
            //DateTime dt2 = new DateTime(2021, 03, 16);
            //var result = rentalManager.Add(new Rental { RentalId = 2, CarId = 2, CustomerId = 1, RentDate = dt1, ReturnDate = dt2 });
            //if (result.Success == true)
            //{
            //    Console.WriteLine(Messages.MessageAdded);
            //}
            //else
            //{
            //    Console.WriteLine(Messages.MessageError);
            //}

            //CarTest();

            //BrandTest();

           ColorTest();

            //GetByIdTest();

            //CarDetailTest();
        }

        private static void CarDetailTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car : " + car.CarName + " -- Price : " + car.DailyPrice + " -- Brand Name : " + car.BrandName + " -- Color Name : " + car.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach(var result in brandManager.GetByBrandId(1).Data)
            {
                Console.WriteLine("Bulunan Id: " + result.BrandId + " -- Bulunan Marka Adı: " + result.BrandName);
            }
                  

            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var result2 in carManager.GetByCarId(5).Data)
            {
                Console.WriteLine("Bulunan Id: " + result2.CarId + " -- Bulunan Aracın Model Yılı: " + result2.ModelYear);
            }

            ColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var result3 in colorManager.GetByColorId(2).Data)
            {
                Console.WriteLine("Bulunan Id: " + result3.ColorId + " -- Bulunan Aracın Rengi: " + result3.ColorName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "BEIGE ANTIQUE MET", ColorCode = "129" });
            colorManager.Update(new Color { ColorId = 6, ColorName = "BEIGE ANTIQUE MET", ColorCode = "128" });
            colorManager.Delete(new Color { ColorId = 7 });

            var result = colorManager.GetAll();
            if (result.Success == false)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine("Aracın Rengi: " + color.ColorName + " -- Aracın Renk Kodu: " + color.ColorCode);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Renault", BrandCountry = "İtalya" });
            brandManager.Update(new Brand { BrandId = 1006, BrandName = "Renault", BrandCountry = "Fransa" });
            brandManager.Delete(new Brand { BrandId = 1005 });
            var result = brandManager.GetAll();
            if (result.Success == true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine("Aracın Markası: " + brand.BrandName + " -- Aracın Ülkesi: " + brand.BrandCountry);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
           
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            carManager.Add(new Car { BrandId = 2, ColorId = 4, DailyPrice = 450, Description = "Sıfıra yakın!", ModelYear = "2021" });        
            carManager.Update(new Car { CarId = 1009, BrandId = 2, ColorId = 4, DailyPrice = 460, Description = "Sıfıra yakın!", ModelYear = "2021" });
            carManager.Delete(new Car { CarId = 1012 });

            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.ModelYear + " model aracınız günlük " + car.DailyPrice + " TL'dir. " + car.Description);
                    
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
        }
    }
}
