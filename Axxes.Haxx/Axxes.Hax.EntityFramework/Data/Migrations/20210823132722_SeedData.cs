using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Axxes.Haxx.EntityFramework.Data
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "Date", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 1, ".NET", new DateTime(2021, 8, 18, 13, 27, 21, 941, DateTimeKind.Utc).AddTicks(1193), "Allround .NET session", true, null, "Allround .NET" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "Date", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 2, "Java", new DateTime(2021, 8, 28, 13, 27, 21, 941, DateTimeKind.Utc).AddTicks(2167), "Allround Java session", true, null, "Allround Java" });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "Category", "Date", "Description", "IsPublic", "SpeakerId", "Title" },
                values: new object[] { 3, "General", new DateTime(2021, 8, 21, 13, 27, 21, 941, DateTimeKind.Utc).AddTicks(2188), "Basics about Visual Studio code", false, null, "VS Code basics" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Date", "SessionId", "Text" },
                values: new object[] { 1, null, new DateTime(2021, 8, 23, 13, 27, 21, 941, DateTimeKind.Utc).AddTicks(9221), 1, "Nice session" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Date", "SessionId", "Text" },
                values: new object[] { 2, null, new DateTime(2021, 8, 23, 13, 27, 21, 941, DateTimeKind.Utc).AddTicks(9507), 3, "Interesting" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
