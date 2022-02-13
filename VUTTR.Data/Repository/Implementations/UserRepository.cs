using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VUTTR.Data.Context;
using VUTTR.Data.Repository.Interfaces;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly VUTTRContext _ctx;

        public UserRepository(VUTTRContext context)
        {
            _ctx = context;
        }
        public async Task<User> Login(User user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return await _ctx.Users
                        .FirstOrDefaultAsync(x => (x.Password.Equals(pass)
                                                && x.UserName.Equals(user.UserName)));
        }

        public async Task<User> Register(User user)
        {
            await _ctx.AddAsync(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        public async Task<User> RefreshUserInfo(User user)
        {
            try
            {
                var result = await GetById(user.Id.GetValueOrDefault());
                if (result != null)
                {
                    _ctx.Entry(result).CurrentValues.SetValues(user);
                    await _ctx.SaveChangesAsync();
                    return user;
                }
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _ctx.Users
                        .FirstOrDefaultAsync(u => u.UserName.Contains(username));
        }

        public async Task<User> Update(User user)
        {
            var result = await _ctx.Users
                        .FirstOrDefaultAsync(t => t.Id.Equals(user.Id));

            _ctx.Entry(result).CurrentValues.SetValues(user);
            await _ctx.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetById(int Id)
        {
            return await _ctx.Users
                                    .FirstOrDefaultAsync(u => u.Id.Equals(Id));
        }
    }
}