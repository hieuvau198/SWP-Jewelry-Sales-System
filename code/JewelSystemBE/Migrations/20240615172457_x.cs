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
                    { "7d718ca5-611e-4481-8ff7-c8c32e0b554a", "Some Product Id", "Some Product Name", 0 },
                    { "d8035e00-2597-4b20-a8a8-3220e2e745c4", "Some Product Id", "Some Product Name", 0 },
                    { "e79dfcb5-e9b5-41f6-9879-7d944a82f150", "Some Product Id", "Some Product Name", 0 },
                    { "ef3bd464-c1d4-4927-8a41-76b09cfbc6d1", "Some Product Id", "Some Product Name", 0 },
                    { "fd941e32-2e0e-41c4-b8b3-1bd321506aaa", "Some Product Id", "Some Product Name", 0 }
                });

            migrationBuilder.InsertData(
                table: "Stalls",
                columns: new[] { "StallId", "StaffId", "StallDescription", "StallName", "StallType" },
                values: new object[,]
                {
                    { "0b2de431-440d-4a60-9b1d-694635912910", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "18918ad3-2e71-42fd-b720-d06f4c08f59b", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "bc088019-1656-4085-a2f2-abc4acd50aff", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "c6bd1201-d24b-4855-a633-c13c64eb66bc", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" },
                    { "cde51957-825d-4322-b143-7c533f647b63", "Some Staff Id", "Some Stall Description", "Some Stall Name", "None" }
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
                    { "1", "Summer Sale", 0.0, new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 1", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2", "Holiday Promotion", 0.0, new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 2", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3", "Spring Clearance", 0.0, new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buyback", "All", "Jewelry 3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4", "Back-to-School Sale", 0.0, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "All", "Jewelry 4", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
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
                columns: new[] { "invoice_item_id", "discount_id", "end_total_price", "invoice_id", "product_name", "quantity", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "1", "1", 21.0, "I1", "Product 1", 2, 21.0, 10.5, "W1" });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "product_name", "quantity", "total_price", "unit_price", "warranty_id" },
                values: new object[] { "2", "1", 0.14999999999999999, 21.890000000000001, "I1", "Product 2", 1, 21.890000000000001, 25.75, "W2" });

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
                    { "155eceaa-363b-4cb9-8f22-4b8c3e4f4a4f", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(290), "2", 2.0, "2", 18.0, 100.0, 1.5, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0, 0.0, 0.0 },
                    { "29bfd17c-f485-43e2-9cef-61f36335e0e9", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(285), "1", 5.0, "1", 45.0, 200.0, 1.2, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0, 0.0, 0.0 },
                    { "4f3c5eb2-de15-4805-893f-ff47bc548005", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(301), "4", 1.5, "4", 13.5, 180.0, 1.7, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0, 0.0, 0.0 },
                    { "92300e96-c162-4bf1-9253-4cd51d573ab8", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(294), "3", 3.0, "3", 27.0, 150.0, 1.3, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0, 0.0, 0.0 },
                    { "b09f2d6f-4f9c-4140-9576-3e7f2e3985c0", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(362), "5", 2.5, "5", 7.5, 90.0, 1.1000000000000001, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0, 0.0, 0.0 },
                    { "d84b03e6-7581-48f0-b5fc-b979b6fd74d5", new DateTime(2024, 6, 16, 0, 24, 55, 667, DateTimeKind.Local).AddTicks(365), "1", 4.0, "2", 21.0, 130.0, 1.2, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0, 0.0, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "1", "user1@example.com", "User One", "$2a$11$qBu9jOJfkGFCRaCZORuzCuFCqbp2W4rWC98puDXvqrO5CSAQW1hcS", "Admin", "user1" },
                    { "2", "user2@example.com", "User Two", "$2a$11$s8Fv8z.t8TFDgZ0UY0eICuPhjhWFonvMBMyROg87NhYY/niIZCC0e", "Manager", "user2" },
                    { "3", "user3@example.com", "User Three", "$2a$11$eWPFn.v3rX7dhQWPxKG4fOLhY1NLFEWqvxuJ0RV3jXgxZ9ghb0gcC", "Sale", "user3" },
                    { "4", "user4@example.com", "User Four", "$2a$11$9inu/vsWo4PcG.2DWl.sTuLLtjWYcY7eNInMDnSWYvB5JPZ12AyP.", "Sale", "user4" },
                    { "5", "user5@example.com", "User Five", "$2a$11$BYBujna4ZQ.FJa4Ka3LPw.1to6NdZOmgoLYvOVQmvxXYLvG2M77Ii", "Cashier", "user5" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "warranty_id", "expire_date", "product_id", "product_name", "start_date" },
                values: new object[,]
                {
                    { "94cfb5d7-2330-4d20-9407-e75bc7ac1e4e", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
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
