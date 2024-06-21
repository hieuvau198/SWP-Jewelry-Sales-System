using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelSystemBE.Migrations
{
    /// <inheritdoc />
    public partial class x : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customer_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    customer_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_rank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    customer_point = table.Column<int>(type: "int", nullable: false),
                    attend_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "discount",
                columns: table => new
                {
                    DiscountId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DiscountName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    OrderType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false),
                    PublicDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "gem",
                columns: table => new
                {
                    gem_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gem_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    gem_price = table.Column<double>(type: "float", nullable: false),
                    GemWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gem", x => x.gem_id);
                });

            migrationBuilder.CreateTable(
                name: "gold",
                columns: table => new
                {
                    gold_id = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gold_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GoldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellPrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gold", x => x.gold_id);
                });

            migrationBuilder.CreateTable(
                name: "ImageRecords",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    invoice_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    invoice_type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    customer_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    invoice_date = table.Column<DateTime>(type: "date", nullable: false),
                    customer_voucher = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    end_total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InvoiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.invoice_id);
                });

            migrationBuilder.CreateTable(
                name: "invoice_item",
                columns: table => new
                {
                    invoice_item_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    invoice_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StallId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    discount_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount_rate = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    total_price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    end_total_price = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    warranty_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_item", x => x.invoice_item_id);
                });

            migrationBuilder.CreateTable(
                name: "jewel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jewel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    product_images = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    product_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    product_weight = table.Column<double>(type: "float", nullable: false),
                    product_warranty = table.Column<int>(type: "int", nullable: false),
                    markup_rate = table.Column<double>(type: "float", nullable: false),
                    gem_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemWeight = table.Column<double>(type: "float", nullable: false),
                    gold_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gold_weight = table.Column<double>(type: "float", nullable: false),
                    labor_cost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "StallItems",
                columns: table => new
                {
                    StallItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StallItems", x => x.StallItemId);
                });

            migrationBuilder.CreateTable(
                name: "Stalls",
                columns: table => new
                {
                    StallId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stalls", x => x.StallId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "warranty",
                columns: table => new
                {
                    warranty_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start_date = table.Column<DateTime>(type: "date", nullable: false),
                    expire_date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warranty", x => x.warranty_id);
                });

            migrationBuilder.InsertData(
                table: "ImageRecords",
                columns: new[] { "Id", "FileName", "Path" },
                values: new object[,]
                {
                    { "2f29b6a7-8010-4a90-853f-c896fd387793", "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg", "dfyqz4e-f004994b-129e-44ad-853f-3eaae3112671.jpg" },
                    { "58bbac95-17ef-484c-a0d8-24494f8d36a5", "hentai.png", "hentai.png" },
                    { "de9b5453-15d2-41a0-922e-1edbcc6e0bef", "maxresdefault.jpg", "maxresdefault.jpg" },
                    { "e4b1110f-0340-48d3-82b0-9315acc175e0", "RDT_20240603_1700187451959011441817016.jpg", "RDT_20240603_1700187451959011441817016.jpg" }
                });

            migrationBuilder.InsertData(
                table: "StallItems",
                columns: new[] { "StallItemId", "ProductId", "ProductName", "quantity" },
                values: new object[,]
                {
                    { "1fa19f53-fdb0-4c2a-ad8f-5ce35e94e76e", "Some Product Id", "Some Product Name", 0 },
                    { "3357a839-1a6e-4f57-9f33-92e387924dd3", "Some Product Id", "Some Product Name", 0 },
                    { "519d9aa9-4a2c-48c6-92ef-eef9093e4334", "Some Product Id", "Some Product Name", 0 },
                    { "691dc2bd-e5c4-4e2b-a765-07057b195860", "Some Product Id", "Some Product Name", 0 },
                    { "bd30616b-cf77-48df-860b-4d15a07de47c", "Some Product Id", "Some Product Name", 0 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "StallId", "StaffName", "StallDescription", "StallName", "StallType", "UserId" },
                values: new object[,]
                {
                    { "S1", "1", "1", "Ring", "Ring", "US3" },
                    { "S2", "1", "1", "Bracelet", "Bracelet", "US4" },
                    { "S3", "1", "1", "Necklace", "Necklace", "US6" },
                    { "S4", "1", "1", "Earring", "Earring", "US7" },
                    { "S5", "1", "1", "Anklet", "Anklet", "US8" }
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "customer_id", "attend_date", "customer_name", "CustomerPhone", "customer_point", "customer_rank" },
                values: new object[,]
                {
                    { "C1", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "012345678", 100, "Gold" },
                    { "C2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", "012345677", 80, "Silver" },
                    { "C3", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", "012345676", 50, "Bronze" },
                    { "C4", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Brown", "012345675", 120, "Bronze" },
                    { "C5", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Wilson", "012345674", 90, "Bronze" }
                });

            migrationBuilder.InsertData(
                table: "discount",
                columns: new[] { "DiscountId", "DiscountName", "DiscountRate", "ExpireDate", "OrderType", "ProductId", "ProductType", "PublicDate" },
                values: new object[,]
                {
                    { "D1", "Summer Sale", 0.20000000000000001, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D2", "Holiday Promotion", 0.29999999999999999, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D3", "Spring Clearance", 0.40000000000000002, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Bracelet", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D4", "Back-to-School Sale", 0.5, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P002", "Ring", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D5", "Winter Warm-up", 0.0, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Necklace", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "gem",
                columns: new[] { "gem_id", "BuyPrice", "GemCode", "gem_name", "gem_price", "GemWeight", "Unit" },
                values: new object[,]
                {
                    { "GE001", 50000000.0, "JSG-R1", "Natural Mozambique Ruby", 58000000.0, 0.97999999999999998, "ct" },
                    { "GE002", 170000000.0, "JSG-R2", "Burmese Ruby", 190000000.0, 28.0, "ct" },
                    { "GE003", 8235000.0, "JSG-R3", "Thai Ruby", 9756000.0, 9.9399999999999995, "ct" },
                    { "GE004", 1322012.0, "JSG-R4", "India Ruby", 1709078.0, 5.9100000000000001, "ct" },
                    { "GE005", 6900000.0, "JSG-R5", "Mozambique Ruby", 7859078.0, 0.33000000000000002, "ct" },
                    { "GE006", 3700000.0, "JSG-R6", "Heated Natural Ruby", 4166666.0, 0.34000000000000002, "ct" },
                    { "GE007", 8989000.0, "JSG-R7", "Mozambique Ruby", 9789973.0, 0.35999999999999999, "ct" },
                    { "GE008", 4950000.0, "JSG-R8", "Mozambique Ruby (Heated)", 5826558.0, 0.48999999999999999, "ct" },
                    { "GE009", 11900000.0, "JSG-R9", "Mozambique Ruby", 13000000.0, 0.48999999999999999, "ct" },
                    { "GE010", 3000000.0, "JSG-R10", "Burma Ruby", 3658000.0, 0.54000000000000004, "ct" },
                    { "GE011", 30000000.0, "JSG-S1", "Natural Ceylon Sapphire", 35000000.0, 1.02, "ct" },
                    { "GE012", 65000000.0, "JSG-S2", "Burmese Sapphire", 75000000.0, 2.75, "ct" },
                    { "GE013", 22000000.0, "JSG-S3", "Madagascar Sapphire", 26000000.0, 1.5, "ct" },
                    { "GE014", 18000000.0, "JSG-S4", "Australian Sapphire", 21000000.0, 3.2000000000000002, "ct" },
                    { "GE015", 120000000.0, "JSG-S5", "Kashmir Sapphire", 140000000.0, 0.94999999999999996, "ct" },
                    { "GE016", 45000000.0, "JSG-S6", "Heated Natural Sapphire", 50000000.0, 2.1000000000000001, "ct" },
                    { "GE017", 35000000.0, "JSG-S7", "Thai Sapphire", 40000000.0, 1.8, "ct" },
                    { "GE018", 5000000.0, "JSG-S8", "Montana Sapphire", 6000000.0, 0.71999999999999997, "ct" },
                    { "GE019", 28000000.0, "JSG-S9", "Ethiopian Sapphire", 32000000.0, 1.3, "ct" },
                    { "GE020", 150000000.0, "JSG-S10", "Padparadscha Sapphire", 180000000.0, 1.0, "ct" },
                    { "GE021", 5000000.0, "JSG-C1", "Moonstone Cabochon", 6000000.0, 3.5, "ct" },
                    { "GE022", 12000000.0, "JSG-C2", "Opal Cabochon", 15000000.0, 2.1000000000000001, "ct" },
                    { "GE023", 3000000.0, "JSG-C3", "Turquoise Cabochon", 4000000.0, 4.7000000000000002, "ct" },
                    { "GE024", 2000000.0, "JSG-C4", "Labradorite Cabochon", 3000000.0, 5.0, "ct" },
                    { "GE025", 25000000.0, "JSG-C5", "Star Sapphire Cabochon", 30000000.0, 3.2000000000000002, "ct" },
                    { "GE026", 45000000.0, "JSG-C6", "Cat's Eye Chrysoberyl Cabochon", 52000000.0, 2.5, "ct" },
                    { "GE027", 15000000.0, "JSG-C7", "Jade Cabochon", 18000000.0, 6.7999999999999998, "ct" },
                    { "GE028", 5000000.0, "JSG-C8", "Lapis Lazuli Cabochon", 6000000.0, 7.5, "ct" },
                    { "GE029", 2000000.0, "JSG-C9", "Amazonite Cabochon", 2500000.0, 4.2000000000000002, "ct" },
                    { "GE030", 7000000.0, "JSG-C10", "Garnet Cabochon", 8500000.0, 3.0, "ct" },
                    { "GE031", 50000000.0, "JSG-E1", "Colombian Emerald", 58000000.0, 1.2, "ct" },
                    { "GE032", 120000000.0, "JSG-E2", "Zambian Emerald", 140000000.0, 2.5, "ct" },
                    { "GE033", 80000000.0, "JSG-E3", "Brazilian Emerald", 92000000.0, 1.8, "ct" },
                    { "GE034", 60000000.0, "JSG-E4", "Afghan Emerald", 75000000.0, 2.2000000000000002, "ct" },
                    { "GE035", 70000000.0, "JSG-E5", "Russian Emerald", 82000000.0, 1.5, "ct" },
                    { "GE036", 15000000.0, "JSG-E6", "Synthetic Emerald", 18000000.0, 3.0, "ct" },
                    { "GE037", 100000000.0, "JSG-E7", "Zambian Emerald", 120000000.0, 1.1000000000000001, "ct" },
                    { "GE038", 45000000.0, "JSG-E8", "Colombian Emerald", 52000000.0, 0.90000000000000002, "ct" },
                    { "GE039", 95000000.0, "JSG-E9", "Brazilian Emerald", 110000000.0, 2.7000000000000002, "ct" },
                    { "GE040", 55000000.0, "JSG-E10", "Ethiopian Emerald", 65000000.0, 1.3, "ct" },
                    { "GE041", 150000000.0, "JSG-D1", "Round Brilliant Diamond", 170000000.0, 1.0, "ct" },
                    { "GE042", 250000000.0, "JSG-D2", "Princess Cut Diamond", 290000000.0, 1.5, "ct" },
                    { "GE043", 400000000.0, "JSG-D3", "Emerald Cut Diamond", 450000000.0, 2.0, "ct" },
                    { "GE044", 180000000.0, "JSG-D4", "Oval Diamond", 210000000.0, 1.2, "ct" },
                    { "GE045", 320000000.0, "JSG-D5", "Cushion Cut Diamond", 370000000.0, 1.8, "ct" },
                    { "GE046", 200000000.0, "JSG-D6", "Asscher Cut Diamond", 230000000.0, 1.3, "ct" },
                    { "GE047", 280000000.0, "JSG-D7", "Marquise Diamond", 320000000.0, 1.6000000000000001, "ct" },
                    { "GE048", 170000000.0, "JSG-D8", "Radiant Cut Diamond", 200000000.0, 1.1000000000000001, "ct" },
                    { "GE049", 230000000.0, "JSG-D9", "Pear Shaped Diamond", 270000000.0, 1.3999999999999999, "ct" },
                    { "GE050", 150000000.0, "JSG-D10", "Heart Shaped Diamond", 180000000.0, 1.0, "ct" }
                });

            migrationBuilder.InsertData(
                table: "gold",
                columns: new[] { "gold_id", "BuyPrice", "Date", "GoldCode", "gold_name", "SellPrice", "Unit" },
                values: new object[,]
                {
                    { "vang10k", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(2579), "Vàng nữ trang 41,7%", "10K", 0.0, "VND/Chỉ" },
                    { "vang14k", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(2577), "Vàng nữ trang 58,3%", "14K", 0.0, "VND/Chỉ" },
                    { "vang18k", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(2574), "Vàng nữ trang 75%", "18K", 0.0, "VND/Chỉ" },
                    { "vang24k", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(2559), "Vàng nữ trang 99,99%", "24K", 0.0, "VND/Chỉ" }
                });

            migrationBuilder.InsertData(
                table: "invoice",
                columns: new[] { "invoice_id", "customer_id", "CustomerName", "customer_voucher", "end_total_price", "invoice_date", "InvoiceStatus", "invoice_type", "total_price", "UserFullname", "user_id" },
                values: new object[,]
                {
                    { "I1", "C1", "Some Customer Name", 50m, 450m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type A", 500m, "Some User Fullname", "U1" },
                    { "I2", "C2", "Some Customer Name", 30m, 670m, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type B", 700m, "Some User Fullname", "U2" },
                    { "I3", "C3", "Some Customer Name", 20m, 280m, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type C", 300m, "Some User Fullname", "U3" },
                    { "I4", "C4", "Some Customer Name", 40m, 960m, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type D", 1000m, "Some User Fullname", "U1" },
                    { "I5", "C5", "Some Customer Name", 60m, 740m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type E", 800m, "Some User Fullname", "U2" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "1", "1", 21.0, "I1", "1", "Product 1", 2, "Some Stall Id", "Some Stall Name", 21.0, 10.5, "W1" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "2", "1", 0.14999999999999999, 21.890000000000001, "I1", "2", "Product 2", 1, "Some Stall Id", "Some Stall Name", 21.890000000000001, 25.75, "W2" });

            migrationBuilder.InsertData(
                table: "jewel",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Necklace" },
                    { 2, "Bracelet" },
                    { 3, "Ring" },
                    { 4, "Earrings" },
                    { 5, "Pendant" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "product_id", "BuyPrice", "created_at", "gem_id", "GemName", "GemWeight", "gold_id", "GoldName", "gold_weight", "labor_cost", "markup_rate", "product_code", "product_images", "product_name", "product_quantity", "product_type", "product_warranty", "product_weight", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { "P001", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4897), "GE001", "Some Gem Name", 0.0, "vang24k", "Some Gold Name", 45.0, 200.0, 1.2, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0, 0.0, 0.0 },
                    { "P002", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4902), "GE005", "Some Gem Name", 0.0, "vang10k", "Some Gold Name", 18.0, 100.0, 1.5, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0, 0.0, 0.0 },
                    { "P003", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4939), "GE015", "Some Gem Name", 0.0, "vang24k", "Some Gold Name", 27.0, 150.0, 1.3, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0, 0.0, 0.0 },
                    { "P004", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4943), "GE035", "Some Gem Name", 0.0, "vang10k", "Some Gold Name", 13.5, 180.0, 1.7, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earring", 24, 15.0, 0.0, 0.0 },
                    { "P005", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4946), "GE045", "Some Gem Name", 0.0, "vang10k", "Some Gold Name", 7.5, 90.0, 1.1000000000000001, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Necklace", 6, 10.0, 0.0, 0.0 },
                    { "P006", 0.0, new DateTime(2024, 6, 21, 21, 49, 59, 823, DateTimeKind.Local).AddTicks(4949), "GE025", "Some Gem Name", 0.0, "vang24k", "Some Gold Name", 21.0, 130.0, 1.2, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "US1", "liam@gmail.com", "Liam Williams", "$2a$11$H47tctI1Rr43gAhBTEBVfuGvjlp3FgK5keO/ThoAlHxqmceMZTT0C", "Admin", "user1" },
                    { "US2", "olivia@gmail.com", "Olivia Miller", "$2a$11$H80l9U..HySqAatR9Bm8Pe749rrGjrMZgZv8Fg4RA1LRLKj3y8FUW", "Manager", "user2" },
                    { "US3", "james@gmail.com", "James Martinez", "$2a$11$Mz9PkyplrXGBDiUb/TChXe/rvJpBzSZzpsoBwYgdQyuENEoFmJ8zK", "Sale", "user3" },
                    { "US4", "matao@gmail.com", "Mateo Martinez", "$2a$11$cus678R3KnTMceiPz8pK1uFOVl7xUtAY7CqjhrwkVCMiKwQuNyYyS", "Sale", "user4" },
                    { "US5", "theodore@gmail.com", "Theodore Garcia", "$2a$11$wYqKwULxLxVShI7hb6QbRekQoKuraRRjq.DTwBrtM9LTtCaXz5VXa", "Cashier", "user5" },
                    { "US6", "isabel@gmail.com", "Isabel Rodriguez", "$2a$11$NbR58M5awB9MgCh9Z7cfeOsc9518d1qMeFLELCtCbj1bU3onuovI6", "Sale", "user6" },
                    { "US7", "luna@gmail.com", "Luna Taylor", "$2a$11$tpNi905Z5EXAyqVAFBf44euk20MEmpl.DT/UiqQvj49MiEYoxqQ5S", "Sale", "user7" },
                    { "US8", "emma@gmail.com", "Emma Young", "$2a$11$7e79F/m6LqVjnTU6kAIr7uIwci2j3uFlKTwL8j628Ajpd0OzAqR3C", "Sale", "user8" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "warranty_id", "expire_date", "product_id", "product_name", "start_date" },
                values: new object[,]
                {
                    { "W1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P1", "Product A", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W2", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P2", "Product B", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W4", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "discount");

            migrationBuilder.DropTable(
                name: "gem");

            migrationBuilder.DropTable(
                name: "gold");

            migrationBuilder.DropTable(
                name: "ImageRecords");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "invoice_item");

            migrationBuilder.DropTable(
                name: "jewel");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "StallItems");

            migrationBuilder.DropTable(
                name: "Stalls");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "warranty");
        }
    }
}
