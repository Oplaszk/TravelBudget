using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetContactContext.Migrations
{
    public partial class CommentUpdate : Migration
    {
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
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
