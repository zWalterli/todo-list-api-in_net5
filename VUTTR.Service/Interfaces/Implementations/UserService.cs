using System;
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

            return new TokenDto(
                true,
                createDate.ToString(DATE_FORMAT),
                ExpirationDate.ToString(DATE_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public async Task<UserDto> Register(UserDto user)
        {
            User model = new User(user);
            model.Password = _userRepository.ComputeHash( user.Password, new SHA256CryptoServiceProvider());
            return new UserDto(await _userRepository.Register(model));
        }
    }
}