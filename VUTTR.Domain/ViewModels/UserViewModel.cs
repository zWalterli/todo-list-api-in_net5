using System;
using VUTTR.Domain.Models;

namespace VUTTR.Domain.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() {}
        public UserViewModel(string refreshToken, DateTime refreshTokenExpiryTime)
        {
            RefreshToken = refreshToken;
            RefreshTokenExpiryTime = refreshTokenExpiryTime;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}