using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingTravelsAndExpensesList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CountryId", "Price" },
                values: new object[] { 2, 25.5 });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 88.0);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 102.3);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 34.5);

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "CategoryId", "CountryId", "Date", "Description", "Price", "TravelId" },
                values: new object[] { 5, 1, 4, new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified), "Random text4", 130.0, 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CountryId", "Price" },
                values: new object[] { 1, 15.5 });

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Price",
                value: 15.5);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 15.5);

            migrationBuilder.UpdateData(
                table: "Expenses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 15.5);
        }
    }
}
