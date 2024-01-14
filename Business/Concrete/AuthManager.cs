using Business.Abstract;
using Business.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager(IUserService userService) : IAuthService
    {
        private readonly IUserService _userService = userService;
        ITokenHelper _tokenHelper;

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetOperationClaims(user).Data;
            var token = _tokenHelper.CreateToken(user, operationClaims);
            return new SuccessDataResult<AccessToken>(token);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToChechk = _userService.GetByMail(userForLoginDto.Email);
            if (userToChechk==null)
            {
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            }


        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            throw new NotImplementedException();
        }

        public IResult UserExists(string email)
        {
            throw new NotImplementedException();
        }
    }
}
