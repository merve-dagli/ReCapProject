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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandsDal)
        {
            _brandDal = brandsDal;
        }

        public void Add(Brand brand)
            {
                if (brand.BrandName.Length >= 2)
                {
                 _brandDal.Add(brand);
                }
                else
                {
                    Console.WriteLine("Yetersiz karakter!");
                }
            
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetByBrandId(int id)
        {
            return _brandDal.Get(b=>b.BrandId==id);
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
