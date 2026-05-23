using Microsoft.EntityFrameworkCore;
using ProductCRUD.Model;

namespace ProductCRUD.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Electronics", Description = "อุปกรณ์อิเล็กทรอนิกส์และไอที" },
                new Category { Id = 2, Name = "Clothing", Description = "เสื้อผ้า แฟชั่น และเครื่องแต่งกาย" },
                new Category { Id = 3, Name = "Food & Drinks", Description = "อาหาร เครื่องดื่ม และของกินเล่น" }
            );
        }
    }
}