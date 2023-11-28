using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    public partial class AddingForeignKeyToExpenseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Accommodation");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "JP");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CountryId",
                table: "Expenses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Countries_CountryId",
                table: "Expenses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Countries_CountryId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_CountryId",
                table: "Expenses");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Type",
                value: "Accomodation");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5,
                column: "Code",
                value: "CJP");
        }
    }
}
