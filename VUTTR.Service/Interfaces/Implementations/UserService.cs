using System;
using System.Text;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.DTOs;
using VUTTR.Domain.Models;
using VUTTR.Service.Configuration;
using VUTTR.Service.Interfaces.Interfaces;

namespace VUTTR.Service.Interfaces.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private TokenConfigurations _configuration;
        private const string DATE_FORMAT = "yyy-MM-dd HH:mm:ss";


        public UserService(IUserRepository repo, ITokenService ServiceToken, TokenConfigurations configuration)
        {
            _userRepository = repo;
            _tokenService = ServiceToken;
            _configuration = configuration;
        }
        public async Task<TokenDto> Login(UserDto user)
        {
            user.Password = await Task.Run( () => {
                return Base64ToString(user.Password);
            });
            
            User model = new User(user);
            User userModel = await _userRepository.Login(model);

            if (userModel == null) return null;
            
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GenerateAccessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            await _userRepository.RefreshUserInfo(model);

            DateTime createDate = DateTime.Now;
            DateTime ExpirationDate = createDate.AddMinutes(_configuration.Minutes);

            userModel.Password = null;
            return new TokenDto(
                true,
                createDate.ToString(DATE_FORMAT),
                ExpirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken,
                new UserDto(userModel)
                );
        }

        private async Task<string> Base64ToString(string base64)
        {
            var valueBytes = System.Convert.FromBase64String(base64);
            return Encoding.UTF8.GetString(valueBytes);
        }

        public async Task<UserDto> Register(UserDto user)
        {
            user.Password = await Task.Run( () => {
                return Base64ToString(user.Password);
            });

            User model = new User(user);
            UserDto modelUserName = await this.GetByUserName(user.UserName);
            if(modelUserName != null)
                throw new Exception("Usuário já existente!");

            model.Password = _userRepository.ComputeHash( user.Password, new SHA256CryptoServiceProvider());
            return new UserDto(await _userRepository.Register(model));
        }

        public async Task<UserDto> Update(UserDto user)
        {
            if(user.Password == null) {
                var modelComPassword = await this.GetById(user.UserId, true);
                user.Password = modelComPassword.Password;
            } else {
                user.Password = _userRepository.ComputeHash( user.Password, new SHA256CryptoServiceProvider());
            }
            User model = new User(user);
            return new UserDto(await _userRepository.Update(model));
        }

        public async Task<UserDto> GetById(int UserId, bool includePassword)
        {
            User model = await _userRepository.GetById(UserId);
            if(!includePassword)
                model.Password = null;
            
            return new UserDto(model);
        }

        public async Task<UserDto> GetByUserName(string userName)
        {
            User model = await _userRepository.GetByUserName(userName);
            if(model == null) {
                return null;
            }
            return new UserDto(model);
        }
    }
}