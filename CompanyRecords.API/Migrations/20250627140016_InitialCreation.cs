using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyRecords.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Exchange = table.Column<string>(type: "TEXT", nullable: false),
                    Ticker = table.Column<string>(type: "TEXT", nullable: false),
                    Isin = table.Column<string>(type: "TEXT", nullable: false),
                    WebsiteUrl = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Exchange", "Isin", "Name", "Ticker", "WebsiteUrl" },
                values: new object[,]
                {
                    { 1, "NASDAQ", "US0378331005", "Apple Inc.", "AAPL", "http://www.apple.com" },
                    { 2, "Pink Sheets", "US1104193065", "British Airways Plc", "BAIRY", null },
                    { 3, "Euronext Amsterdam", "NL0000009165", "Heineken NV", "HEIA", null },
                    { 4, "Tokyo Stock Exchange", "JP3866800000", "Panasonic Corp", "6752", "http://www.panasonic.co.jp" },
                    { 5, "Deutsche Börse", "DE000PAH0038", "Porsche Automobil", "PAH3", "https://www.porsche.com/" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Isin",
                table: "Companies",
                column: "Isin",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
