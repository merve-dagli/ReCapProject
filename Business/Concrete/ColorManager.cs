using Business.Abstract;
using Business.Constants;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorsDal)
        {
            _colorDal = colorsDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(Color color)
        {
            if (color.ColorId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _colorDal.Delete(color);
            return new SuccessResult(Messages.MessageDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetByColorId(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorId ==id));
        }

        public IResult Update(Color color)
        {
            if (color.ColorId.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _colorDal.Update(color);
            return new SuccessResult(Messages.MessageUpdated);
        }
    }
}
