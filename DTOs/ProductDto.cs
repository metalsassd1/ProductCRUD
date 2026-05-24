using System.ComponentModel.DataAnnotations;

namespace ProductCRUD.DTOs
{
    // 🔹 ขาออก (Response): ส่งข้อมูลไปโชว์ในตาราง Angular
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    // 🔹 ขาเข้า (Request): รับข้อมูลมาจากฟอร์มตอนสร้างหรือแก้ไขสินค้า
    public class ProductCreateUpdateDto
    {
        [Required(ErrorMessage = "กรุณากรอกชื่อสินค้า")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "ชื่อสินค้าต้องไม่เกิน 100 ตัวอักษร")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Range(0.01, double.MaxValue, ErrorMessage = "ราคาต้องมากกว่า 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock ต้องไม่ติดลบ")]
        public int Stock { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "กรุณาเลือกหมวดหมู่สินค้า")]
        public int CategoryId { get; set; }
    }

    public class ProductDeleteDto
    {
        public List<int> Ids { get; set; } = new List<int>();
    }
}