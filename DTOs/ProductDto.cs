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
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
    }
}