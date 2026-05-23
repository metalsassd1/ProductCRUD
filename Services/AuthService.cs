using Microsoft.EntityFrameworkCore;
using ProductCRUD.Data;
using ProductCRUD.DTOs;
using ProductCRUD.Model;

namespace ProductCRUD.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        // 1. 📝 ระบบสมัครสมาชิก (Register)
        public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
        {
            // เช็กก่อนว่าชื่อ Username นี้ถูกคนอื่นใช้ไปหรือยัง
            var userExists = await _context.Users.AnyAsync(u => u.Username.ToLower() == dto.Username.ToLower());
            if (userExists)
            {
                return new AuthResponseDto { Message = "Username นี้มีผู้ใช้งานแล้ว" };
            }

            // 💡 แฮชรหัสผ่านแปลงเป็นตัวเลขยุ่งเหยิงก่อนเซฟลง DB ด้วย BCrypt
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password, salt);

            var newUser = new User
            {
                Username = dto.Username,
                PasswordHash = hashedPassword, // เก็บตัวที่แฮชแล้วลงคอลัมน์ passwordHash
                Role = dto.Role
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return new AuthResponseDto
            {
                Username = newUser.Username,
                Role = newUser.Role,
                Message = "สมัครสมาชิกสำเร็จสำเร็จ"
            };
        }

        // 2. 🔑 ระบบล็อกอิน (Login)
        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            // ค้นหา User ตาม Username ที่ส่งมา
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null) return null; // หาชื่อไม่เจอ ส่ง null กลับไป

            // 💡 ใช้ BCrypt ตรวจสอบว่ารหัสผ่านที่พิมเข้ามา ตรงกับรหัสผ่านที่แฮชไว้ใน DB ไหม
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash);
            if (!isPasswordValid) return null; // รหัสผ่านไม่ตรง ส่ง null กลับไป

            // ถ้ารหัสถูกต้อง ส่งข้อมูลกลับไปให้หน้าบ้านเอาไปเก็บไว้ทำระบบสิทธิ์ต่อ
            return new AuthResponseDto
            {
                Username = user.Username,
                Role = user.Role,
                Message = "เข้าสู่ระบบสำเร็จ"
            };
        }
    }
}