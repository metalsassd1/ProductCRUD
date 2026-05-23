using Microsoft.EntityFrameworkCore;
using ProductCRUD.Data;
using ProductCRUD.DTOs;
using ProductCRUD.Model;

namespace ProductCRUD.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryResponseDto>> GetAllAsync(string? search)
        {
            var query = _context.Categories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(c => c.Name.ToLower().Contains(search.ToLower()));
            }
            return await query
                .Select(c => new CategoryResponseDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync(); 
        }

        //public async Task<CategoryResponseDto?> GetByNameAsync(string name)
        //{
        //    var c = await _context.Categories
        //        .FirstOrDefaultAsync(x => x.Name.ToLower().Contains(name.ToLower()));

        //    if (c == null) return null;

        //    return new CategoryResponseDto
        //    {
        //        Id = c.Id,
        //        Name = c.Name,
        //        Description = c.Description
        //    };
        //}

        public async Task<CategoryResponseDto?> GetByIdAsync(int id)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (c == null) return null;

            return new CategoryResponseDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
            };
        }

        public async Task<CategoryResponseDto> CreateAsync(CategoryCreateUpdateDto dto)
        {
            var category = new Category
            {
                Name = dto.Name,
                Description = dto.Description
            };

            // บันทึกเข้าตาราง Categories ให้ตรงตาราง
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }

        public async Task<bool> UpdateAsync(int id, CategoryCreateUpdateDto dto)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            category.Name = dto.Name;
            category.Description = dto.Description;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}