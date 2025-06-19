using AuthService.Dtos;
using AuthService.Entities;

namespace AuthService.Interfaces
{
    public interface IUserService
    {
        Task<User?> RegisterAsync(RegisterDto dto);
        Task<User?> LoginAsync(LoginDto dto);
    }
}
