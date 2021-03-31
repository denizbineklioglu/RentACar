using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IResult ChangePassword(PasswordDto passwordDto)
        {
            byte[] passwordHash, passwordSalt;
            var userToCheck = _userService.GetById(passwordDto.UserId).Data;
            if (userToCheck == null)
            {
                return new ErrorResult(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(passwordDto.OldPassword,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }
            HashingHelper.CreatePasswordHash(passwordDto.NewPassword, out passwordHash, out passwordSalt);
            userToCheck.PasswordHash = passwordHash;
            userToCheck.PasswordSalt = passwordSalt;
            _userService.Update(userToCheck);
            return new SuccessResult(Messages.PasswordChanged);
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessHasBeen);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.Data.PasswordHash,userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
      
            HashingHelper.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.Registered);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email).Data != null)
            {
                return new ErrorResult(Messages.UserEntered);
            }
            return new SuccessResult();
        }
    }
}
