using ProductCRUD.DTOs;

namespace ProductCRUD.Services
{
    public interface IAuthService
    {
        Task<AuthResponseDto> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
        Task<bool> DeleteAsync(int id);
    }
}