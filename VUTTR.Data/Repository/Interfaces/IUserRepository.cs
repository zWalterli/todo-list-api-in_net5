using System.Security.Cryptography;
using System.Threading.Tasks;
using VUTTR.Domain.Models;

namespace VUTTR.Data.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(int UserId);
        Task<User> Login(User user);
        Task<User> RefreshUserInfo(User user);
        Task<User> Register(User user);
        string ComputeHash(string input, SHA256CryptoServiceProvider algorithm);
        Task<User> Update(User user);
        Task<User> GetByUserName(string username);
    }
}