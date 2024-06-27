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
                    invoice_date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    product_images = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { "2e7160a3-82ac-4f7a-93c0-91a0d849cb4d", "Some Product Id", "Some Product Name", 0 },
                    { "3e476202-1b8a-470d-b8b1-7c476edd0d3b", "Some Product Id", "Some Product Name", 0 },
                    { "6bd19672-6a06-47bf-85dc-29fb27031084", "Some Product Id", "Some Product Name", 0 },
                    { "a8f21b99-74f9-4bfb-b8ff-86da24aa039c", "Some Product Id", "Some Product Name", 0 },
                    { "fc3bcb78-7a27-4fa0-a5b9-b529727984eb", "Some Product Id", "Some Product Name", 0 }
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
                    { "D1", "Elegance", 0.12, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D10", "Sparkle Savings III", 0.080000000000000002, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D11", "Ring Gala", 0.10000000000000001, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D12", "Wedding Night", 0.12, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D13", "For Your Love", 0.17000000000000001, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D14", "For Your Love II", 0.23999999999999999, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D15", "Wedding Night II", 0.14999999999999999, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Ring", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D16", "Necklace IV", 0.17999999999999999, new DateTime(2024, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Necklace", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D17", "Necklace V", 0.13, new DateTime(2024, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Necklace", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D18", "Necklace Special", 0.10000000000000001, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P001", "Necklace", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D19", "Earrings Speical III", 0.070000000000000007, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P003", "Earrings", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D2", "Winter Warm-Up", 0.050000000000000003, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D20", "Earrings Speical VI", 0.10000000000000001, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P009", "Earrings", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D21", "Sapphire Bracelet Discount", 0.27000000000000002, new DateTime(2024, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P011", "Bracelet", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D22", "Emerald Necklace Discount", 0.20000000000000001, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P012", "Necklace", new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D23", "Ruby Earrings Discount", 0.17999999999999999, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P013", "Earrings", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D24", "Sapphire Necklace Discount", 0.17999999999999999, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P014", "Necklace", new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D25", "Diamond Necklace Discount", 0.22, new DateTime(2024, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P015", "Necklace", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D26", "Emerald Bracelet Discount", 0.20999999999999999, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "P016", "Bracelet", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D3", "Spring Special", 0.14999999999999999, new DateTime(2024, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D4", "Autumn Breath", 0.10000000000000001, new DateTime(2024, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D5", "New Year Sale", 0.14999999999999999, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D6", "Expired Sale 1", 0.059999999999999998, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D7", "Radiant Reductions I", 0.089999999999999997, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D8", "Sparkle Savings II", 0.10000000000000001, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "D9", "Radiant Reductions II", 0.070000000000000007, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "All", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
                    { "vang10k", 0.0, new DateTime(2024, 6, 27, 17, 51, 55, 584, DateTimeKind.Local).AddTicks(1638), "Vàng nữ trang 41,7%", "10K", 0.0, "VND/Chỉ" },
                    { "vang14k", 0.0, new DateTime(2024, 6, 27, 17, 51, 55, 584, DateTimeKind.Local).AddTicks(1637), "Vàng nữ trang 58,3%", "14K", 0.0, "VND/Chỉ" },
                    { "vang18k", 0.0, new DateTime(2024, 6, 27, 17, 51, 55, 584, DateTimeKind.Local).AddTicks(1633), "Vàng nữ trang 75%", "18K", 0.0, "VND/Chỉ" },
                    { "vang24k", 0.0, new DateTime(2024, 6, 27, 17, 51, 55, 584, DateTimeKind.Local).AddTicks(1620), "Vàng nữ trang 99,99%", "24K", 0.0, "VND/Chỉ" }
                });

            migrationBuilder.InsertData(
                table: "invoice",
                columns: new[] { "invoice_id", "customer_id", "CustomerName", "customer_voucher", "end_total_price", "invoice_date", "InvoiceStatus", "invoice_type", "total_price", "UserFullname", "user_id" },
                values: new object[,]
                {
                    { "I1", "C1", "John Doe", 0m, 798576000m, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 882348000m, "James Martinez", "US3" },
                    { "I10", "C2", "Jane Smith", 0m, 1890000000m, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 2100000000m, "Luna Taylor", "US7" },
                    { "I11", "C5", "Emily Wilson", 0m, 2700000000m, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 3000000000m, "Mateo Martinez", "US4" },
                    { "I12", "C4", "Bob Brown", 0m, 1500000000m, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", 1500000000m, "James Martinez", "US3" },
                    { "I13", "C3", "Alice Johnson", 0m, 2400000000m, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", 2400000000m, "Mateo Martinez", "US4" },
                    { "I14", "C5", "Emily Wilson", 0m, 810000000m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", 900000000m, "Isabel Rodriguez", "US6" },
                    { "I15", "C1", "John Doe", 0m, 1200000000m, new DateTime(2025, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", 1200000000m, "Luna Taylor", "US7" },
                    { "I2", "C2", "Jane Smith", 0m, 192000000m, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 240000000m, "Mateo Martinez", "US4" },
                    { "I3", "C3", "Alice Johnson", 1000000m, 209000000m, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Sale", 225000000m, "Mateo Martinez", "US4" },
                    { "I4", "C5", "Emily Wilson", 500000m, 84500000m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 85000000m, "Isabel Rodriguez", "US6" },
                    { "I5", "C2", "Jane Smith", 0m, 1200000000m, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 1500000000m, "Luna Taylor", "US7" },
                    { "I6", "C4", "Bob Brown", 0m, 2430000000m, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 2700000000m, "Isabel Rodriguez", "US6" },
                    { "I7", "C3", "Alice Johnson", 0m, 864000000m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 960000000m, "Luna Taylor", "US7" },
                    { "I8", "C1", "John Doe", 0m, 990000000m, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 1100000000m, "Mateo Martinez", "US4" },
                    { "I9", "C3", "Alice Johnson", 0m, 720000000m, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", 800000000m, "Emma Young", "US8" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II1", "No Discount", 463488000.0, "I1", "P015", "Diamond Necklace", 1, "Some Stall Id", "Some Stall Name", 463488000.0, 463488000.0, "W1" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II10", "D2", 0.29999999999999999, 288960000.0, "I5", "P021", "Diamond Earring", 2, "Some Stall Id", "Some Stall Name", 412800000.0, 206400000.0, "W10" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II11", "No Discount", 800000000.0, "I5", "P016", "Ruby Necklace", 1, "Some Stall Id", "Some Stall Name", 800000000.0, 800000000.0, "W11" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II12", "D1", 0.20000000000000001, 1440000000.0, "I6", "P011", "Sapphire Ring", 2, "Some Stall Id", "Some Stall Name", 1800000000.0, 900000000.0, "W12" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "II13", "No Discount", 600000000.0, "I6", "P018", "Emerald Bracelet", 1, "Some Stall Id", "Some Stall Name", 600000000.0, 600000000.0, "W13" },
                    { "II14", "No Discount", 480000000.0, "I7", "P013", "Opal Ring", 1, "Some Stall Id", "Some Stall Name", 480000000.0, 480000000.0, "W14" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "II15", "D3", 0.40000000000000002, 288000000.0, "I7", "P022", "Opal Earring", 2, "Some Stall Id", "Some Stall Name", 480000000.0, 240000000.0, "W15" },
                    { "II16", "D4", 0.5, 231744000.0, "I8", "P015", "Diamond Necklace", 1, "Some Stall Id", "Some Stall Name", 463488000.0, 463488000.0, "W16" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II17", "No Discount", 1200000000.0, "I8", "P019", "Emerald Ring", 2, "Some Stall Id", "Some Stall Name", 1200000000.0, 600000000.0, "W17" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II18", "D2", 0.29999999999999999, 560000000.0, "I9", "P017", "Sapphire Necklace", 1, "Some Stall Id", "Some Stall Name", 800000000.0, 800000000.0, "W18" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II19", "No Discount", 500000000.0, "I9", "P012", "Ruby Bracelet", 1, "Some Stall Id", "Some Stall Name", 500000000.0, 500000000.0, "W19" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "II2", "D1", 0.20000000000000001, 165120000.0, "I1", "P021", "Diamond Earring", 1, "Some Stall Id", "Some Stall Name", 206400000.0, 206400000.0, "W2" },
                    { "II20", "D3", 0.40000000000000002, 1080000000.0, "I10", "P011", "Sapphire Ring", 2, "Some Stall Id", "Some Stall Name", 1800000000.0, 900000000.0, "W20" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II21", "No Discount", 600000000.0, "I10", "P020", "Emerald Earring", 1, "Some Stall Id", "Some Stall Name", 600000000.0, 600000000.0, "W21" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II22", "D1", 0.20000000000000001, 1920000000.0, "I11", "P014", "Turquoise Ring", 2, "Some Stall Id", "Some Stall Name", 2400000000.0, 1200000000.0, "W22" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "II23", "No Discount", 40000000.0, "I11", "P023", "Turquoise Cabochon", 1, "Some Stall Id", "Some Stall Name", 40000000.0, 40000000.0, "W23" },
                    { "II24", "No Discount", 1500000000.0, "I12", "P016", "Diamond Ring", 1, "Some Stall Id", "Some Stall Name", 1500000000.0, 1500000000.0, "Not Applied" },
                    { "II26", "No Discount", 2400000000.0, "I13", "P013", "Opal Necklace", 1, "Some Stall Id", "Some Stall Name", 2400000000.0, 2400000000.0, "Not Applied" },
                    { "II28", "No Discount", 900000000.0, "I14", "P011", "Sapphire Ring", 1, "Some Stall Id", "Some Stall Name", 900000000.0, 900000000.0, "Not Applied" },
                    { "II29", "No Discount", 1200000000.0, "I15", "P014", "Turquoise Ring", 1, "Some Stall Id", "Some Stall Name", 1200000000.0, 1200000000.0, "Not Applied" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "II3", "D3", 0.40000000000000002, 48000000.0, "I2", "P005", "Gold Bracelet", 1, "Some Stall Id", "Some Stall Name", 80000000.0, 80000000.0, "W3" },
                    { "II4", "D2", 0.29999999999999999, 144000000.0, "I2", "P010", "Silver Ring", 2, "Some Stall Id", "Some Stall Name", 160000000.0, 80000000.0, "W4" },
                    { "II5", "D1", 0.20000000000000001, 100000000.0, "I3", "P003", "Platinum Necklace", 1, "Some Stall Id", "Some Stall Name", 125000000.0, 125000000.0, "W5" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II6", "No Discount", 100000000.0, "I3", "P018", "Ruby Pendant", 1, "Some Stall Id", "Some Stall Name", 100000000.0, 100000000.0, "W6" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II7", "D2", 0.29999999999999999, 35000000.0, "I4", "P011", "Emerald Ring", 1, "Some Stall Id", "Some Stall Name", 50000000.0, 50000000.0, "W7" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II8", "No Discount", 35000000.0, "I4", "P020", "Sapphire Bracelet", 1, "Some Stall Id", "Some Stall Name", 35000000.0, 35000000.0, "W8" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "StallId", "StallName", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "II9", "D1", 0.20000000000000001, 8000000.0, "I4", "P030", "Gold Earrings", 1, "Some Stall Id", "Some Stall Name", 10000000.0, 10000000.0, "W9" });

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
                    { "P001", 0.0, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE001", "Natural Mozambique Ruby", 0.0, "vang24k", "24K", 45.0, 2000000.0, 1.2, "NEGE00124K", "P001.png", "Ruby Necklace NE-R1-24K", 10, "Necklace", 12, 50.0, 0.0, 0.0 },
                    { "P002", 0.0, new DateTime(2023, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE012", "Burmese Sapphire", 0.0, "vang14k", "14K", 15.0, 1500000.0, 1.1499999999999999, "NES214K", "P002.png", "Sapphire Necklace NE-S2-14K", 15, "Necklace", 12, 20.0, 0.0, 0.0 },
                    { "P003", 0.0, new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE033", "Brazilian Emerald", 0.0, "vang18k", "18K", 13.0, 1800000.0, 1.25, "NEEME03318K", "P003.png", "Emerald Earrings NE-EME033-18K", 25, "Earrings", 24, 18.0, 0.0, 0.0 },
                    { "P004", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 0.0, "vang24k", "24K", 20.0, 2500000.0, 1.3, "NEDIA04124K", "P004.png", "Diamond Ring NE-DIA041-24K", 30, "Ring", 36, 25.0, 0.0, 0.0 },
                    { "P005", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE005", "Mozambique Ruby", 0.0, "vang10k", "10K", 25.0, 2200000.0, 1.1000000000000001, "NERUB00510K", "P005.png", "Ruby Bracelet NE-RUB005-10K", 20, "Bracelet", 12, 30.0, 0.0, 0.0 },
                    { "P006", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE046", "Asscher Cut Diamond", 0.0, "vang24k", "24K", 40.0, 3000000.0, 1.3500000000000001, "NEEMA04618K", "P006.png", "Diamond Necklace NE-EMA046-24K", 10, "Necklace", 24, 45.0, 0.0, 0.0 },
                    { "P007", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE013", "Madagascar Sapphire", 0.0, "vang24k", "24K", 17.0, 2000000.0, 1.2, "NESAP01324K", "P007.png", "Sapphire Ring NE-SAP013-24K", 12, "Ring", 18, 22.0, 0.0, 0.0 },
                    { "P008", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE034", "Afghan Emerald", 0.0, "vang14k", "14K", 14.0, 1700000.0, 1.1499999999999999, "NEEME03414K", "P008.png", "Emerald Necklace NE-EME034-14K", 20, "Necklace", 12, 18.5, 0.0, 0.0 },
                    { "P009", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE043", "Emerald Cut Diamond", 0.0, "vang24k", "24K", 22.0, 2300000.0, 1.25, "NEDIA04318K", "P009.png", "Diamond Earrings NE-DIA043-24K", 18, "Earrings", 24, 27.0, 0.0, 0.0 },
                    { "P010", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE003", "Thai Ruby", 0.0, "vang10k", "10K", 16.0, 1600000.0, 1.1000000000000001, "NERUB00310K", "P010.png", "Ruby Ring NE-RUB003-10K", 15, "Ring", 12, 20.0, 0.0, 0.0 },
                    { "P011", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE014", "Australian Sapphire", 0.0, "vang18k", "18K", 25.0, 2100000.0, 1.22, "NESAP01418K", "P011.png", "Sapphire Bracelet NE-SAP014-18K", 22, "Bracelet", 18, 30.0, 0.0, 0.0 },
                    { "P012", 0.0, new DateTime(2023, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 0.0, "vang24k", "24K", 35.0, 2700000.0, 1.3, "NEEME03124K", "P012.png", "Emerald Necklace NE-EME031-24K", 10, "Necklace", 24, 40.0, 0.0, 0.0 },
                    { "P013", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE004", "India Ruby", 0.0, "vang14k", "14K", 16.0, 1800000.0, 1.1799999999999999, "NERUB00414K", "P013.png", "Ruby Earrings NE-RUB004-14K", 14, "Earrings", 12, 20.0, 0.0, 0.0 },
                    { "P014", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE015", "Kashmir Sapphire", 0.0, "vang18k", "18K", 37.0, 2800000.0, 1.3500000000000001, "NESAP01518K", "P014.png", "Sapphire Necklace NE-SAP015-18K", 8, "Necklace", 24, 42.0, 0.0, 0.0 },
                    { "P015", 0.0, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE044", "Oval Diamond", 0.0, "vang24k", "24K", 20.0, 2400000.0, 1.28, "NEDIA04414K", "P015.png", "Diamond Necklace NE-DIA044-24K", 16, "Necklace", 18, 24.0, 0.0, 0.0 },
                    { "P016", 0.0, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE035", "Russian Emerald", 0.0, "vang10k", "10K", 25.0, 1900000.0, 1.22, "NEEME03510K", "P016.png", "Emerald Bracelet NE-EME035-10K", 18, "Bracelet", 12, 30.0, 0.0, 0.0 },
                    { "P017", 0.0, new DateTime(2021, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE045", "Cushion Cut Diamond", 0.0, "vang24k", "24K", 30.0, 2900000.0, 1.3, "NEDIA04524K", "P017.png", "Diamond Bracelet NE-DIA045-24K", 12, "Bracelet", 36, 35.0, 0.0, 0.0 },
                    { "P018", 0.0, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE032", "Zambian Emerald", 0.0, "vang18k", "18K", 17.0, 2300000.0, 1.25, "NEEME03218K", "P018.png", "Emerald Ring NE-EME032-18K", 15, "Ring", 24, 22.0, 0.0, 0.0 },
                    { "P019", 0.0, new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE002", "Burmese Ruby", 0.0, "vang14k", "14K", 40.0, 2700000.0, 1.28, "NERUB00214K", "P019.png", "Ruby Necklace NE-RUB002-14K", 10, "Necklace", 24, 45.0, 0.0, 0.0 },
                    { "P020", 0.0, new DateTime(2016, 10, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 0.0, "vang10k", "10K", 16.0, 1600000.0, 1.1499999999999999, "NESAP01110K", "P020.png", "Sapphire Earrings NE-SAP011-10K", 20, "Earrings", 18, 20.0, 0.0, 0.0 },
                    { "P021", 0.0, new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 0.0, "vang24k", "24K", 18.0, 2000000.0, 1.2, "NEEMA04114K", "P021.png", "Diamond Earrings NE-EMA041-24K", 18, "Earrings", 24, 22.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "US1", "liam@gmail.com", "Liam Williams", "$2a$11$V1Q7hJNVNcryhyzNW0TCNe/QNaanhYLOdUHT7Q1nVSUlgUJFhTPvK", "Admin", "user1" },
                    { "US2", "olivia@gmail.com", "Olivia Miller", "$2a$11$l8kje79yWPmKpsdxWKzG8e/hWlKkuJjz.SivoTzWoYLfPZpZNKYe2", "Manager", "user2" },
                    { "US3", "james@gmail.com", "James Martinez", "$2a$11$3bAm5AyOZk.r/zpYacEOJOPnOX6wuRTazAl2CGF.z0yOwIjWSb0O6", "Sale", "user3" },
                    { "US4", "matao@gmail.com", "Mateo Martinez", "$2a$11$xMdQ91n5E87kMGRHYH0EMuVU4dyNXCEz9t5rSen/K3ibNi76SOJkq", "Sale", "user4" },
                    { "US5", "theodore@gmail.com", "Theodore Garcia", "$2a$11$qMhF5LymbSOHLnsPAwQfset6k2MKSmSDIvVO1D9j9wsOCbTvq3Y4O", "Cashier", "user5" },
                    { "US6", "isabel@gmail.com", "Isabel Rodriguez", "$2a$11$V3s79vWChxm0N.C9b76z8OXjTbJhG0kl3gZ8XKNfoCddh5.SnTQNq", "Sale", "user6" },
                    { "US7", "luna@gmail.com", "Luna Taylor", "$2a$11$dEDLQwp3nsmkztX58WjSE.MDQRiBcmy99WSli/cc28BtR4OVoNyUK", "Sale", "user7" },
                    { "US8", "emma@gmail.com", "Emma Young", "$2a$11$fahgY/rCXKbZnmJYd9XnUu85pDw8NUTBh1Rq2vdl009WZ6SisBLfy", "Sale", "user8" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "warranty_id", "expire_date", "product_id", "product_name", "start_date" },
                values: new object[,]
                {
                    { "W1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P002", "Product A", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
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
