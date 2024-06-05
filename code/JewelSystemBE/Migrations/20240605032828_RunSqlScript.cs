using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace JewelSystemBE.Migrations
{
    /// <inheritdoc />
    public partial class RunSqlScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1244262e-9162-4d35-8f5c-8e6a00d3628c", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6631), "1", 4.0, "2", 21.0, 130.00m, 1.2f, "P006", "ruby_bracelet.jpg", "Ruby Bracelet", 7, "Bracelet", 12, 25.0 },
                    { "7950d03e-7de8-48e9-b80b-c4aece26ee9c", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6607), "3", 3.0, "3", 27.0, 150.00m, 1.3f, "P003", "emerald_bracelet.jpg", "Emerald Bracelet", 8, "Bracelet", 18, 30.0 },
                    { "828adbee-72e4-4de5-b3ad-806b532c25a8", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6623), "4", 1.5, "4", 13.5, 180.00m, 1.7f, "P004", "diamond_earrings.jpg", "Diamond Earrings", 12, "Earrings", 24, 15.0 },
                    { "84abd533-aa3b-457f-a2e7-cfd2c553a2bb", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6627), "5", 2.5, "5", 7.5, 90.00m, 1.1f, "P005", "topaz_pendant.jpg", "Topaz Pendant", 20, "Pendant", 6, 10.0 },
                    { "c7910802-60bc-4cce-bf3f-fbbd2ab2b5c5", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6601), "2", 2.0, "2", 18.0, 100.00m, 1.5f, "P002", "sapphire_ring.jpg", "Sapphire Ring", 5, "Ring", 24, 20.0 },
                    { "ecfbba59-ef5d-43f1-b756-caeaef601471", new DateTime(2024, 6, 5, 10, 28, 28, 516, DateTimeKind.Local).AddTicks(6596), "1", 5.0, "1", 45.0, 200.00m, 1.2f, "P001", "ruby_necklace.jpg", "Ruby Necklace", 10, "Necklace", 12, 50.0 }
                });

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "1",
                column: "Password",
                value: "$2a$11$GSbul3mmiNu6X6v1CjTVNeW5dSVIKqKkGrtbkjHQ9BOkCexcwPCum");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "2",
                column: "Password",
                value: "$2a$11$u.WW5Z3X1Q7V6A0rQuBo2.BPATlqauYzLFx.uY1Ay4znfZsWXM/N.");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "3",
                column: "Password",
                value: "$2a$11$JHBSzV3w.91cgNWM.bmO4OMyS6jpjG7vLeddyhBCFI/JzBmf8KpZK");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "4",
                column: "Password",
                value: "$2a$11$Wyn9uRVgcq2mSOJz2iwix.v14Q.ODR46KwKye6JPVig4Cw175b3Nq");

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "UserId",
                keyValue: "5",
                column: "Password",
                value: "$2a$11$zHm0miXqnsZQqAFVqpTeJOzHi4NRt97Iy7/ybCDXvM63DkzPtv1jS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "1244262e-9162-4d35-8f5c-8e6a00d3628c");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "7950d03e-7de8-48e9-b80b-c4aece26ee9c");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "828adbee-72e4-4de5-b3ad-806b532c25a8");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "84abd533-aa3b-457f-a2e7-cfd2c553a2bb");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "c7910802-60bc-4cce-bf3f-fbbd2ab2b5c5");

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "product_id",
                keyValue: "ecfbba59-ef5d-43f1-b756-caeaef601471");

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
    }
}
