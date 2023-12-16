using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    /// <inheritdoc />
    public partial class ChangingMainUserId2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: "bbde869e-3781-4076-bd46-aee8b984777d");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: "bbde869e-3781-4076-bd46-aee8b984777d");

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: "bbde869e-3781-4076-bd46-aee8b984777d");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
