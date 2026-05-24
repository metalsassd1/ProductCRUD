using ProductCRUD.DTOs;

namespace ProductCRUD.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponseDto>> GetAllAsync();
        Task<bool> UpdateAsync(int id, UserUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}