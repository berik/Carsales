using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddImageUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ab306a9-ff4c-46ca-a6f9-c47383d928d8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e70e739-389b-4a8e-9456-ef947e8e4f9e", "AQAAAAEAACcQAAAAEDXHPuhvi/Amar4u8jCWjyiEuWFKmvSepM+tChrYwoF+sXgi8wrgMiSEZoi4xLeBhg==", "83caa590-3d2d-4c8f-820c-233449d45b8d" });

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1,
                column: "Engine",
                value: "faf0a964-af87-4b9e-8118-d59a3a37f4d3");

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2,
                column: "Engine",
                value: "edcb79a7-9b48-4a5c-acc3-f72990dfadfb");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2020, 12, 15, 22, 11, 59, 643, DateTimeKind.Local).AddTicks(4410));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2020, 12, 15, 22, 11, 59, 659, DateTimeKind.Local).AddTicks(4460));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicle");

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
    }
}
