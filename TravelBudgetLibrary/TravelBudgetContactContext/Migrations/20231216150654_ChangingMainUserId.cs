using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMainUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "289a4aad-7cb3-4e92-b49a-04fd4bdda59a");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "289a4aad-7cb3-4e92-b49a-04fd4bdda59a");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "289a4aad-7cb3-4e92-b49a-04fd4bdda59a");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "c9c98838-1475-49b6-a54d-6aa6cd4e5bdc");
        }
    }
}
