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
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerRank = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPoint = table.Column<int>(type: "int", nullable: false),
                    AttendDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Discounts", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Gems",
                columns: table => new
                {
                    GemId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GemName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GemCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    GemPrice = table.Column<double>(type: "float", nullable: false),
                    GemWeight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gems", x => x.GemId);
                });

            migrationBuilder.CreateTable(
                name: "Golds",
                columns: table => new
                {
                    GoldId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GoldName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GoldCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellPrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Golds", x => x.GoldId);
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
                name: "InvoiceItems",
                columns: table => new
                {
                    InvoiceItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    DiscountId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    EndTotalPrice = table.Column<double>(type: "float", nullable: false),
                    WarrantyId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.InvoiceItemId);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InvoiceType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashierId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CashierFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerVoucher = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    EndTotalPrice = table.Column<double>(type: "float", nullable: false),
                    InvoiceStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                });

            migrationBuilder.CreateTable(
                name: "Jewels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductImages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductWeight = table.Column<double>(type: "float", nullable: false),
                    ProductWarranty = table.Column<int>(type: "int", nullable: false),
                    MarkupRate = table.Column<double>(type: "float", nullable: false),
                    GemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GemWeight = table.Column<double>(type: "float", nullable: false),
                    GoldId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GoldWeight = table.Column<double>(type: "float", nullable: false),
                    LaborCost = table.Column<double>(type: "float", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    BuyPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "StallEmployees",
                columns: table => new
                {
                    StallEmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StallId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StallName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeFullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StallEmployees", x => x.StallEmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "StallItems",
                columns: table => new
                {
                    StallItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StallId = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Users",
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
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Warranties",
                columns: table => new
                {
                    WarrantyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warranties", x => x.WarrantyId);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "AttendDate", "CustomerName", "CustomerPhone", "CustomerPoint", "CustomerRank" },
                values: new object[,]
                {
                    { "C1", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", "012345678", 100, "Gold" },
                    { "C2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", "012345677", 80, "Silver" },
                    { "C3", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", "012345676", 50, "Bronze" },
                    { "C4", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Brown", "012345675", 120, "Bronze" },
                    { "C5", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Wilson", "012345674", 90, "Bronze" }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
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
                table: "Gems",
                columns: new[] { "GemId", "BuyPrice", "GemCode", "GemName", "GemPrice", "GemWeight", "Unit" },
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
                table: "Golds",
                columns: new[] { "GoldId", "BuyPrice", "Date", "GoldCode", "GoldName", "SellPrice", "Unit" },
                values: new object[,]
                {
                    { "vang10k", 0.0, new DateTime(2024, 7, 12, 15, 34, 28, 489, DateTimeKind.Local).AddTicks(8281), "Vàng nữ trang 41,7%", "10K", 0.0, "Mace" },
                    { "vang14k", 0.0, new DateTime(2024, 7, 12, 15, 34, 28, 489, DateTimeKind.Local).AddTicks(8279), "Vàng nữ trang 58,3%", "14K", 0.0, "Mace" },
                    { "vang18k", 0.0, new DateTime(2024, 7, 12, 15, 34, 28, 489, DateTimeKind.Local).AddTicks(8276), "Vàng nữ trang 75%", "18K", 0.0, "Mace" },
                    { "vang24k", 0.0, new DateTime(2024, 7, 12, 15, 34, 28, 489, DateTimeKind.Local).AddTicks(8255), "Vàng nữ trang 99,99%", "24K", 0.0, "Mace" }
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
                table: "InvoiceItems",
                columns: new[] { "InvoiceItemId", "DiscountId", "DiscountRate", "EndTotalPrice", "InvoiceId", "ProductId", "ProductName", "Quantity", "StallId", "StallName", "TotalPrice", "UnitPrice", "WarrantyId" },
                values: new object[,]
                {
                    { "II1", "No Discount", 0.0, 463488000.0, "I1", "P015", "Diamond Necklace", 1, "Some Stall Id", "Some Stall Name", 463488000.0, 463488000.0, "W1" },
                    { "II10", "D2", 0.29999999999999999, 288960000.0, "I5", "P021", "Diamond Earring", 2, "Some Stall Id", "Some Stall Name", 412800000.0, 206400000.0, "W10" },
                    { "II11", "No Discount", 0.0, 800000000.0, "I5", "P016", "Ruby Necklace", 1, "Some Stall Id", "Some Stall Name", 800000000.0, 800000000.0, "W11" },
                    { "II12", "D1", 0.20000000000000001, 1440000000.0, "I6", "P011", "Sapphire Ring", 2, "Some Stall Id", "Some Stall Name", 1800000000.0, 900000000.0, "W12" },
                    { "II13", "No Discount", 0.0, 600000000.0, "I6", "P018", "Emerald Bracelet", 1, "Some Stall Id", "Some Stall Name", 600000000.0, 600000000.0, "W13" },
                    { "II14", "No Discount", 0.0, 480000000.0, "I7", "P013", "Opal Ring", 1, "Some Stall Id", "Some Stall Name", 480000000.0, 480000000.0, "W14" },
                    { "II15", "D3", 0.40000000000000002, 288000000.0, "I7", "P022", "Opal Earring", 2, "Some Stall Id", "Some Stall Name", 480000000.0, 240000000.0, "W15" },
                    { "II16", "D4", 0.5, 231744000.0, "I8", "P015", "Diamond Necklace", 1, "Some Stall Id", "Some Stall Name", 463488000.0, 463488000.0, "W16" },
                    { "II17", "No Discount", 0.0, 1200000000.0, "I8", "P019", "Emerald Ring", 2, "Some Stall Id", "Some Stall Name", 1200000000.0, 600000000.0, "W17" },
                    { "II18", "D2", 0.29999999999999999, 560000000.0, "I9", "P017", "Sapphire Necklace", 1, "Some Stall Id", "Some Stall Name", 800000000.0, 800000000.0, "W18" },
                    { "II19", "No Discount", 0.0, 500000000.0, "I9", "P012", "Ruby Bracelet", 1, "Some Stall Id", "Some Stall Name", 500000000.0, 500000000.0, "W19" },
                    { "II2", "D1", 0.20000000000000001, 165120000.0, "I1", "P021", "Diamond Earring", 1, "Some Stall Id", "Some Stall Name", 206400000.0, 206400000.0, "W2" },
                    { "II20", "D3", 0.40000000000000002, 1080000000.0, "I10", "P011", "Sapphire Ring", 2, "Some Stall Id", "Some Stall Name", 1800000000.0, 900000000.0, "W20" },
                    { "II21", "No Discount", 0.0, 600000000.0, "I10", "P020", "Emerald Earring", 1, "Some Stall Id", "Some Stall Name", 600000000.0, 600000000.0, "W21" },
                    { "II22", "D1", 0.20000000000000001, 1920000000.0, "I11", "P014", "Turquoise Ring", 2, "Some Stall Id", "Some Stall Name", 2400000000.0, 1200000000.0, "W22" },
                    { "II23", "No Discount", 0.0, 40000000.0, "I11", "P021", "Turquoise Cabochon", 1, "Some Stall Id", "Some Stall Name", 40000000.0, 40000000.0, "W23" },
                    { "II24", "No Discount", 0.0, 1500000000.0, "I12", "P016", "Diamond Ring", 1, "Some Stall Id", "Some Stall Name", 1500000000.0, 1500000000.0, "Not Applied" },
                    { "II26", "No Discount", 0.0, 2400000000.0, "I13", "P013", "Opal Necklace", 1, "Some Stall Id", "Some Stall Name", 2400000000.0, 2400000000.0, "Not Applied" },
                    { "II28", "No Discount", 0.0, 900000000.0, "I14", "P011", "Sapphire Ring", 1, "Some Stall Id", "Some Stall Name", 900000000.0, 900000000.0, "Not Applied" },
                    { "II29", "No Discount", 0.0, 1200000000.0, "I15", "P014", "Turquoise Ring", 1, "Some Stall Id", "Some Stall Name", 1200000000.0, 1200000000.0, "Not Applied" },
                    { "II3", "D3", 0.40000000000000002, 48000000.0, "I2", "P005", "Gold Bracelet", 1, "Some Stall Id", "Some Stall Name", 80000000.0, 80000000.0, "W3" },
                    { "II4", "D2", 0.29999999999999999, 144000000.0, "I2", "P010", "Silver Ring", 2, "Some Stall Id", "Some Stall Name", 160000000.0, 80000000.0, "W4" },
                    { "II5", "D1", 0.20000000000000001, 100000000.0, "I3", "P003", "Platinum Necklace", 1, "Some Stall Id", "Some Stall Name", 125000000.0, 125000000.0, "W5" },
                    { "II6", "No Discount", 0.0, 100000000.0, "I3", "P018", "Ruby Pendant", 1, "Some Stall Id", "Some Stall Name", 100000000.0, 100000000.0, "W6" },
                    { "II7", "D2", 0.29999999999999999, 35000000.0, "I4", "P011", "Emerald Ring", 1, "Some Stall Id", "Some Stall Name", 50000000.0, 50000000.0, "W7" },
                    { "II8", "No Discount", 0.0, 35000000.0, "I4", "P020", "Sapphire Bracelet", 1, "Some Stall Id", "Some Stall Name", 35000000.0, 35000000.0, "W8" },
                    { "II9", "D1", 0.20000000000000001, 8000000.0, "I4", "P030", "Gold Earrings", 1, "Some Stall Id", "Some Stall Name", 10000000.0, 10000000.0, "W9" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "CashierFullname", "CashierId", "CustomerId", "CustomerName", "CustomerVoucher", "EndTotalPrice", "InvoiceDate", "InvoiceStatus", "InvoiceType", "ManagerFullname", "ManagerId", "StallId", "StallName", "TotalPrice", "UserFullname", "UserId" },
                values: new object[,]
                {
                    { "I1", "Theodore Garcia", "US5", "C1", "John Doe", 0.0, 798576000.0, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 882348000.0, "James Martinez", "US3" },
                    { "I10", "Theodore Garcia", "US5", "C2", "Jane Smith", 0.0, 1890000000.0, new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 2100000000.0, "Luna Taylor", "US7" },
                    { "I11", "Theodore Garcia", "US5", "C5", "Emily Wilson", 0.0, 2700000000.0, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 3000000000.0, "Mateo Martinez", "US4" },
                    { "I12", "Theodore Garcia", "US5", "C4", "Bob Brown", 0.0, 1500000000.0, new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", "Olivia Miller", "US2", "ST01", "Stall A", 1500000000.0, "James Martinez", "US3" },
                    { "I13", "Theodore Garcia", "US5", "C3", "Alice Johnson", 0.0, 2400000000.0, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", "Olivia Miller", "US2", "ST01", "Stall A", 2400000000.0, "Mateo Martinez", "US4" },
                    { "I14", "Theodore Garcia", "US5", "C5", "Emily Wilson", 0.0, 810000000.0, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", "Olivia Miller", "US2", "ST01", "Stall A", 900000000.0, "Isabel Rodriguez", "US6" },
                    { "I15", "Theodore Garcia", "US5", "C1", "John Doe", 0.0, 1200000000.0, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Buy", "Olivia Miller", "US2", "ST01", "Stall A", 1200000000.0, "Luna Taylor", "US7" },
                    { "I2", "Theodore Garcia", "US5", "C2", "Jane Smith", 0.0, 192000000.0, new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 240000000.0, "Mateo Martinez", "US4" },
                    { "I3", "Theodore Garcia", "US5", "C3", "Alice Johnson", 1000000.0, 209000000.0, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 225000000.0, "Mateo Martinez", "US4" },
                    { "I4", "Theodore Garcia", "US5", "C5", "Emily Wilson", 500000.0, 84500000.0, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 85000000.0, "Isabel Rodriguez", "US6" },
                    { "I5", "Theodore Garcia", "US5", "C2", "Jane Smith", 0.0, 1200000000.0, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 1500000000.0, "Luna Taylor", "US7" },
                    { "I6", "Theodore Garcia", "US5", "C4", "Bob Brown", 0.0, 2430000000.0, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 2700000000.0, "Isabel Rodriguez", "US6" },
                    { "I7", "Theodore Garcia", "US5", "C3", "Alice Johnson", 0.0, 864000000.0, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 960000000.0, "Luna Taylor", "US7" },
                    { "I8", "Theodore Garcia", "US5", "C1", "John Doe", 0.0, 990000000.0, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 1100000000.0, "Mateo Martinez", "US4" },
                    { "I9", "Theodore Garcia", "US5", "C3", "Alice Johnson", 0.0, 720000000.0, new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Complete", "Sale", "Olivia Miller", "US2", "ST01", "Stall A", 800000000.0, "Emma Young", "US8" }
                });

            migrationBuilder.InsertData(
                table: "Jewels",
                columns: new[] { "Id", "IsComplete", "Name" },
                values: new object[,]
                {
                    { 1, false, "Necklace" },
                    { 2, false, "Bracelet" },
                    { 3, false, "Ring" },
                    { 4, false, "Earrings" },
                    { 5, false, "Pendant" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "BuyPrice", "CreatedAt", "GemId", "GemName", "GemWeight", "GoldId", "GoldName", "GoldWeight", "LaborCost", "MarkupRate", "ProductCode", "ProductImages", "ProductName", "ProductQuantity", "ProductType", "ProductWarranty", "ProductWeight", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { "P001", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE001", "Natural Mozambique Ruby", 0.0, "vang24k", "24K", 45.0, 2000000.0, 1.2, "NEGE00124K", "P001.png", "Ruby Necklace NE-R1-24K", 10, "Necklace", 12, 50.0, 0.0, 0.0 },
                    { "P002", 0.0, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE012", "Burmese Sapphire", 0.0, "vang14k", "14K", 15.0, 1500000.0, 1.1499999999999999, "NES214K", "P002.png", "Sapphire Necklace NE-S2-14K", 15, "Necklace", 12, 20.0, 0.0, 0.0 },
                    { "P003", 0.0, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE033", "Brazilian Emerald", 0.0, "vang18k", "18K", 13.0, 1800000.0, 1.25, "NEEME03318K", "P003.png", "Emerald Earrings NE-EME033-18K", 25, "Earrings", 24, 18.0, 0.0, 0.0 },
                    { "P004", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 0.0, "vang24k", "24K", 20.0, 2500000.0, 1.3, "NEDIA04124K", "P004.png", "Diamond Ring NE-DIA041-24K", 30, "Ring", 36, 25.0, 0.0, 0.0 },
                    { "P005", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE005", "Mozambique Ruby", 0.0, "vang10k", "10K", 25.0, 2200000.0, 1.1000000000000001, "NERUB00510K", "P005.png", "Ruby Bracelet NE-RUB005-10K", 20, "Bracelet", 12, 30.0, 0.0, 0.0 },
                    { "P006", 0.0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE046", "Asscher Cut Diamond", 0.0, "vang24k", "24K", 40.0, 3000000.0, 1.3500000000000001, "NEEMA04618K", "P006.png", "Diamond Necklace NE-EMA046-24K", 10, "Necklace", 24, 45.0, 0.0, 0.0 },
                    { "P007", 0.0, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE013", "Madagascar Sapphire", 0.0, "vang24k", "24K", 17.0, 2000000.0, 1.2, "NESAP01324K", "P007.png", "Sapphire Ring NE-SAP013-24K", 12, "Ring", 18, 22.0, 0.0, 0.0 },
                    { "P008", 0.0, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE034", "Afghan Emerald", 0.0, "vang14k", "14K", 14.0, 1700000.0, 1.1499999999999999, "NEEME03414K", "P008.png", "Emerald Necklace NE-EME034-14K", 20, "Necklace", 12, 18.5, 0.0, 0.0 },
                    { "P009", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE043", "Emerald Cut Diamond", 0.0, "vang24k", "24K", 22.0, 2300000.0, 1.25, "NEDIA04318K", "P009.png", "Diamond Earrings NE-DIA043-24K", 18, "Earrings", 24, 27.0, 0.0, 0.0 },
                    { "P010", 0.0, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE003", "Thai Ruby", 0.0, "vang10k", "10K", 16.0, 1600000.0, 1.1000000000000001, "NERUB00310K", "P010.png", "Ruby Ring NE-RUB003-10K", 15, "Ring", 12, 20.0, 0.0, 0.0 },
                    { "P011", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE014", "Australian Sapphire", 0.0, "vang18k", "18K", 25.0, 2100000.0, 1.22, "NESAP01418K", "P011.png", "Sapphire Bracelet NE-SAP014-18K", 22, "Bracelet", 18, 30.0, 0.0, 0.0 },
                    { "P012", 0.0, new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 0.0, "vang24k", "24K", 35.0, 2700000.0, 1.3, "NEEME03124K", "P012.png", "Emerald Necklace NE-EME031-24K", 10, "Necklace", 24, 40.0, 0.0, 0.0 },
                    { "P013", 0.0, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE004", "India Ruby", 0.0, "vang14k", "14K", 16.0, 1800000.0, 1.1799999999999999, "NERUB00414K", "P013.png", "Ruby Earrings NE-RUB004-14K", 14, "Earrings", 12, 20.0, 0.0, 0.0 },
                    { "P014", 0.0, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE015", "Kashmir Sapphire", 0.0, "vang18k", "18K", 37.0, 2800000.0, 1.3500000000000001, "NESAP01518K", "P014.png", "Sapphire Necklace NE-SAP015-18K", 8, "Necklace", 24, 42.0, 0.0, 0.0 },
                    { "P015", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE044", "Oval Diamond", 0.0, "vang24k", "24K", 20.0, 2400000.0, 1.28, "NEDIA04414K", "P015.png", "Diamond Necklace NE-DIA044-24K", 16, "Necklace", 18, 24.0, 0.0, 0.0 },
                    { "P016", 0.0, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE035", "Russian Emerald", 0.0, "vang10k", "10K", 25.0, 1900000.0, 1.22, "NEEME03510K", "P016.png", "Emerald Bracelet NE-EME035-10K", 18, "Bracelet", 12, 30.0, 0.0, 0.0 },
                    { "P017", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE045", "Cushion Cut Diamond", 0.0, "vang24k", "24K", 30.0, 2900000.0, 1.3, "NEDIA04524K", "P017.png", "Diamond Bracelet NE-DIA045-24K", 12, "Bracelet", 36, 35.0, 0.0, 0.0 },
                    { "P018", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE032", "Zambian Emerald", 0.0, "vang18k", "18K", 17.0, 2300000.0, 1.25, "NEEME03218K", "P018.png", "Emerald Ring NE-EME032-18K", 15, "Ring", 24, 22.0, 0.0, 0.0 },
                    { "P019", 0.0, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE002", "Burmese Ruby", 0.0, "vang14k", "14K", 40.0, 2700000.0, 1.28, "NERUB00214K", "P019.png", "Ruby Necklace NE-RUB002-14K", 10, "Necklace", 24, 45.0, 0.0, 0.0 },
                    { "P020", 0.0, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 0.0, "vang10k", "10K", 16.0, 1600000.0, 1.1499999999999999, "NESAP01110K", "P020.png", "Sapphire Earrings NE-SAP011-10K", 20, "Earrings", 18, 20.0, 0.0, 0.0 },
                    { "P021", 0.0, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 0.0, "vang24k", "24K", 18.0, 2000000.0, 1.2, "NEEMA04114K", "P021.png", "Diamond Earrings NE-EMA041-24K", 18, "Earrings", 24, 22.0, 0.0, 0.0 },
                    { "P022", 0.0, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE049", "Pear Shaped Diamond", 1.3999999999999999, "vang24k", "24K", 3.0427947598991731, 12218864.894510968, 1.8840143924302741, "", "P022.png", "Pear Shaped Diamond Earrings", 12, "Earrings", 28, 4.8072378361217076, 0.0, 0.0 },
                    { "P023", 0.0, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE035", "Russian Emerald", 1.5, "vang18k", "18K", 3.397609558032495, 43235443.701126061, 1.5856625094225101, "674204419049", "P023.png", "Russian Emerald Ring", 15, "Ring", 35, 5.1487517928266318, 0.0, 0.0 },
                    { "P024", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 1.02, "vang10k", "10K", 3.7031008537293699, 20255374.450385179, 1.045675402349213, "862178701237", "P024.png", "Natural Ceylon Sapphire Earrings", 17, "Earrings", 18, 5.8259561300838563, 0.0, 0.0 },
                    { "P025", 0.0, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE042", "Princess Cut Diamond", 1.5, "vang10k", "10K", 3.4438763345857621, 6533141.6216132352, 2.9724477477624149, "428617280256", "P025.png", "Princess Cut Diamond Bracelet", 14, "Bracelet", 43, 5.285126368972044, 0.0, 0.0 },
                    { "P026", 0.0, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE048", "Radiant Cut Diamond", 1.1000000000000001, "vang24k", "24K", 8.5476521351442916, 8586437.9996748939, 1.7085622340187063, "670169156688", "P026.png", "Radiant Cut Diamond Earrings", 16, "Earrings", 16, 10.762794066397113, 0.0, 0.0 },
                    { "P027", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang10k", "10K", 3.2498160752384582, 1375258.8754988282, 1.59993305674788, "829988629120", "P027.png", "Colombian Emerald Earrings", 14, "Earrings", 19, 6.6180361329643729, 0.0, 0.0 },
                    { "P028", 0.0, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE020", "Padparadscha Sapphire", 1.0, "vang14k", "14K", 3.0781166668032323, 37289462.666079007, 2.6080432203782928, "633028312781", "P028.png", "Padparadscha Sapphire Ring", 7, "Ring", 20, 4.7494802867916093, 0.0, 0.0 },
                    { "P029", 0.0, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE030", "Garnet Cabochon", 3.0, "vang14k", "14K", 4.4987673409191018, 44583675.937731139, 1.0150129584628296, "730263125687", "P029.png", "Garnet Cabochon Necklace", 14, "Necklace", 25, 7.5145527391032436, 0.0, 0.0 },
                    { "P030", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE039", "Brazilian Emerald", 2.7000000000000002, "vang18k", "18K", 2.711575205296207, 2445534.0691606943, 1.1401401775578925, "901788122324", "P030.png", "Brazilian Emerald Necklace", 12, "Necklace", 15, 5.9787788892494573, 0.0, 0.0 },
                    { "P031", 0.0, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE036", "Synthetic Emerald", 3.0, "vang14k", "14K", 3.4989526307700163, 23573781.627794143, 2.7326722773575503, "870534791152", "P031.png", "Synthetic Emerald Bracelet", 12, "Bracelet", 46, 7.8996141108280602, 0.0, 0.0 },
                    { "P032", 0.0, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE049", "Pear Shaped Diamond", 1.3999999999999999, "vang10k", "10K", 7.8549700069851989, 30841391.562616978, 2.6984438757492146, "816946302009", "P032.png", "Pear Shaped Diamond Ring", 22, "Ring", 41, 9.3918793622172121, 0.0, 0.0 },
                    { "P033", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE033", "Brazilian Emerald", 1.8, "vang10k", "10K", 1.5895821041883988, 11699620.78143068, 1.004876605607548, "610464781825", "P033.png", "Brazilian Emerald Ring", 21, "Ring", 21, 5.0317236418602027, 0.0, 0.0 },
                    { "P034", 0.0, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE048", "Radiant Cut Diamond", 1.1000000000000001, "vang18k", "18K", 9.4084747676317875, 4180201.6651579402, 2.6536883297093854, "762407690611", "P034.png", "Radiant Cut Diamond Bracelet", 8, "Bracelet", 22, 11.992138786457193, 0.0, 0.0 },
                    { "P035", 0.0, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE044", "Oval Diamond", 1.2, "vang24k", "24K", 2.0726233200024078, 3572618.9548964691, 1.6047853756229071, "231569490190", "P035.png", "Oval Diamond Necklace", 16, "Necklace", 35, 6.176482890493749, 0.0, 0.0 },
                    { "P036", 0.0, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE039", "Brazilian Emerald", 2.7000000000000002, "vang10k", "10K", 8.9107279938249917, 39438265.041138254, 2.8969498751521985, "630624866041", "P036.png", "Brazilian Emerald Bracelet", 18, "Bracelet", 47, 14.04223322239628, 0.0, 0.0 },
                    { "P037", 0.0, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE021", "Moonstone Cabochon", 3.5, "vang10k", "10K", 7.6742829061817046, 19100700.2069338, 1.9103063365760704, "427057894494", "P037.png", "Moonstone Cabochon Bracelet", 13, "Bracelet", 39, 13.136524250093027, 0.0, 0.0 },
                    { "P038", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE017", "Thai Sapphire", 1.8, "vang24k", "24K", 1.4517318691161973, 25417389.084952321, 1.1076850835844394, "719461390533", "P038.png", "Thai Sapphire Necklace", 23, "Necklace", 29, 5.5597362550141352, 0.0, 0.0 },
                    { "P039", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE006", "Heated Natural Ruby", 0.34000000000000002, "vang24k", "24K", 3.6069865725694159, 26270393.562470425, 2.6640068376294783, "186487133888", "P039.png", "Heated Natural Ruby Ring", 24, "Ring", 18, 6.5136482136814644, 0.0, 0.0 },
                    { "P040", 0.0, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 1.02, "vang14k", "14K", 9.166335198076375, 18924204.050375704, 2.1763476154150325, "794088504470", "P040.png", "Natural Ceylon Sapphire Bracelet", 18, "Bracelet", 43, 11.748285931737238, 0.0, 0.0 },
                    { "P041", 0.0, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE022", "Opal Cabochon", 2.1000000000000001, "vang24k", "24K", 1.4518589504348511, 39783324.086961329, 1.3533459210371506, "660680543120", "P041.png", "Opal Cabochon Bracelet", 12, "Bracelet", 29, 5.7188124212483702, 0.0, 0.0 },
                    { "P042", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE039", "Brazilian Emerald", 2.7000000000000002, "vang18k", "18K", 1.2742085596804833, 31800804.722350467, 1.4945676533281764, "366177263281", "P042.png", "Brazilian Emerald Earrings", 21, "Earrings", 19, 4.1300382053166604, 0.0, 0.0 },
                    { "P043", 0.0, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 1.02, "vang18k", "18K", 4.7931436554959843, 21576589.514455389, 1.0517502056142054, "164695297436", "P043.png", "Natural Ceylon Sapphire Bracelet", 10, "Bracelet", 32, 5.822323224641309, 0.0, 0.0 },
                    { "P044", 0.0, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 1.0, "vang18k", "18K", 5.9144301009109927, 45688334.095289342, 2.7528004545662834, "466485346360", "P044.png", "Round Brilliant Diamond Necklace", 11, "Necklace", 15, 7.8327010529136505, 0.0, 0.0 },
                    { "P045", 0.0, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang14k", "14K", 5.1279976492402408, 3652522.4423296447, 1.8176659611941688, "383869345739", "P045.png", "Colombian Emerald Ring", 7, "Ring", 41, 6.8532138136079892, 0.0, 0.0 },
                    { "P046", 0.0, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE030", "Garnet Cabochon", 3.0, "vang18k", "18K", 6.5481548907944758, 7315325.6225724174, 2.6778426540134204, "231003630530", "P046.png", "Garnet Cabochon Ring", 6, "Ring", 38, 12.430393848269079, 0.0, 0.0 },
                    { "P047", 0.0, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE013", "Madagascar Sapphire", 1.5, "vang24k", "24K", 9.1350717759652618, 36773026.531728342, 2.1308457513069903, "949651291774", "P047.png", "Madagascar Sapphire Bracelet", 18, "Bracelet", 30, 10.638862761839402, 0.0, 0.0 },
                    { "P048", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE004", "India Ruby", 5.9100000000000001, "vang10k", "10K", 5.7112920563087908, 40130088.610135965, 2.9139016693393902, "197592618896", "P048.png", "India Ruby Necklace", 17, "Necklace", 31, 13.988171237491485, 0.0, 0.0 },
                    { "P049", 0.0, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE019", "Ethiopian Sapphire", 1.3, "vang18k", "18K", 6.9667322552426816, 27063957.402623728, 1.8406804973503976, "467794567861", "P049.png", "Ethiopian Sapphire Bracelet", 9, "Bracelet", 19, 8.3853743925279467, 0.0, 0.0 },
                    { "P050", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE014", "Australian Sapphire", 3.2000000000000002, "vang18k", "18K", 4.8415670016816001, 37693764.75196147, 1.1524591313630836, "838026328454", "P050.png", "Australian Sapphire Ring", 10, "Ring", 25, 8.5443841468456903, 0.0, 0.0 },
                    { "P051", 0.0, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE050", "Heart Shaped Diamond", 1.0, "vang24k", "24K", 1.3370469090329491, 44783583.40441224, 2.818804308589629, "596836381399", "P051.png", "Heart Shaped Diamond Necklace", 12, "Necklace", 22, 2.6356106557152472, 0.0, 0.0 },
                    { "P052", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE041", "Round Brilliant Diamond", 1.0, "vang18k", "18K", 1.7854832402627365, 18740482.320073944, 1.5343275103208867, "512360707805", "P052.png", "Round Brilliant Diamond Earrings", 20, "Earrings", 45, 5.7760728245347757, 0.0, 0.0 },
                    { "P053", 0.0, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE043", "Emerald Cut Diamond", 2.0, "vang24k", "24K", 1.6261364372426415, 38467110.619900107, 2.5737571486008322, "170516697530", "P053.png", "Emerald Cut Diamond Ring", 10, "Ring", 17, 3.7898083446080011, 0.0, 0.0 },
                    { "P054", 0.0, new DateTime(2024, 1, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE021", "Moonstone Cabochon", 3.5, "vang10k", "10K", 9.9355026202953312, 20285142.942025773, 1.7603008491551091, "814881347466", "P054.png", "Moonstone Cabochon Earrings", 8, "Earrings", 15, 15.754298331285687, 0.0, 0.0 },
                    { "P055", 0.0, new DateTime(2024, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE018", "Montana Sapphire", 0.71999999999999997, "vang10k", "10K", 8.6920669221133693, 22229931.668697417, 2.2033386258169805, "890509691739", "P055.png", "Montana Sapphire Necklace", 12, "Necklace", 27, 11.427962360843086, 0.0, 0.0 },
                    { "P056", 0.0, new DateTime(2024, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE044", "Oval Diamond", 1.2, "vang10k", "10K", 7.6271642229012775, 13235448.229500482, 1.010838790324708, "529134568958", "P056.png", "Oval Diamond Ring", 11, "Ring", 16, 9.2405207215731355, 0.0, 0.0 },
                    { "P057", 0.0, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE040", "Ethiopian Emerald", 1.3, "vang24k", "24K", 5.0236620676589121, 2290639.5334139392, 1.568168533711181, "171920122186", "P057.png", "Ethiopian Emerald Bracelet", 22, "Bracelet", 14, 6.6410874291153021, 0.0, 0.0 },
                    { "P058", 0.0, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE014", "Australian Sapphire", 3.2000000000000002, "vang24k", "24K", 2.1373953928147498, 35214561.045897558, 2.9760848672967848, "849475227946", "P058.png", "Australian Sapphire Earrings", 12, "Earrings", 16, 6.19172427226904, 0.0, 0.0 },
                    { "P059", 0.0, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE024", "Labradorite Cabochon", 5.0, "vang18k", "18K", 8.9547116847561803, 21302530.900030572, 1.8241638887332949, "383905492512", "P059.png", "Labradorite Cabochon Bracelet", 10, "Bracelet", 23, 14.430716366025056, 0.0, 0.0 },
                    { "P060", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE049", "Pear Shaped Diamond", 1.3999999999999999, "vang24k", "24K", 2.9613493454250701, 13184353.139635505, 1.4415493190934421, "875404298027", "P060.png", "Pear Shaped Diamond Necklace", 11, "Necklace", 30, 4.5761415534657655, 0.0, 0.0 },
                    { "P061", 0.0, new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE001", "Natural Mozambique Ruby", 0.97999999999999998, "vang18k", "18K", 5.0964341658111598, 28780291.704716213, 2.5408466176827234, "474280836261", "P061.png", "Natural Mozambique Ruby Ring", 23, "Ring", 16, 7.5435725625713692, 0.0, 0.0 },
                    { "P062", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang18k", "18K", 2.1833268375472161, 22541225.68969354, 2.6526516000486389, "997655504675", "P062.png", "Colombian Emerald Necklace", 22, "Necklace", 13, 6.2762189716804055, 0.0, 0.0 },
                    { "P063", 0.0, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang18k", "18K", 7.8690873654790092, 4803614.9889506493, 1.4783200469191291, "132820434702", "P063.png", "Colombian Emerald Bracelet", 24, "Bracelet", 14, 9.3747581691066024, 0.0, 0.0 },
                    { "P064", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE035", "Russian Emerald", 1.5, "vang10k", "10K", 1.9503276588997664, 11322111.743710199, 2.9648315748663912, "223652976341", "P064.png", "Russian Emerald Necklace", 14, "Necklace", 27, 5.3915833885971871, 0.0, 0.0 },
                    { "P065", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE022", "Opal Cabochon", 2.1000000000000001, "vang14k", "14K", 7.3328638769437671, 48052995.225846723, 2.0854551419359146, "134535776319", "P065.png", "Opal Cabochon Bracelet", 14, "Bracelet", 47, 9.7483448449973622, 0.0, 0.0 },
                    { "P066", 0.0, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE026", "Cat's Eye Chrysoberyl Cabochon", 2.5, "vang18k", "18K", 8.0880597241821484, 4178216.465776931, 1.0561345131368729, "282821916462", "P066.png", "Cat's Eye Chrysoberyl Cabochon Earrings", 15, "Earrings", 32, 12.495811598649325, 0.0, 0.0 },
                    { "P067", 0.0, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE028", "Lapis Lazuli Cabochon", 7.5, "vang14k", "14K", 3.2511990910559962, 45521277.525136769, 2.1148330811040097, "736198789615", "P067.png", "Lapis Lazuli Cabochon Ring", 5, "Ring", 16, 10.94677041286857, 0.0, 0.0 },
                    { "P068", 0.0, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE017", "Thai Sapphire", 1.8, "vang18k", "18K", 9.0160205280884096, 49663585.427000947, 1.4553703825497204, "652141365560", "P068.png", "Thai Sapphire Earrings", 23, "Earrings", 42, 13.642886882573031, 0.0, 0.0 },
                    { "P069", 0.0, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang24k", "24K", 7.0020717493306472, 2958963.6531875115, 2.0070032319070266, "869018111056", "P069.png", "Colombian Emerald Ring", 20, "Ring", 23, 9.3955396669381415, 0.0, 0.0 },
                    { "P070", 0.0, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE011", "Natural Ceylon Sapphire", 1.02, "vang14k", "14K", 2.7790679761061821, 13212584.193749525, 2.1474341245059181, "360314486545", "P070.png", "Natural Ceylon Sapphire Bracelet", 12, "Bracelet", 14, 5.1939316845560599, 0.0, 0.0 },
                    { "P071", 0.0, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE028", "Lapis Lazuli Cabochon", 7.5, "vang24k", "24K", 4.7503978016786474, 35179269.036827415, 1.5106439551370094, "973237878653", "P071.png", "Lapis Lazuli Cabochon Earrings", 17, "Earrings", 32, 12.861498155646276, 0.0, 0.0 },
                    { "P072", 0.0, new DateTime(2024, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE001", "Natural Mozambique Ruby", 0.97999999999999998, "vang14k", "14K", 5.6046179311436344, 7925490.2645036774, 1.4292663110662522, "416465740045", "P072.png", "Natural Mozambique Ruby Necklace", 13, "Necklace", 28, 8.8939635934102323, 0.0, 0.0 },
                    { "P073", 0.0, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE034", "Afghan Emerald", 2.2000000000000002, "vang10k", "10K", 5.7121034800410904, 28689999.243368484, 1.7249882691674601, "905642139964", "P073.png", "Afghan Emerald Necklace", 20, "Necklace", 43, 8.7256562246592573, 0.0, 0.0 },
                    { "P074", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE031", "Colombian Emerald", 1.2, "vang10k", "10K", 7.8017670967492414, 33418437.651721679, 1.0262643392773481, "518675440124", "P074.png", "Colombian Emerald Ring", 5, "Ring", 20, 11.115736636314629, 0.0, 0.0 },
                    { "P075", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE027", "Jade Cabochon", 6.7999999999999998, "vang10k", "10K", 9.5105342119102119, 19873671.941997729, 2.7746569220624755, "883107591713", "P075.png", "Jade Cabochon Earrings", 7, "Earrings", 38, 17.327096643258589, 0.0, 0.0 },
                    { "P076", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE027", "Jade Cabochon", 6.7999999999999998, "vang24k", "24K", 5.0850553137715719, 16554494.020607131, 1.711876058221355, "285490561092", "P076.png", "Jade Cabochon Necklace", 13, "Necklace", 27, 12.189626989427303, 0.0, 0.0 },
                    { "P077", 0.0, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE006", "Heated Natural Ruby", 0.34000000000000002, "vang18k", "18K", 4.8220018319153937, 9726902.5970138386, 2.5867224320072006, "810850684545", "P077.png", "Heated Natural Ruby Necklace", 10, "Necklace", 30, 6.0616339539171662, 0.0, 0.0 },
                    { "P078", 0.0, new DateTime(2024, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE016", "Heated Natural Sapphire", 2.1000000000000001, "vang18k", "18K", 8.3681424148649342, 40912458.290988036, 1.5921443127414832, "123256896894", "P078.png", "Heated Natural Sapphire Necklace", 12, "Necklace", 31, 11.121893409395742, 0.0, 0.0 },
                    { "P079", 0.0, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE019", "Ethiopian Sapphire", 1.3, "vang24k", "24K", 6.0560348589837201, 4194023.0041391337, 1.001408411053442, "387439802850", "P079.png", "Ethiopian Sapphire Necklace", 13, "Necklace", 12, 10.061922050371816, 0.0, 0.0 },
                    { "P080", 0.0, new DateTime(2024, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE005", "Mozambique Ruby", 0.33000000000000002, "vang18k", "18K", 1.470998773475916, 10721397.801540006, 1.1317351319358644, "255717953045", "P080.png", "Mozambique Ruby Bracelet", 9, "Bracelet", 21, 1.8268978794962705, 0.0, 0.0 },
                    { "P081", 0.0, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE038", "Colombian Emerald", 0.90000000000000002, "vang14k", "14K", 6.1122190563446885, 45645441.276931733, 1.5788510456637512, "739592453907", "P081.png", "Colombian Emerald Bracelet", 14, "Bracelet", 38, 8.345755921584324, 0.0, 0.0 },
                    { "P082", 0.0, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE008", "Mozambique Ruby (Heated)", 0.48999999999999999, "vang14k", "14K", 8.3685855562191893, 14180127.36439872, 2.1139432088655075, "554417345981", "P082.png", "Mozambique Ruby (Heated) Bracelet", 17, "Bracelet", 33, 9.8541619627186723, 0.0, 0.0 },
                    { "P083", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE014", "Australian Sapphire", 3.2000000000000002, "vang14k", "14K", 1.8754761710121342, 31622697.745569754, 2.3430281274260949, "378892611670", "P083.png", "Australian Sapphire Necklace", 22, "Necklace", 18, 7.2884837215129572, 0.0, 0.0 },
                    { "P084", 0.0, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE021", "Moonstone Cabochon", 3.5, "vang14k", "14K", 9.3623495242815196, 16563472.75871514, 1.0399685928834637, "895541535083", "P084.png", "Moonstone Cabochon Ring", 17, "Ring", 37, 14.231060675176391, 0.0, 0.0 },
                    { "P085", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE033", "Brazilian Emerald", 1.8, "vang24k", "24K", 7.8841570298546673, 27675466.14092264, 2.1938325138235886, "683840289612", "P085.png", "Brazilian Emerald Necklace", 10, "Necklace", 22, 11.310927651708962, 0.0, 0.0 },
                    { "P086", 0.0, new DateTime(2024, 1, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE032", "Zambian Emerald", 2.5, "vang14k", "14K", 2.7482666505600251, 15154325.736343848, 1.6851489741219896, "855506970606", "P086.png", "Zambian Emerald Ring", 8, "Ring", 15, 8.0031120785753149, 0.0, 0.0 },
                    { "P087", 0.0, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE035", "Russian Emerald", 1.5, "vang18k", "18K", 1.4853638811329359, 42822876.531945735, 1.9282511939714539, "698883680113", "P087.png", "Russian Emerald Ring", 24, "Ring", 33, 4.9611045887676823, 0.0, 0.0 },
                    { "P088", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE025", "Star Sapphire Cabochon", 3.2000000000000002, "vang10k", "10K", 2.2413237529785395, 3063576.5542223216, 2.2545791946922975, "537897479809", "P088.png", "Star Sapphire Cabochon Necklace", 16, "Necklace", 17, 8.1617748979889591, 0.0, 0.0 },
                    { "P089", 0.0, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE005", "Mozambique Ruby", 0.33000000000000002, "vang18k", "18K", 4.5173023710675118, 20354729.054825481, 2.833644193886045, "157125451128", "P089.png", "Mozambique Ruby Necklace", 11, "Necklace", 14, 7.7083585135297916, 0.0, 0.0 },
                    { "P090", 0.0, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE046", "Asscher Cut Diamond", 1.3, "vang10k", "10K", 2.0689658540162821, 25064114.060412843, 1.5813632694189736, "300830776654", "P090.png", "Asscher Cut Diamond Necklace", 24, "Necklace", 38, 6.3100550604794536, 0.0, 0.0 },
                    { "P091", 0.0, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE022", "Opal Cabochon", 2.1000000000000001, "vang10k", "10K", 2.3224759493616145, 34825371.455560803, 2.2396282540551438, "773834750665", "P091.png", "Opal Cabochon Bracelet", 7, "Bracelet", 20, 5.2230354313027005, 0.0, 0.0 },
                    { "P092", 0.0, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE009", "Mozambique Ruby", 0.48999999999999999, "vang24k", "24K", 3.5622533490032104, 8578941.7910587341, 2.382340498189611, "298516339018", "P092.png", "Mozambique Ruby Ring", 9, "Ring", 27, 5.6941004842404901, 0.0, 0.0 },
                    { "P093", 0.0, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE040", "Ethiopian Emerald", 1.3, "vang14k", "14K", 2.6806493651067336, 42270085.522961698, 1.2731079633387989, "792674934158", "P093.png", "Ethiopian Emerald Bracelet", 5, "Bracelet", 35, 5.4234697813875847, 0.0, 0.0 },
                    { "P094", 0.0, new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE044", "Oval Diamond", 1.2, "vang24k", "24K", 9.2253807240819956, 38039309.398583248, 1.7553388224754771, "775223714850", "P094.png", "Oval Diamond Bracelet", 10, "Bracelet", 33, 12.530601570954346, 0.0, 0.0 },
                    { "P095", 0.0, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE030", "Garnet Cabochon", 3.0, "vang24k", "24K", 4.2444716481162743, 43984746.533329844, 2.0936609871436485, "289398842985", "P095.png", "Garnet Cabochon Ring", 20, "Ring", 38, 7.9596724849241971, 0.0, 0.0 },
                    { "P096", 0.0, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE021", "Moonstone Cabochon", 3.5, "vang14k", "14K", 4.5387696389747232, 34699113.981977336, 2.0783819312115486, "346196169746", "P096.png", "Moonstone Cabochon Bracelet", 24, "Bracelet", 12, 9.6147137013852149, 0.0, 0.0 },
                    { "P097", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE030", "Garnet Cabochon", 3.0, "vang14k", "14K", 1.8079704872461873, 6343166.36201734, 2.0305332291768714, "729722262028", "P097.png", "Garnet Cabochon Necklace", 7, "Necklace", 22, 5.4744477214319165, 0.0, 0.0 },
                    { "P098", 0.0, new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE038", "Colombian Emerald", 0.90000000000000002, "vang18k", "18K", 9.5980533515403028, 35858379.55481039, 2.5880326005739667, "894208493653", "P098.png", "Colombian Emerald Bracelet", 22, "Bracelet", 18, 11.881774016516705, 0.0, 0.0 },
                    { "P099", 0.0, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE028", "Lapis Lazuli Cabochon", 7.5, "vang18k", "18K", 8.8995553242924714, 18372770.988842566, 2.2003199138665521, "975718722237", "P099.png", "Lapis Lazuli Cabochon Ring", 22, "Ring", 45, 17.005635105397129, 0.0, 0.0 },
                    { "P100", 0.0, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "GE007", "Mozambique Ruby", 0.35999999999999999, "vang14k", "14K", 1.0876427465645859, 26908960.946195457, 1.6931379646437632, "186329661165", "P100.png", "Mozambique Ruby Earrings", 6, "Earrings", 29, 1.8772857207332527, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "StallEmployees",
                columns: new[] { "StallEmployeeId", "EmployeeFullname", "EmployeeId", "Role", "StallId", "StallName" },
                values: new object[,]
                {
                    { "SE0010", "Sophia Wilson", "US10", "Sale", "ST01", "Sky Treasure" },
                    { "SE007", "Luna Taylor", "US07", "Cashier", "ST01", "Sky Treasure" },
                    { "SE008", "Emma Young", "US08", "Sale", "ST01", "Sky Treasure" },
                    { "SE009", "Ava Davis", "US09", "Sale", "ST01", "Sky Treasure" },
                    { "SE011", "Charlotte Brown", "US11", "Cashier", "ST02", "Delights" },
                    { "SE012", "Amelia Jones", "US12", "Sale", "ST02", "Delights" },
                    { "SE013", "Mia Anderson", "US13", "Sale", "ST02", "Delights" },
                    { "SE014", "Harper Thomas", "US14", "Sale", "ST02", "Delights" },
                    { "SE015", "Evelyn White", "US15", "Cashier", "ST03", "The Vintage" },
                    { "SE016", "Abigail Harris", "US16", "Sale", "ST03", "The Vintage" },
                    { "SE017", "Ella Clark", "US17", "Sale", "ST03", "The Vintage" },
                    { "SE018", "Avery Lewis", "US18", "Sale", "ST03", "The Vintage" },
                    { "SE019", "Julius Caesar", "US19", "Cashier", "ST04", "The Charm" },
                    { "SE020", "Charles De Quin", "US20", "Sale", "ST04", "The Charm" },
                    { "SE021", "Victoria Sylvanas", "US21", "Sale", "ST04", "The Charm" },
                    { "SE022", "Albert Brown", "US22", "Sale", "ST04", "The Charm" }
                });

            migrationBuilder.InsertData(
                table: "StallItems",
                columns: new[] { "StallItemId", "ProductId", "ProductName", "StallId", "quantity" },
                values: new object[,]
                {
                    { "SI001", "P001", "Ruby Necklace NE-R1-24K", "ST01", 10 },
                    { "SI0010", "P010", "Ruby Ring NE-RUB003-10K", "ST01", 15 },
                    { "SI002", "P002", "Sapphire Necklace NE-S2-14K", "ST01", 15 },
                    { "SI003", "P003", "Emerald Earrings NE-EME033-18K", "ST01", 25 },
                    { "SI004", "P004", "Diamond Ring NE-DIA041-24K", "ST01", 30 },
                    { "SI005", "P005", "Ruby Bracelet NE-RUB005-10K", "ST01", 20 },
                    { "SI006", "P006", "Diamond Necklace NE-EMA046-24K", "ST01", 10 },
                    { "SI007", "P007", "Sapphire Ring NE-SAP013-24K", "ST01", 12 },
                    { "SI008", "P008", "Emerald Necklace NE-EME034-14K", "ST01", 20 },
                    { "SI009", "P009", "Diamond Earrings NE-DIA043-24K", "ST01", 18 },
                    { "SI011", "P100", "Mozambique Ruby Earrings", "ST01", 6 },
                    { "SI012", "P011", "Sapphire Bracelet NE-SAP014-18K", "ST01", 22 },
                    { "SI013", "P012", "Emerald Necklace NE-EME031-24K", "ST01", 10 },
                    { "SI014", "P013", "Ruby Earrings NE-RUB004-14K", "ST01", 14 },
                    { "SI015", "P014", "Sapphire Necklace NE-SAP015-18K", "ST01", 8 },
                    { "SI016", "P015", "Diamond Necklace NE-DIA044-24K", "ST01", 16 },
                    { "SI017", "P016", "Emerald Bracelet NE-EME035-10K", "ST01", 18 },
                    { "SI018", "P017", "Diamond Bracelet NE-DIA045-24K", "ST01", 12 },
                    { "SI019", "P018", "Emerald Ring NE-EME032-18K", "ST01", 15 },
                    { "SI020", "P019", "Ruby Necklace NE-RUB002-14K", "ST01", 10 },
                    { "SI021", "P020", "Sapphire Earrings NE-SAP011-10K", "ST01", 20 },
                    { "SI022", "P021", "Diamond Earrings NE-EMA041-24K", "ST01", 18 },
                    { "SI023", "P022", "Pear Shaped Diamond Earrings", "ST01", 12 },
                    { "SI024", "P023", "Russian Emerald Ring", "ST01", 15 },
                    { "SI025", "P024", "Natural Ceylon Sapphire Earrings", "ST01", 16 },
                    { "SI026", "P025", "Princess Cut Diamond Bracelet", "ST02", 14 },
                    { "SI027", "P026", "Radiant Cut Diamond Earrings", "ST02", 16 },
                    { "SI028", "P027", "Colombian Emerald Earrings", "ST02", 13 },
                    { "SI029", "P028", "Padparadscha Sapphire Ring", "ST02", 7 },
                    { "SI030", "P029", "Garnet Cabochon Necklace", "ST02", 14 },
                    { "SI031", "P030", "Brazilian Emerald Necklace", "ST02", 12 },
                    { "SI032", "P031", "Synthetic Emerald Bracelet", "ST02", 12 },
                    { "SI033", "P032", "Pear Shaped Diamond Ring", "ST02", 22 },
                    { "SI034", "P033", "Brazilian Emerald Ring", "ST02", 21 },
                    { "SI035", "P034", "Radiant Cut Diamond Bracelet", "ST02", 8 },
                    { "SI036", "P035", "Oval Diamond Necklace", "ST02", 16 },
                    { "SI037", "P036", "Brazilian Emerald Bracelet", "ST02", 18 },
                    { "SI038", "P037", "Moonstone Cabochon Bracelet", "ST02", 13 },
                    { "SI039", "P038", "Thai Sapphire Necklace", "ST02", 23 },
                    { "SI040", "P039", "Heated Natural Ruby Ring", "ST02", 24 },
                    { "SI041", "P040", "Natural Ceylon Sapphire Bracelet", "ST02", 18 },
                    { "SI042", "P041", "Opal Cabochon Bracelet", "ST02", 12 },
                    { "SI043", "P042", "Brazilian Emerald Earrings", "ST02", 21 },
                    { "SI044", "P043", "Natural Ceylon Sapphire Bracelet", "ST02", 10 },
                    { "SI045", "P044", "Round Brilliant Diamond Necklace", "ST02", 11 },
                    { "SI046", "P045", "Colombian Emerald Ring", "ST02", 7 },
                    { "SI047", "P046", "Garnet Cabochon Ring", "ST02", 6 },
                    { "SI048", "P047", "Madagascar Sapphire Bracelet", "ST02", 18 },
                    { "SI049", "P048", "India Ruby Necklace", "ST02", 17 },
                    { "SI050", "P049", "Ethiopian Sapphire Bracelet", "ST02", 9 },
                    { "SI051", "P050", "Australian Sapphire Ring", "ST03", 10 },
                    { "SI052", "P051", "Heart Shaped Diamond Necklace", "ST03", 12 },
                    { "SI053", "P052", "Round Brilliant Diamond Earrings", "ST03", 20 },
                    { "SI054", "P053", "Emerald Cut Diamond Ring", "ST03", 10 },
                    { "SI055", "P054", "Moonstone Cabochon Earrings", "ST03", 8 },
                    { "SI056", "P055", "Montana Sapphire Necklace", "ST03", 12 },
                    { "SI057", "P056", "Oval Diamond Ring", "ST03", 11 },
                    { "SI058", "P057", "Ethiopian Emerald Bracelet", "ST03", 22 },
                    { "SI059", "P058", "Australian Sapphire Earrings", "ST03", 12 },
                    { "SI060", "P059", "Labradorite Cabochon Bracelet", "ST03", 10 },
                    { "SI061", "P060", "Pear Shaped Diamond Necklace", "ST03", 11 },
                    { "SI062", "P061", "Natural Mozambique Ruby Ring", "ST03", 23 },
                    { "SI063", "P062", "Colombian Emerald Necklace", "ST03", 22 },
                    { "SI064", "P063", "Colombian Emerald Bracelet", "ST03", 24 },
                    { "SI065", "P064", "Russian Emerald Necklace", "ST03", 14 },
                    { "SI066", "P065", "Opal Cabochon Bracelet", "ST03", 14 },
                    { "SI067", "P066", "Cat's Eye Chrysoberyl Cabochon Earrings", "ST03", 15 },
                    { "SI068", "P067", "Lapis Lazuli Cabochon Ring", "ST03", 5 },
                    { "SI069", "P068", "Thai Sapphire Earrings", "ST03", 23 },
                    { "SI070", "P069", "Colombian Emerald Ring", "ST03", 20 },
                    { "SI071", "P070", "Natural Ceylon Sapphire Bracelet", "ST03", 12 },
                    { "SI072", "P071", "Lapis Lazuli Cabochon Earrings", "ST03", 17 },
                    { "SI073", "P072", "Natural Mozambique Ruby Necklace", "ST03", 13 },
                    { "SI074", "P073", "Afghan Emerald Necklace", "ST03", 20 },
                    { "SI075", "P074", "Colombian Emerald Ring", "ST03", 5 },
                    { "SI076", "P075", "Jade Cabochon Earrings", "ST04", 7 },
                    { "SI077", "P076", "Jade Cabochon Necklace", "ST04", 13 },
                    { "SI078", "P077", "Heated Natural Ruby Necklace", "ST04", 10 },
                    { "SI079", "P078", "Heated Natural Sapphire Necklace", "ST04", 12 },
                    { "SI080", "P079", "Ethiopian Sapphire Necklace", "ST04", 13 },
                    { "SI081", "P080", "Mozambique Ruby Bracelet", "ST04", 9 },
                    { "SI082", "P081", "Colombian Emerald Bracelet", "ST04", 14 },
                    { "SI083", "P082", "Mozambique Ruby (Heated) Bracelet", "ST04", 17 },
                    { "SI084", "P083", "Australian Sapphire Necklace", "ST04", 22 },
                    { "SI085", "P084", "Moonstone Cabochon Ring", "ST04", 17 },
                    { "SI086", "P085", "Brazilian Emerald Necklace", "ST04", 10 },
                    { "SI087", "P086", "Zambian Emerald Ring", "ST04", 8 },
                    { "SI088", "P087", "Russian Emerald Ring", "ST04", 24 },
                    { "SI089", "P088", "Star Sapphire Cabochon Necklace", "ST04", 16 },
                    { "SI090", "P089", "Mozambique Ruby Necklace", "ST04", 11 },
                    { "SI091", "P090", "Asscher Cut Diamond Necklace", "ST04", 24 },
                    { "SI092", "P091", "Opal Cabochon Bracelet", "ST04", 7 },
                    { "SI093", "P092", "Mozambique Ruby Ring", "ST04", 9 },
                    { "SI094", "P093", "Ethiopian Emerald Bracelet", "ST04", 5 },
                    { "SI095", "P094", "Oval Diamond Bracelet", "ST04", 10 },
                    { "SI096", "P095", "Garnet Cabochon Ring", "ST04", 20 },
                    { "SI097", "P096", "Moonstone Cabochon Bracelet", "ST04", 24 },
                    { "SI098", "P097", "Garnet Cabochon Necklace", "ST04", 7 },
                    { "SI099", "P098", "Colombian Emerald Bracelet", "ST04", 22 },
                    { "SI100", "P099", "Lapis Lazuli Cabochon Ring", "ST04", 22 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "StallId", "StaffName", "StallDescription", "StallName", "StallType", "UserId" },
                values: new object[,]
                {
                    { "ST01", "Olivia Miller", "Opening", "Sky Treasure", "Diversity", "US2" },
                    { "ST02", "Olivia Miller", "Opening", "Delights", "Diversity", "US2" },
                    { "ST03", "Olivia Miller", "Opening", "The Vintage", "Diversity", "US2" },
                    { "ST04", "Olivia Miller", "Maintenance", "The Charm", "Diversity", "US2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "US01", "liam@gmail.com", "Liam Williams", "$2a$11$v/XJ4Ps3lsiSAlZpi.T4wuD0DxZ3cHLn0cdQOPNlyFtqlMGw8k1T2", "Admin", "user1" },
                    { "US02", "olivia@gmail.com", "Olivia Miller", "$2a$11$mRRvXKGSTRm24n9UAG0lEusg8SAkhDBF1dsp.0eyPPWIk..7NVSLC", "Admin", "user2" },
                    { "US03", "james@gmail.com", "James Martinez", "$2a$11$k9WEU0g9.XsXUXO1Rk4EqeafEneiU.qSqv1kJ4YmH4KHrFk.GsUO2", "Manager", "user3" },
                    { "US04", "matao@gmail.com", "Mateo Martinez", "$2a$11$GVN2QejAKB6rhB/Aob0pKu9G9GBX2FmLWCgJcoSThcuM4YJV3dZoC", "Manager", "user4" },
                    { "US05", "theodore@gmail.com", "Theodore Garcia", "$2a$11$FvfFLBB1/XhfsJk0JclVuutxpPRdr3Xn5ebqQV3jBPHZcULy28Fw6", "Manager", "user5" },
                    { "US06", "isabel@gmail.com", "Isabel Rodriguez", "$2a$11$kQA1EZRws.bW88KVADHADeAaEKR6FfJbF.dv5dvEHnLILleNQ51xC", "Manager", "user6" },
                    { "US07", "luna@gmail.com", "Luna Taylor", "$2a$11$70Ml2QKZ2zo7Ki4KBzVHEuzTCktXYt1enHOcTi.EEiiMofUytRri2", "Cashier", "user7" },
                    { "US08", "emma@gmail.com", "Emma Young", "$2a$11$n/fpCThW5vcCWDp.nnSo7egzr4FBfFuEDBdigpw3ByFsTuyczrBcK", "Sale", "user8" },
                    { "US09", "ava@gmail.com", "Ava Davis", "$2a$11$Ilx9TloXL4Ezv5VY.PBAEuo0lbBPmBjTE/z6O5vrTLA660fw9AL6y", "Sale", "user9" },
                    { "US10", "sophia@gmail.com", "Sophia Wilson", "$2a$11$mFqi2QV8Hgk9nGZO6nuJBOdjKhGmzxp618K/84vTrU5rXcNAdrvCa", "Sale", "user10" },
                    { "US11", "charlotte@gmail.com", "Charlotte Brown", "$2a$11$JrVUBZ/pG4RROMjvVULcPOBGZr7SH0F.PbKS8ibKcZMRFQy96WJNm", "Cashier", "user11" },
                    { "US12", "amelia@gmail.com", "Amelia Jones", "$2a$11$OxRUJphbBmTu5ReqheabiOqnR9uGk9ebrIC2Qsb90/XI7PQwkWdBC", "Sale", "user12" },
                    { "US13", "mia@gmail.com", "Mia Anderson", "$2a$11$206MXQA4dLfS/SMJNNUOOuckCOl6gFteqbFcefIuy/JPlKuv.YiBi", "Sale", "user13" },
                    { "US14", "harper@gmail.com", "Harper Thomas", "$2a$11$OdcBW5/rBlJfC1eF.z6FYOE/z16dGIOtQSB7gQJ1tIeilB9rbJEpe", "Sale", "user14" },
                    { "US15", "evelyn@gmail.com", "Evelyn White", "$2a$11$l./UHlY1R6xw1GkqQiLcaOm/ptMwqoMIqQopAZVvwcg0j0M/zQfF2", "Cashier", "user15" },
                    { "US16", "abigail@gmail.com", "Abigail Harris", "$2a$11$yBpSsj81M/G6qnFKkHdXGOdLO4W1.VaPiOeVKFQrfVitoNhRQ7F1S", "Sale", "user16" },
                    { "US17", "ella@gmail.com", "Ella Clark", "$2a$11$udU92eNjDgPj2tMKG//fWeXBtpOuxYM/xcLZGfKzFQ/ylcItCi/v6", "Sale", "user17" },
                    { "US18", "avery@gmail.com", "Avery Lewis", "$2a$11$Tnd6RUiuKdDIbLRkdApPy.FYuPynMaU9fk0Co1MQiZc26WkA5Y12.", "Sale", "user18" },
                    { "US19", "julius@gmail.com", "Julius Caesar", "$2a$11$yiHz5LhQxJqbaA1kVDCsP.kaIezY095Kvsm6l2CpfS76QNk52r71i", "Cashier", "user19" },
                    { "US20", "charles@gmail.com", "Charles De Quin", "$2a$11$fzIF8iOI8LVpxZvAHdf8CuSKNIhHqbgNWt8lbpKYWBzFV8Wr/CiC2", "Sale", "user20" },
                    { "US21", "sylvanas@gmail.com", "Victoria Sylvanas", "$2a$11$MhnDvErPqr4sc1BXvieut.lW5S0MetMlHebkYJKCJaO6nNepmAp3a", "Sale", "user21" },
                    { "US22", "albert@gmail.com", "Albert Brown", "$2a$11$1/uKam5TBrvIvfqKhTOL2eChKZd0lvca0BHOCCO8c7jhvkO6tziBa", "Sale", "user22" }
                });

            migrationBuilder.InsertData(
                table: "Warranties",
                columns: new[] { "WarrantyId", "ExpireDate", "ProductId", "ProductName", "StartDate" },
                values: new object[,]
                {
                    { "W1", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P015", "Diamond Necklace NE-DIA044-24K", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W10", new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P021", "Diamond Earrings NE-EMA041-24K", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W11", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P016", "Emerald Bracelet NE-EME035-10K", new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W12", new DateTime(2025, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P011", "Sapphire Bracelet NE-SAP014-18K", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W13", new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P018", "Emerald Ring NE-EME032-18K", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W14", new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P013", "Ruby Earrings NE-RUB004-14K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W15", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P014", "Sapphire Necklace NE-SAP015-18K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W16", new DateTime(2025, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P015", "Diamond Necklace NE-DIA044-24K", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W17", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P019", "Ruby Necklace NE-RUB002-14K", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W18", new DateTime(2027, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P017", "Diamond Bracelet NE-DIA045-24K", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W19", new DateTime(2026, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "P012", "Emerald Necklace NE-EME031-24K", new DateTime(2024, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W2", new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P021", "Diamond Earrings NE-EMA041-24K", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W20", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "P011", "Sapphire Bracelet NE-SAP014-18K", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W21", new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "P020", "Sapphire Earrings NE-SAP011-10K", new DateTime(2024, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W22", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P014", "Sapphire Necklace NE-SAP015-18K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W23", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P021", "Diamond Earrings NE-EMA041-24K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W3", new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "P005", "Ruby Bracelet NE-RUB005-10K", new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W4", new DateTime(2025, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "P010", "Ruby Ring NE-RUB003-10K", new DateTime(2024, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W5", new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", "Emerald Earrings NE-EME033-18K", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W6", new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P018", "Emerald Ring NE-EME032-18K", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W7", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P011", "Sapphire Bracelet NE-SAP014-18K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W8", new DateTime(2025, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P020", "Sapphire Earrings NE-SAP011-10K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W9", new DateTime(2026, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "P003", "Emerald Earrings NE-EME033-18K", new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Gems");

            migrationBuilder.DropTable(
                name: "Golds");

            migrationBuilder.DropTable(
                name: "ImageRecords");

            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Jewels");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StallEmployees");

            migrationBuilder.DropTable(
                name: "StallItems");

            migrationBuilder.DropTable(
                name: "Stalls");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Warranties");
        }
    }
}
