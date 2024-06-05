using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelSystemBE.Migrations
{
    /// <inheritdoc />
    public partial class createdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "44c7c027-3065-4279-be62-0becdcba8ea1");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "74d56cbc-9568-494e-b03b-6abe0d720da8");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "789b60a3-8c2f-4cc5-a9ce-d771ca011fbc");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "9e391b1b-f198-4f98-95d8-fe7466e102a8");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "bf862704-92e6-40ce-9708-e026f4f245ff");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "f01b872d-8716-46d9-b1f8-5db28a989283");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "product_id", "created_at", "gem_id", "gem_weight", "gold_id", "gold_weight", "labor_cost", "markup_rate", "product_code", "product_images", "product_name", "product_quantity", "product_type", "product_warranty", "product_weight" },
                values: new object[,]
                {
                    { "13edf237-dacf-4e69-b322-2141c8aa6e64", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2462), "2", 2.0, "2", 18.0, 100.00m, 1.5f, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0 },
                    { "1de0eaf8-5331-4aba-8b7f-de93edf487e1", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2491), "1", 4.0, "2", 21.0, 130.00m, 1.2f, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0 },
                    { "2fc11df4-48b5-496a-b69d-54cd8e5c7486", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2487), "5", 2.5, "5", 7.5, 90.00m, 1.1f, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0 },
                    { "9ccc457b-40e4-4273-93dc-96cbeca924a9", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2467), "3", 3.0, "3", 27.0, 150.00m, 1.3f, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0 },
                    { "df11cceb-241d-4383-8586-306e5a4c0b64", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2455), "1", 5.0, "1", 45.0, 200.00m, 1.2f, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0 },
                    { "e9a26be3-77d5-48ca-ba45-5c263c4330ec", new DateTime(2024, 6, 5, 10, 15, 3, 235, DateTimeKind.Local).AddTicks(2471), "4", 1.5, "4", 13.5, 180.00m, 1.7f, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0 }
                });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "1",
                column: "Password",
                value: "$2a$11$iYfILgXC13Nkl5Ur4pIF0e/peePMQZCuIa7CWemEfu.t11B1drEy6");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "2",
                column: "Password",
                value: "$2a$11$JqlOMhzkAIJ6pghi0lMNseWdHo8fAkrkeKIrmE4lXJyDWeBQAvO/m");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "3",
                column: "Password",
                value: "$2a$11$d6VgojlZ/9LPHoIWsF0O2.cgQhkrbb3ipW00a007YcO6nqjd0zaUq");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "4",
                column: "Password",
                value: "$2a$11$N9xRmFAiDrYyv2EzrYfcs.5YoS07hiuBNVl0R1wCo/GiQ7DofLjJC");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "5",
                column: "Password",
                value: "$2a$11$jn5wPr1X2tS8ayDQpIsP9.6bZkE0l6l1vdXxnCCzZy98GzjLjZMn2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "13edf237-dacf-4e69-b322-2141c8aa6e64");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "1de0eaf8-5331-4aba-8b7f-de93edf487e1");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "2fc11df4-48b5-496a-b69d-54cd8e5c7486");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "9ccc457b-40e4-4273-93dc-96cbeca924a9");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "df11cceb-241d-4383-8586-306e5a4c0b64");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "e9a26be3-77d5-48ca-ba45-5c263c4330ec");

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "product_id", "created_at", "gem_id", "gem_weight", "gold_id", "gold_weight", "labor_cost", "markup_rate", "product_code", "product_images", "product_name", "product_quantity", "product_type", "product_warranty", "product_weight" },
                values: new object[,]
                {
                    { "44c7c027-3065-4279-be62-0becdcba8ea1", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6896), "3", 3.0, "3", 27.0, 150.00m, 1.3f, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0 },
                    { "74d56cbc-9568-494e-b03b-6abe0d720da8", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6885), "2", 2.0, "2", 18.0, 100.00m, 1.5f, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0 },
                    { "789b60a3-8c2f-4cc5-a9ce-d771ca011fbc", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6826), "1", 5.0, "1", 45.0, 200.00m, 1.2f, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0 },
                    { "9e391b1b-f198-4f98-95d8-fe7466e102a8", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6905), "4", 1.5, "4", 13.5, 180.00m, 1.7f, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0 },
                    { "bf862704-92e6-40ce-9708-e026f4f245ff", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6924), "1", 4.0, "2", 21.0, 130.00m, 1.2f, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0 },
                    { "f01b872d-8716-46d9-b1f8-5db28a989283", new DateTime(2024, 6, 3, 20, 20, 35, 211, DateTimeKind.Local).AddTicks(6915), "5", 2.5, "5", 7.5, 90.00m, 1.1f, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0 }
                });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "1",
                column: "Password",
                value: "$2a$11$yxtJUaLfSzvmjdNiWCcJq.wpBoXY9WLe9umgmztfj/lVNmegooOgi");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "2",
                column: "Password",
                value: "$2a$11$iOJBqJ0zsV36y2EPbJ98wu7Zj5nNO7WEPWt7quM.2BUEFtge2IdnS");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "3",
                column: "Password",
                value: "$2a$11$GuIKrwqUwLH18ySqPzvHQelmUyDOdxWVfSjKoGyxb7nvTzyGkkbWO");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "4",
                column: "Password",
                value: "$2a$11$EAcnxESnv9Cx0lY1PYMZQeimy5Qr1po/87jgkjd5xgLDDatUi/Z1y");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "5",
                column: "Password",
                value: "$2a$11$yxILJA/YLYlzDDVmVqvmUOyCMhjDFj36MEYKWNVDXKRJweGza.kg.");
        }
    }
}
