using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "อาหาร เครื่องดื่ม และของกินเล่น", "Food & Drinks" },
                    { 2, "เครื่องใช้ไฟฟ้าภายในบ้านและห้องครัว", "Home Appliances" },
                    { 3, "อุปกรณ์อิเล็กทรอนิกส์และสินค้าไอที", "Electronics & IT" },
                    { 4, "เสื้อผ้า แฟชั่น และเครื่องแต่งกาย", "Clothing & Fashion" },
                    { 5, "ผลิตภัณฑ์สุขภาพและความงาม", "Health & Beauty" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "PasswordHash", "Role", "Username" },
                values: new object[] { 1, "$2y$12$zNr.4i/.waJKNJuCDTCa3.XTyHAPmoYIHvpFukV2d7E.TQ7gpfl.G", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "เมล็ดกาแฟโรบัสต้าแท้เข้มข้น", "กาแฟปรุงสำเร็จผง 3 in 1", 129.00m, 150 },
                    { 2, 1, "ข้าวเกี่ยวใหม่ นุ่มเหนียวหอมอร่อย", "ข้าวหอมมะลิแท้ 100% (5 กก.)", 245.00m, 80 },
                    { 3, 1, "รสชาติจัดจ้านถึงเครื่อง แพ็ก 10 ซอง", "บะหมี่กึ่งสำเร็จรูปรสต้มยำกุ้ง", 65.00m, 340 },
                    { 4, 2, "ปรับแรงลมได้ 3 ระดับ ประหยัดไฟเบอร์ 5", "พัดลมตั้งพื้น 16 นิ้ว", 599.00m, 45 },
                    { 5, 2, "หม้อในเคลือบสารกันติด หุงข้าวได้หลากหลาย", "หม้อหุงข้าวดิจิทัล 1.8 ลิตร", 1490.00m, 25 },
                    { 6, 2, "ต้มน้ำเดือดเร็ว ตัดไฟอัตโนมัติเมื่อเดือด", "กาต้มน้ำไฟฟ้าสแตนเลส (1.5 ลิตร)", 390.00m, 65 },
                    { 7, 3, "ดีไซน์ประคองมือ ลดอาการปวดข้อมือ", "เมาส์ไร้สายบลูทูธ Ergonomic", 450.00m, 120 },
                    { 8, 3, "Blue Switch เสียงคลิกสะใจ มีไฟ RGB", "คีย์บอร์ดกลไก Mechanical", 1890.00m, 40 },
                    { 9, 3, "รองรับการชาร์จเร็ว Fast Charge พกพาง่าย", "พาวเวอร์แบงค์ความจุ 20,000 mAh", 690.00m, 95 },
                    { 10, 4, "ผ้าเนื้อนุ่ม ระบายอากาศดี ใส่สบายได้ทุกวัน", "เสื้อยืดผ้าคอตตอนทรง Oversize", 290.00m, 180 },
                    { 11, 4, "ผ้ายีนส์ยืดหยุ่นเล็กน้อย ทรงสวยแมตช์ง่าย", "กางเกงยีนส์ขายาวทรงกระบอก", 590.00m, 85 },
                    { 12, 4, "มีช่องใส่โน้ตบุ๊กขนาด 15.6 นิ้ว ผ้ากันละอองน้ำ", "กระเป๋าเป้สะพายหลังกันน้ำ", 890.00m, 50 },
                    { 13, 5, "บางเบา ซึมไว ไม่เหนียวเหนอะหนะและไม่เป็นคราบ", "ครีมกันแดดสูตรน้ำ SPF50+", 420.00m, 110 },
                    { 14, 5, "เติมความชุ่มชื้นให้ผิวหน้า ดูอิ่มน้ำฟูกระชับ", "เซรั่มไฮยาลูรอนเข้มข้น", 580.00m, 75 },
                    { 15, 5, "เสริมภูมิคุ้มกันให้ร่างกาย บำรุงผิวพรรณ", "วิตามินซีสกัดเข้มข้น (100 เม็ด)", 320.00m, 90 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
