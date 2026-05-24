# ProductCRUD
Angular C#.net

# ติดตั้ง Library และ Dependency ในโปรเจกต์ (Restore Packages)
Bash
dotnet restore

# ตั้งค่าระบบฐานข้อมูลและ Data Seeding
ตรวจสอบให้มั่นใจว่าไฟล์ AppDbContext.cs มีข้อมูลเริ่มต้นเรียบร้อย (มีข้อมูลผู้ใช้ Admin, หมวดหมู่ 5 รายการ และสินค้า 15 รายการ) จากนั้นใช้คำสั่งสร้างตารางและอัปเดตลงฐานข้อมูล:
Bash
# สร้างไฟล์ Migration 
dotnet ef migrations add InitialCreate

# ยิง Seed Data เข้าสู่ฐานข้อมูล
dotnet ef database update
4. รันBackend API
Bash
dotnet run
