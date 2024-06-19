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
                    gem_price = table.Column<double>(type: "float", nullable: false)
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
                    gold_price = table.Column<double>(type: "float", nullable: false)
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
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    gem_weight = table.Column<double>(type: "float", nullable: false),
                    gold_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gold_weight = table.Column<double>(type: "float", nullable: false),
                    labor_cost = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
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
                    StaffId = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    { "396ca43f-a2e2-4af7-98fb-2b9a8a8f6713", "Some Product Id", "Some Product Name", 0 },
                    { "973513ac-48e5-4ba3-bf1e-f933c2f34ee9", "Some Product Id", "Some Product Name", 0 },
                    { "bbe79acf-7b9d-45fa-929d-8c831de96e24", "Some Product Id", "Some Product Name", 0 },
                    { "bdadf08a-aa9e-4b66-9585-89c42eca533a", "Some Product Id", "Some Product Name", 0 },
                    { "db50bdb2-ffa8-492a-8a14-ee5cdfe6b456", "Some Product Id", "Some Product Name", 0 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "StallId", "StaffId", "StallDescription", "StallName", "StallType" },
                values: new object[,]
                {
                    { "9d2659bb-c394-437c-9e56-4437ea188134", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "9f7a668d-bd45-4341-8f8f-12338cee2917", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "a03ff6d8-56a7-492e-a837-25c52a65a6cf", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "be59c5f9-c33e-4f7d-a833-b14e94b6c7f2", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "d710c963-28ff-427a-abe6-933bc63b00b7", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" }
                });

            migrationBuilder.InsertData(
                table: "customer",
                columns: new[] { "customer_id", "attend_date", "customer_name", "customer_point", "customer_rank" },
                values: new object[,]
                {
                    { "C1", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "John Doe", 100, "Gold" },
                    { "C2", new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane Smith", 80, "Silver" },
                    { "C3", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alice Johnson", 50, "Bronze" },
                    { "C4", new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob Brown", 120, "Bronze" },
                    { "C5", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily Wilson", 90, "Bronze" }
                });

            migrationBuilder.InsertData(
                table: "discount",
                columns: new[] { "DiscountId", "DiscountName", "DiscountRate", "ExpireDate", "OrderType", "ProductId", "ProductType", "PublicDate" },
                values: new object[,]
                {
                    { "1", "Summer Sale", 0.20000000000000001, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 1", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2", "Holiday Promotion", 0.29999999999999999, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 2", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3", "Spring Clearance", 0.40000000000000002, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buyback", "All", "Jewelry 3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4", "Back-to-School Sale", 0.5, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 4", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5", "Winter Warm-up", 0.0, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buyback", "All", "Jewelry 5", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "gem",
                columns: new[] { "gem_id", "gem_name", "gem_price" },
                values: new object[,]
                {
                    { "1", "Ruby", 1000.0 },
                    { "2", "Sapphire", 1500.0 },
                    { "3", "Emerald", 1200.0 },
                    { "4", "Diamond", 5000.0 },
                    { "5", "Topaz", 800.0 }
                });

            migrationBuilder.InsertData(
                table: "gold",
                columns: new[] { "gold_id", "gold_name", "gold_price" },
                values: new object[,]
                {
                    { "1", "24K Gold", 6000.0 },
                    { "2", "22K Gold", 5500.0 },
                    { "3", "18K Gold", 4500.0 },
                    { "4", "14K Gold", 4000.0 },
                    { "5", "10K Gold", 3500.0 }
                });

            migrationBuilder.InsertData(
                table: "invoice",
                columns: new[] { "invoice_id", "customer_id", "customer_voucher", "end_total_price", "invoice_date", "InvoiceStatus", "invoice_type", "total_price", "user_id" },
                values: new object[,]
                {
                    { "I1", "C1", 50m, 450m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type A", 500m, "U1" },
                    { "I2", "C2", 30m, 670m, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type B", 700m, "U2" },
                    { "I3", "C3", 20m, 280m, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type C", 300m, "U3" },
                    { "I4", "C4", 40m, 960m, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type D", 1000m, "U1" },
                    { "I5", "C5", 60m, 740m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", "Type E", 800m, "U2" }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "1", "1", 21.0, "I1", "Some ProductId", "Product 1", 2, 21.0, 10.5, "W1" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "ProductId", "product_name", "quantity", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "2", "1", 0.14999999999999999, 21.890000000000001, "I1", "Some ProductId", "Product 2", 1, 21.890000000000001, 25.75, "W2" });

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
                columns: new[] { "product_id", "created_at", "gem_id", "gem_weight", "gold_id", "gold_weight", "labor_cost", "markup_rate", "product_code", "product_images", "product_name", "product_quantity", "product_type", "product_warranty", "product_weight", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { "05075254-12d4-4cd7-92b0-4fa9261552cd", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(837), "2", 2.0, "2", 18.0, 100.0, 1.5, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0, 0.0, 0.0 },
                    { "1f1762ec-14df-42ea-901b-fa55e9fc4645", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(861), "1", 4.0, "2", 21.0, 130.0, 1.2, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0, 0.0, 0.0 },
                    { "253d8909-bd9d-424a-a6ae-f181f2f55fb9", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(826), "1", 5.0, "1", 45.0, 200.0, 1.2, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0, 0.0, 0.0 },
                    { "510aa500-e82b-4956-94de-09bf830b51a9", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(843), "3", 3.0, "3", 27.0, 150.0, 1.3, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0, 0.0, 0.0 },
                    { "8e656186-ef7c-40c9-b582-c881bf0e5c76", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(849), "4", 1.5, "4", 13.5, 180.0, 1.7, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0, 0.0, 0.0 },
                    { "af7a88ee-2331-4215-a367-ec503348b6af", new DateTime(2024, 6, 19, 11, 30, 34, 918, DateTimeKind.Local).AddTicks(854), "5", 2.5, "5", 7.5, 90.0, 1.1000000000000001, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "1", "user1@example.com", "User One", "$2a$11$Vz/mkh1lAQMf4qY4BpTzX.3ufeuzWz7h3kl/MKD4rLq71cs1BWlH.", "Admin", "user1" },
                    { "2", "user2@example.com", "User Two", "$2a$11$pa8kX35pG/pK79HtPBijW.tJh90SQA1f13rnRa8GkSUqdIIGl9jRq", "Manager", "user2" },
                    { "3", "user3@example.com", "User Three", "$2a$11$QYaTE5p9I4F6NWZB9gkwE.SgFpHWQOCw/MDlpPQnukmB3bLQ/9m8i", "Sale", "user3" },
                    { "4", "user4@example.com", "User Four", "$2a$11$VQrjYRhhWf0K73ZkhQbFNezaoa5O/3yRRJRTK7r/mWcO8uE5i.y9u", "Sale", "user4" },
                    { "5", "user5@example.com", "User Five", "$2a$11$yZRALHGhgw9hUhm7wZZsIeAOCsp8v68Hh2fo8VYRwKVnI7/izwbye", "Cashier", "user5" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "warranty_id", "expire_date", "product_id", "product_name", "start_date" },
                values: new object[,]
                {
                    { "87b635b2-4093-49a3-b94d-a757825d535e", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P1", "Product A", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W2", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P2", "Product B", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
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
