using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelBudgetDBContact.Migrations
{
    public partial class UpdatingDBTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Continents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContinentId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Continents_ContinentId",
                        column: x => x.ContinentId,
                        principalTable: "Continents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TravelId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Travels_TravelId",
                        column: x => x.TravelId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryTravel",
                columns: table => new
                {
                    CountriesId = table.Column<int>(type: "int", nullable: false),
                    TravelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTravel", x => new { x.CountriesId, x.TravelsId });
                    table.ForeignKey(
                        name: "FK_CountryTravel_Countries_CountriesId",
                        column: x => x.CountriesId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTravel_Travels_TravelsId",
                        column: x => x.TravelsId,
                        principalTable: "Travels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Accomodation" },
                    { 2, "Food" },
                    { 3, "Transport" },
                    { 4, "Atractions" },
                    { 5, "Shopping" },
                    { 6, "Others" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content" },
                values: new object[,]
                {
                    { 1, "At the first day..." },
                    { 2, "At the first day..." },
                    { 3, "At the first day..." }
                });

            migrationBuilder.InsertData(
                table: "Continents",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Europe" },
                    { 2, "Africa" },
                    { 3, "Asia" },
                    { 4, "North America" },
                    { 5, "South America" },
                    { 6, "Australia" },
                    { 7, "Zelandia" },
                    { 8, "Antarctica" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { 1, "PLN" },
                    { 2, "EUR" },
                    { 3, "USD" },
                    { 4, "GBP" },
                    { 5, "SEK" },
                    { 6, "JPY" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code", "ContinentId", "CurrencyId", "Name" },
                values: new object[,]
                {
                    { 1, "PL", 1, 1, "Poland" },
                    { 2, "SE", 2, 5, "Sweden" },
                    { 3, "BR", 5, 3, "Brazil" },
                    { 4, "CR", 5, 3, "Costa Rica" },
                    { 5, "CJP", 3, 6, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "Travels",
                columns: new[] { "Id", "Active", "CommentId", "Description", "FinishDate", "Name", "StartingDate" },
                values: new object[,]
                {
                    { 1, false, 1, "Visiting castles around Poland", new DateTime(2022, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2022, 12, 16, 6, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, true, 2, "Visiting forests", new DateTime(2023, 10, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 9, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 3, true, 3, "Mazurian lakes", new DateTime(2023, 12, 12, 21, 15, 0, 0, DateTimeKind.Unspecified), "Around Poland", new DateTime(2023, 6, 18, 6, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "CategoryId", "CountryId", "Date", "Description", "Price", "TravelId" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 12, 17, 15, 15, 0, 0, DateTimeKind.Unspecified), "I bought a souvenir", 15.5, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_ContinentId",
                table: "Countries",
                column: "ContinentId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CurrencyId",
                table: "Countries",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryTravel_TravelsId",
                table: "CountryTravel",
                column: "TravelsId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TravelId",
                table: "Expenses",
                column: "TravelId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_CommentId",
                table: "Travels",
                column: "CommentId",
                unique: true,
                filter: "[CommentId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTravel");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Continents");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "Comments");
        }
    }
}
