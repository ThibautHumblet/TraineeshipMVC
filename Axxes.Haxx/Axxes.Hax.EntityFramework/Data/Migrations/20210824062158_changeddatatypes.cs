using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.Haxx.EntityFramework.Data
{
    public partial class changeddatatypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 8, 24, 6, 21, 57, 981, DateTimeKind.Utc).AddTicks(8121));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 8, 24, 6, 21, 57, 981, DateTimeKind.Utc).AddTicks(8532));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 8, 19, 6, 21, 57, 980, DateTimeKind.Utc).AddTicks(8168));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 8, 29, 6, 21, 57, 980, DateTimeKind.Utc).AddTicks(8591));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 8, 22, 6, 21, 57, 980, DateTimeKind.Utc).AddTicks(8615));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 8, 24, 6, 17, 13, 421, DateTimeKind.Utc).AddTicks(7933));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 8, 24, 6, 17, 13, 421, DateTimeKind.Utc).AddTicks(8459));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 8, 19, 6, 17, 13, 420, DateTimeKind.Utc).AddTicks(1456));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 8, 29, 6, 17, 13, 420, DateTimeKind.Utc).AddTicks(1906));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 8, 22, 6, 17, 13, 420, DateTimeKind.Utc).AddTicks(1925));
        }
    }
}
