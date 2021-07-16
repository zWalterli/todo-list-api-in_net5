using System.Threading.Tasks;
using VUTTR.Domain.DTOs;

namespace VUTTR.Service.Interfaces.Interfaces
{
    public interface IUserService
    {
        Task<TokenDto> Login(UserDto user);
        Task<UserDto> Register(UserDto user);
        Task<UserDto> Update(UserDto user);
        Task<UserDto> GetById(int UserId, bool includePassword);
    }
}