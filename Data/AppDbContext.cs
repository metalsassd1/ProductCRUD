using Microsoft.EntityFrameworkCore;
using ProductCRUD.Model;

namespace ProductCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        PasswordHash = "$2y$12$zNr.4i/.waJKNJuCDTCa3.XTyHAPmoYIHvpFukV2d7E.TQ7gpfl.G", // "admin1234" hashed
                        Role = "Admin",
                    }
                );

            modelBuilder
                .Entity<Category>()
                .HasData(
                    new Category
                    {
                        Id = 1,
                        Name = "Food & Drinks",
                        Description = "อาหาร เครื่องดื่ม และของกินเล่น",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Home Appliances",
                        Description = "เครื่องใช้ไฟฟ้าภายในบ้านและห้องครัว",
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Electronics & IT",
                        Description = "อุปกรณ์อิเล็กทรอนิกส์และสินค้าไอที",
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Clothing & Fashion",
                        Description = "เสื้อผ้า แฟชั่น และเครื่องแต่งกาย",
                    },
                    new Category
                    {
                        Id = 5,
                        Name = "Health & Beauty",
                        Description = "ผลิตภัณฑ์สุขภาพและความงาม",
                    }
                );

            modelBuilder
                .Entity<Product>()
                .HasData(
                    // Food & Drinks
                    new Product
                    {
                        Id = 1,
                        Name = "กาแฟปรุงสำเร็จผง 3 in 1",
                        Description = "เมล็ดกาแฟโรบัสต้าแท้เข้มข้น",
                        Price = 129.00M,
                        Stock = 150,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "ข้าวหอมมะลิแท้ 100% (5 กก.)",
                        Description = "ข้าวเกี่ยวใหม่ นุ่มเหนียวหอมอร่อย",
                        Price = 245.00M,
                        Stock = 80,
                        CategoryId = 1,
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "บะหมี่กึ่งสำเร็จรูปรสต้มยำกุ้ง",
                        Description = "รสชาติจัดจ้านถึงเครื่อง แพ็ก 10 ซอง",
                        Price = 65.00M,
                        Stock = 340,
                        CategoryId = 1,
                    },
                    // Home Appliances
                    new Product
                    {
                        Id = 4,
                        Name = "พัดลมตั้งพื้น 16 นิ้ว",
                        Description = "ปรับแรงลมได้ 3 ระดับ ประหยัดไฟเบอร์ 5",
                        Price = 599.00M,
                        Stock = 45,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "หม้อหุงข้าวดิจิทัล 1.8 ลิตร",
                        Description = "หม้อในเคลือบสารกันติด หุงข้าวได้หลากหลาย",
                        Price = 1490.00M,
                        Stock = 25,
                        CategoryId = 2,
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "กาต้มน้ำไฟฟ้าสแตนเลส (1.5 ลิตร)",
                        Description = "ต้มน้ำเดือดเร็ว ตัดไฟอัตโนมัติเมื่อเดือด",
                        Price = 390.00M,
                        Stock = 65,
                        CategoryId = 2,
                    },
                    // Electronics & IT
                    new Product
                    {
                        Id = 7,
                        Name = "เมาส์ไร้สายบลูทูธ Ergonomic",
                        Description = "ดีไซน์ประคองมือ ลดอาการปวดข้อมือ",
                        Price = 450.00M,
                        Stock = 120,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "คีย์บอร์ดกลไก Mechanical",
                        Description = "Blue Switch เสียงคลิกสะใจ มีไฟ RGB",
                        Price = 1890.00M,
                        Stock = 40,
                        CategoryId = 3,
                    },
                    new Product
                    {
                        Id = 9,
                        Name = "พาวเวอร์แบงค์ความจุ 20,000 mAh",
                        Description = "รองรับการชาร์จเร็ว Fast Charge พกพาง่าย",
                        Price = 690.00M,
                        Stock = 95,
                        CategoryId = 3,
                    },
                    // Clothing & Fashion
                    new Product
                    {
                        Id = 10,
                        Name = "เสื้อยืดผ้าคอตตอนทรง Oversize",
                        Description = "ผ้าเนื้อนุ่ม ระบายอากาศดี ใส่สบายได้ทุกวัน",
                        Price = 290.00M,
                        Stock = 180,
                        CategoryId = 4,
                    },
                    new Product
                    {
                        Id = 11,
                        Name = "กางเกงยีนส์ขายาวทรงกระบอก",
                        Description = "ผ้ายีนส์ยืดหยุ่นเล็กน้อย ทรงสวยแมตช์ง่าย",
                        Price = 590.00M,
                        Stock = 85,
                        CategoryId = 4,
                    },
                    new Product
                    {
                        Id = 12,
                        Name = "กระเป๋าเป้สะพายหลังกันน้ำ",
                        Description = "มีช่องใส่โน้ตบุ๊กขนาด 15.6 นิ้ว ผ้ากันละอองน้ำ",
                        Price = 890.00M,
                        Stock = 50,
                        CategoryId = 4,
                    },
                    // Health & Beauty
                    new Product
                    {
                        Id = 13,
                        Name = "ครีมกันแดดสูตรน้ำ SPF50+",
                        Description = "บางเบา ซึมไว ไม่เหนียวเหนอะหนะและไม่เป็นคราบ",
                        Price = 420.00M,
                        Stock = 110,
                        CategoryId = 5,
                    },
                    new Product
                    {
                        Id = 14,
                        Name = "เซรั่มไฮยาลูรอนเข้มข้น",
                        Description = "เติมความชุ่มชื้นให้ผิวหน้า ดูอิ่มน้ำฟูกระชับ",
                        Price = 580.00M,
                        Stock = 75,
                        CategoryId = 5,
                    },
                    new Product
                    {
                        Id = 15,
                        Name = "วิตามินซีสกัดเข้มข้น (100 เม็ด)",
                        Description = "เสริมภูมิคุ้มกันให้ร่างกาย บำรุงผิวพรรณ",
                        Price = 320.00M,
                        Stock = 90,
                        CategoryId = 5,
                    }
                );
        }
    }
}
