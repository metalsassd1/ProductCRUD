using System.ComponentModel.DataAnnotations;

namespace ProductCRUD.DTOs
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "กรุณาระบุ Id ของผู้ใช้ที่ต้องการแก้ไข")]
        public int Id { get; set; }

        [Required(ErrorMessage = "กรุณากรอก Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username ต้องมีความยาวระหว่าง 3 ถึง 20 ตัวอักษร")]
        public string Username { get; set; } = string.Empty;

        // 💡 รหัสผ่านใหม่ (ไม่บังคับกรอก ถ้ากรอกต้องมีความยาวตามเกณฑ์)
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password ต้องมีความยาวอย่างน้อย 6 ตัวอักษรขึ้นไป")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "กรุณาระบุสิทธิ์ผู้ใช้งาน")]
        [RegularExpression(@"^(User|Merchant|Admin)$", ErrorMessage = "สิทธิ์ผู้ใช้งานไม่ถูกต้อง")]
        public string Role { get; set; } = "User";
    }
}