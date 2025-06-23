using KitapSatisAPI.DTOs;

namespace KitapSatisAPI.Services
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterUserDto dto);
        Task<string?> LoginAsync(LoginDto dto);
    }
}
