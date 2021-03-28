using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarsDboContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(CarsDboContext context=new CarsDboContext())
            {
                var result = from c in context.CarTable
                             join b in context.BrandTable
                             on c.BrandId equals b.BrandId
                             join cl in context.ColorTable
                             on c.ColorId equals cl.ColorId
                             select new CarDetailDto { BrandId = b.BrandId, ColorId = cl.ColorId, BrandName = b.BrandName, ColorName = cl.ColorName, DailyPrice = c.DailyPrice,ModelYear=c.ModelYear };
                return result.ToList();
            }
        }
    }
}
