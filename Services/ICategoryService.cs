using ProductCRUD.DTOs;

namespace ProductCRUD.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponseDto>> GetAllAsync(string? search);
        Task<CategoryResponseDto?> GetByIdAsync(int id);
        //Task<CategoryResponseDto?> GetByNameAsync(string name);
        Task<CategoryResponseDto> CreateAsync(CategoryCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, CategoryCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
