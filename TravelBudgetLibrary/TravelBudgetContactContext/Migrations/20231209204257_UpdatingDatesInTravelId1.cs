using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingDatesInTravelId1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Comments_CommentId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_CommentId",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Travels",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expenses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartingDate" },
                values: new object[] { new DateTime(2022, 12, 16, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 12, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_CommentId",
                table: "Travels",
                column: "CommentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Comments_CommentId",
                table: "Travels",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Travels_Comments_CommentId",
                table: "Travels");

            migrationBuilder.DropIndex(
                name: "IX_Travels_CommentId",
                table: "Travels");

            migrationBuilder.AlterColumn<int>(
                name: "CommentId",
                table: "Travels",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Expenses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FinishDate", "StartingDate" },
                values: new object[] { new DateTime(2022, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 16, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Travels_CommentId",
                table: "Travels",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Travels_Comments_CommentId",
                table: "Travels",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }
    }
}
