using System;
using VUTTR.Domain.Models;

namespace VUTTR.Domain.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel() {}
        public UserViewModel(User user)
        {
            this.UserId = user.UserId;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.FullName = user.FullName;
            this.RefreshToken = user.RefreshToken;
            this.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
        }
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