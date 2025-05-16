using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IdeaManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ideas",
                columns: new[] { "Id", "CreatedAt", "Description", "ProjectId", "Status", "Title", "VotesCount" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 23, 28, 48, 289, DateTimeKind.Utc).AddTicks(619), "Description for Idea 1", 1, 0, "Idea 1", 0 },
                    { 2, new DateTime(2025, 5, 16, 23, 28, 48, 289, DateTimeKind.Utc).AddTicks(1367), "Description for Idea 2", 2, 0, "Idea 2", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ideas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
