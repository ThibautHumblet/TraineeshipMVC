using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.Haxx.EntityFramework.Data
{
    public partial class changedauthoriddatatype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Comments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { null, new DateTime(2021, 8, 24, 6, 17, 13, 421, DateTimeKind.Utc).AddTicks(7933) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { null, new DateTime(2021, 8, 24, 6, 17, 13, 421, DateTimeKind.Utc).AddTicks(8459) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { 0, new DateTime(2021, 8, 24, 6, 12, 40, 344, DateTimeKind.Utc).AddTicks(833) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AuthorId", "Date" },
                values: new object[] { 0, new DateTime(2021, 8, 24, 6, 12, 40, 344, DateTimeKind.Utc).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2021, 8, 19, 6, 12, 40, 343, DateTimeKind.Utc).AddTicks(161));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2021, 8, 29, 6, 12, 40, 343, DateTimeKind.Utc).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2021, 8, 22, 6, 12, 40, 343, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId1",
                table: "Comments",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_AuthorId1",
                table: "Comments",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
