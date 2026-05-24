using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductCRUD.Data;
using ProductCRUD.DTOs;
using ProductCRUD.Model;

namespace ProductCRUD.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly string _jwtSecret;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _jwtSecret = _configuration["Jwt:Secret"]!;
        }

        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            var userExists = await _context.Users.AnyAsync(u =>
                u.Username.ToLower() == dto.Username.ToLower()
            );
            if (userExists)
            {
                return new AuthResponseDto { Message = "Username นี้มีผู้ใช้งานแล้ว" };
            }

            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password, salt);

            var newUser = new User
            {
                Username = dto.Username,
                PasswordHash = hashedPassword, // เก็บตัวที่แฮชแล้วลงคอลัมน์ passwordHash
                Role = dto.Role,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Username = newUser.Username,
                Role = newUser.Role,
                Message = "สมัครสมาชิกสำเร็จสำเร็จ",
            };
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null)
                return null;

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isPasswordValid)
                return null;

            var expiresJson = _configuration["Jwt:ExpiresInMinutes"];
            double minutes = double.TryParse(expiresJson, out var parsedMinutes)
                ? parsedMinutes
                : 60;

            var expiresAt = DateTime.UtcNow.AddMinutes(minutes);

            // เริ่มกระบวนการปั๊มตั๋ว JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtSecret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // ฝังชื่อและสิทธิ์ (Role) ลงไปในไส้ของตั๋ว
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(ClaimTypes.Name, user.Username),
                        new Claim(ClaimTypes.Role, user.Role),
                    }
                ),
                Expires = expiresAt,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            string finalToken = tokenHandler.WriteToken(token); 

            return new AuthResponseDto
            {
                Username = user.Username,
                Role = user.Role,
                Token = finalToken, 
                ExpiresAt = expiresAt,
                Message = "เข้าสู่ระบบสำเร็จ",
            };
        }
        // public async Task<bool> DeleteAsync(int id)
        // {
        //     var users = await _context.Users.FindAsync(id);
        //     if (users == null) return false;

        //     _context.Users.Remove(users);
        //     await _context.SaveChangesAsync();
        //     return true;
        // }
    }
}
