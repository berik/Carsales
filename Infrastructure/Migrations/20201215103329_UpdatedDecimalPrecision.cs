using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdatedDecimalPrecision : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Vehicle",
                type: "decimal(10,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ab306a9-ff4c-46ca-a6f9-c47383d928d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eda3cb4c-946c-4700-b346-62cb7fb8635d", "AQAAAAEAACcQAAAAEEwSY0QdabS/pqbrl4ugTAUTsJJlbRoS0UsGsFNY+lpt6OKJxoVrBTCt5U650HFOtg==", "2e5c3682-c010-4f3a-bb33-36198c07082b" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Engine",
                value: "a32ac040-3172-4f04-bb28-ee7d2bba5629");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Engine",
                value: "cfa2b11e-e13b-488a-881e-ef1874849bd9");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 12, 15, 21, 33, 28, 390, DateTimeKind.Local).AddTicks(3540));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 12, 15, 21, 33, 28, 404, DateTimeKind.Local).AddTicks(9760));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Vehicle",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(10,2)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ab306a9-ff4c-46ca-a6f9-c47383d928d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6c0f4400-275a-421b-9f5a-12148aed7cbb", "AQAAAAEAACcQAAAAEP0GjLchekS01t6tJnE+G42ydBSrnu6bMbn6Hfg5VkCJ/VqhTeLKB6WsuSWjWlfYDg==", "7381c1b9-402b-40dc-8f32-c930ef138f60" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Engine",
                value: "412091fd-32a2-412e-96e3-8322bd3a7304");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Engine",
                value: "267403fa-b0fd-435d-b958-d587b9d2dbd4");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 12, 15, 17, 13, 20, 578, DateTimeKind.Local).AddTicks(610));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 12, 15, 17, 13, 20, 594, DateTimeKind.Local).AddTicks(6870));
        }
    }
}
