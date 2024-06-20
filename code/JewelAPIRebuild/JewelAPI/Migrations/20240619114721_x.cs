using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelAPI.Migrations
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
                    gem_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
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
                    gold_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gold", x => x.gold_id);
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
                    end_total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.invoice_id);
                });

            migrationBuilder.CreateTable(
                name: "jewel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jewel", x => x.Id);
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
                    markup_rate = table.Column<float>(type: "real", nullable: false),
                    gem_id = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    gem_weight = table.Column<double>(type: "float", nullable: false),
                    gold_id = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    gold_weight = table.Column<double>(type: "float", nullable: false),
                    labor_cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false, defaultValue: 0m),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.CheckConstraint("CK_Products_GemWeight", "gem_weight > 0");
                    table.CheckConstraint("CK_Products_GoldWeight", "gold_weight > 0");
                    table.CheckConstraint("CK_Products_LaborCost", "labor_cost >= 0");
                    table.CheckConstraint("CK_Products_ProductQuantity", "product_quantity > 0");
                    table.CheckConstraint("CK_Products_ProductWeight", "product_weight > 0");
                    table.ForeignKey(
                        name: "FK_product_gem_gem_id",
                        column: x => x.gem_id,
                        principalTable: "gem",
                        principalColumn: "gem_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_gold_gold_id",
                        column: x => x.gold_id,
                        principalTable: "gold",
                        principalColumn: "gold_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_item",
                columns: table => new
                {
                    invoice_item_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    invoice_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    discount_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    discount_rate = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    end_total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    warranty_id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_item", x => x.invoice_item_id);
                    table.CheckConstraint("CK_InvoiceItem_EndTotalPrice", "end_total_price >= 0");
                    table.CheckConstraint("CK_InvoiceItem_Quantity", "quantity > 0");
                    table.CheckConstraint("CK_InvoiceItem_TotalPrice", "total_price >= 0");
                    table.CheckConstraint("CK_InvoiceItem_UnitPrice", "unit_price >= 0");
                    table.ForeignKey(
                        name: "FK_invoice_item_invoice_invoice_id",
                        column: x => x.invoice_id,
                        principalTable: "invoice",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_item_warranty_warranty_id",
                        column: x => x.warranty_id,
                        principalTable: "warranty",
                        principalColumn: "warranty_id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "DiscountId", "DiscountName", "ExpireDate", "OrderType", "ProductType", "PublicDate" },
                values: new object[,]
                {
                    { "1", "Summer Sale", new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "Jewelry 1", new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2", "Holiday Promotion", new DateTime(2024, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "Jewelry 2", new DateTime(2024, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "3", "Spring Clearance", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buyback", "Jewelry 3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "4", "Back-to-School Sale", new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sale", "Jewelry 4", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "5", "Winter Warm-up", new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Buyback", "Jewelry 5", new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "gem",
                columns: new[] { "gem_id", "gem_name", "gem_price" },
                values: new object[,]
                {
                    { "1", "Ruby", 1000.00m },
                    { "2", "Sapphire", 1500.00m },
                    { "3", "Emerald", 1200.00m },
                    { "4", "Diamond", 5000.00m },
                    { "5", "Topaz", 800.00m }
                });

            migrationBuilder.InsertData(
                table: "gold",
                columns: new[] { "gold_id", "gold_name", "gold_price" },
                values: new object[,]
                {
                    { "1", "24K Gold", 6000.00m },
                    { "2", "22K Gold", 5500.00m },
                    { "3", "18K Gold", 4500.00m },
                    { "4", "14K Gold", 4000.00m },
                    { "5", "10K Gold", 3500.00m }
                });

            migrationBuilder.InsertData(
                table: "invoice",
                columns: new[] { "invoice_id", "customer_id", "customer_voucher", "end_total_price", "invoice_date", "invoice_type", "total_price", "user_id" },
                values: new object[,]
                {
                    { "I1", "C1", 50.00m, 450.00m, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type A", 500.00m, "U1" },
                    { "I2", "C2", 30.00m, 670.00m, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type B", 700.00m, "U2" },
                    { "I3", "C3", 20.00m, 280.00m, new DateTime(2024, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type C", 300.00m, "U3" },
                    { "I4", "C4", 40.00m, 960.00m, new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type D", 1000.00m, "U1" },
                    { "I5", "C5", 60.00m, 740.00m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Type E", 800.00m, "U2" }
                });

            migrationBuilder.InsertData(
                table: "jewel",
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
                table: "user",
                columns: new[] { "UserId", "Email", "Fullname", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { "1", "user1@example.com", "User One", "$2a$10$W9JQqHLEAvIsuDRvJsFmtOyitIKr732D9wnUUqN1sL88CEJ1lHqy6", "Admin", "user1" },
                    { "2", "user2@example.com", "User Two", "$2a$10$vml/KQj8U1K.iaUs1MZCk.cfoHCwVCrrUA6esQsB.r1mVEqvjxyT6", "User", "user2" },
                    { "3", "user3@example.com", "User Three", "$2a$10$zd2gW0ES9onLymra.t1FreYYPXxeXA0glyxoitLeK2fXQMZxn9fda", "User", "user3" },
                    { "4", "user4@example.com", "User Four", "$2a$10$H7vgCs9BM2.bqbl/Mac8QOUfeXh8iZdhG3.Dl1Uuvb9etZmKN3gbO", "User", "user4" },
                    { "5", "user5@example.com", "User Five", "$2a$10$P3Q9zkp/OtV7x3nfDPylvOfWagDgacEuMXgf3GygSFbbb9ViJSKgO", "User", "user5" }
                });

            migrationBuilder.InsertData(
                table: "warranty",
                columns: new[] { "warranty_id", "expire_date", "product_id", "product_name", "start_date" },
                values: new object[,]
                {
                    { "W1", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P1", "Product A", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W2", new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P2", "Product B", new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "W3", new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "P3", "Product C", new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "invoice_item",
                columns: new[] { "invoice_item_id", "discount_id", "discount_rate", "end_total_price", "invoice_id", "product_name", "quantity", "total_price", "unit_price", "warranty_id" },
                values: new object[,]
                {
                    { "1", "1", 0m, 21.00m, "I1", "Product 1", 2, 21.00m, 10.50m, "W1" },
                    { "2", "1", 0.15m, 21.89m, "I1", "Product 2", 1, 21.89m, 25.75m, "W2" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "product_id", "created_at", "gem_id", "gem_weight", "gold_id", "gold_weight", "labor_cost", "markup_rate", "product_code", "product_images", "product_name", "product_quantity", "product_type", "product_warranty", "product_weight" },
                values: new object[,]
                {
                    { "282c1618-f2ff-4795-a9e5-03eb08111b5f", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5200), "4", 1.5, "4", 13.5, 180.00m, 1.7f, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0 },
                    { "35572135-fbd3-40c4-8eca-8a8005ff5d8f", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5210), "1", 4.0, "2", 21.0, 130.00m, 1.2f, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0 },
                    { "535b14b7-8050-41a6-a669-707fa2603769", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5205), "5", 2.5, "5", 7.5, 90.00m, 1.1f, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0 },
                    { "5ecd075b-6056-4d68-b4dc-7b9a3245c529", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5195), "3", 3.0, "3", 27.0, 150.00m, 1.3f, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0 },
                    { "899af466-a560-45c6-95fe-cde96081ecf3", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5169), "1", 5.0, "1", 45.0, 200.00m, 1.2f, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0 },
                    { "e74a40d6-2cb8-4fe6-b052-bf4c334f6325", new DateTime(2024, 6, 19, 18, 47, 20, 474, DateTimeKind.Local).AddTicks(5186), "2", 2.0, "2", 18.0, 100.00m, 1.5f, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_invoice_id",
                table: "invoice_item",
                column: "invoice_id");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_item_warranty_id",
                table: "invoice_item",
                column: "warranty_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_gem_id",
                table: "product",
                column: "gem_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_gold_id",
                table: "product",
                column: "gold_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "discount");

            migrationBuilder.DropTable(
                name: "invoice_item");

            migrationBuilder.DropTable(
                name: "jewel");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "warranty");

            migrationBuilder.DropTable(
                name: "gem");

            migrationBuilder.DropTable(
                name: "gold");
        }
    }
}
