using System.ComponentModel.DataAnnotations; // 👈 ต้องใช้ Tool ตัวนี้ในการดักจับ

namespace ProductCRUD.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "กรุณากรอก Username")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username ต้องมีความยาวระหว่าง 3 ถึง 20 ตัวอักษร")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username ต้องเป็นภาษาอังกฤษ ตัวเลข หรือ Under score เท่านั้น")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "กรุณากรอก Password")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password ต้องมีความยาวอย่างน้อย 6 ตัวอักษรขึ้นไป")]
        public string Password { get; set; } = string.Empty;

        // 💡 บล็อกไม่ให้หน้าบ้านเนียนส่ง Role มั่วๆ มาเอง หรือแอบอ้างเป็น Admin
        [RegularExpression(@"^(User|Merchant)$", ErrorMessage = "สิทธิ์ผู้ใช้งานไม่ถูกต้อง")]
        public string Role { get; set; } = "User";
    }
}