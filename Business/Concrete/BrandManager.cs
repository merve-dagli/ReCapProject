using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
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

      
        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
           
            _brandDal.Add(brand);
            return new SuccessResult(Messages.MessageAdded);
        
            
        }

        public IResult Delete(Brand brand)
        {
            if (brand.BrandId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.MessageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll());
        }


        [CacheRemoveAspect("IBrandService.Get")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Update(Brand brand)
        {
            if (brand.BrandId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.MessageUpdated);
        }

        [CacheAspect]
        public IDataResult<Brand> GetByBrandId(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id));
        }
    }
}
