using Microsoft.EntityFrameworkCore;
using ProductCRUD.Data;
using ProductCRUD.DTOs;

namespace ProductCRUD.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
        {
            return await _context.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Username = u.Username,
                    Role = u.Role
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(int id, UserUpdateDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.Username = dto.Username;
            user.Role = dto.Role;

            if (!string.IsNullOrWhiteSpace(dto.NewPassword))
            {
                string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword, salt);
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}