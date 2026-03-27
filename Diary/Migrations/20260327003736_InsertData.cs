using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Diary.Migrations
{
    /// <inheritdoc />
    public partial class InsertData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "CreatedOn", "Disabled", "Enabled", "Title", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "This is the content of the first diary entry.", new DateTime(2026, 3, 27, 0, 37, 35, 922, DateTimeKind.Local).AddTicks(7225), false, true, "First Entry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "This is the content of the second diary entry.", new DateTime(2026, 3, 27, 0, 37, 35, 922, DateTimeKind.Local).AddTicks(8560), false, true, "Second Entry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "This is the content of the Third diary entry.", new DateTime(2026, 3, 27, 0, 37, 35, 922, DateTimeKind.Local).AddTicks(8567), false, true, "Third Entry", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
