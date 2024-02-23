using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;

namespace Business.Concrete
{
    
    [LogAspect(typeof(FileLogger))]
    public class UserManager(IUserDal userDal) : IUserService
    {
        private readonly IUserDal _userDal = userDal;

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(UserMessages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(UserMessages.UserDeleted);
        }

        public IDataResult<User> GetById(int userId)
        {
            var result = _userDal.Get(u => u.Id==userId);
            return new SuccessDataResult<User>(result, UserMessages.UserGet);
        }

        public IDataResult<User> GetByMail(string mail)
        {
            var result = _userDal.Get(u => u.Email==mail);
            return new SuccessDataResult<User>(result, UserMessages.UserGet);
        }

        public IDataResult<List<User>> GetList()
        {
            var result = _userDal.GetList().ToList();
            return new SuccessDataResult<List<User>>(result, UserMessages.UsersListed);
        }

        public IDataResult<List<OperationClaim>> GetOperationClaims(User user)
        {
            var result = _userDal.GetClaims(user).ToList();
            return new SuccessDataResult<List<OperationClaim>>(result, UserMessages.UsersClaimsListed);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(UserMessages.UserUpdated);
        }
    }
}
