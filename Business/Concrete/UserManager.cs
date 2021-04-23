using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal usersDal)
        {
            _userDal = usersDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.MessageAdded);
        }

        public IResult Delete(User user)
        {
            if (user.Id.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            _userDal.Delete(user);
            return new SuccessResult(Messages.MessageDeleted);
            
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByUserId(int id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == id));
        }

        public IResult Update(User user)
        {
            if (user.Id.ToString() == null)
            {
                return new ErrorResult(Messages.MessageError);
            }
            else
            {
                _userDal.Update(user);
                return new SuccessResult(Messages.MessageUpdated);
            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
