using System.ComponentModel.DataAnnotations;

namespace ProductCRUD.DTOs
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class CategoryCreateUpdateDto
    {
        [Required(ErrorMessage = "กรุณากรอกชื่อหมวดหมู่")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "ชื่อหมวดหมู่ต้องไม่เกิน 50 ตัวอักษร")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}