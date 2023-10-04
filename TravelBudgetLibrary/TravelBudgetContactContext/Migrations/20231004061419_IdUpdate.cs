using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetContactContext.Migrations
{
    public partial class IdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 1, false, 1, "Visiting castles around Poland", new DateTime(2022, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2022, 12, 16, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 2, true, 2, "Visiting forests", new DateTime(2023, 10, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 9, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 3, true, 3, "Mazurian lakes", new DateTime(2023, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 6, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Travels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 1, false, 1, "Visiting castles around Poland", new DateTime(2022, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2022, 12, 16, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 2, true, 2, "Visiting forests", new DateTime(2023, 10, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 9, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[] { 3, true, 3, "Mazurian lakes", new DateTime(2023, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 6, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
