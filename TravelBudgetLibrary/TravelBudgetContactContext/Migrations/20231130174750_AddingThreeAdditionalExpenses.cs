using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelBudgetDBContact.Migrations
{
    /// <inheritdoc />
    public partial class AddingThreeAdditionalExpenses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "CategoryId", "CountryId", "Date", "Description", "Price", "TravelId" },
                values: new object[,]
                {
                    { 2, 2, 1, new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified), "Random text1", 15.5, 2 },
                    { 3, 3, 1, new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified), "Random text2", 15.5, 2 },
                    { 4, 4, 1, new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified), "Random text3", 15.5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
