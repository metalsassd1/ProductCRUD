using ProductCRUD.DTOs;

namespace ProductCRUD.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetAllAsync(string? search, int page, int pageSize);
        Task<ProductResponseDto?> GetByIdAsync(int id);
        Task<ProductResponseDto> CreateAsync(ProductCreateUpdateDto dto);
        Task<bool> UpdateAsync(int id, ProductCreateUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}