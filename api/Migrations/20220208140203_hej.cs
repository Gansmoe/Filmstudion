using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmstudion.Migrations
{
    public partial class hej : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filmstudios",
                columns: table => new
                {
                    FilmStudioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FilmStudioCity = table.Column<string>(type: "TEXT", nullable: true),
                    FilmStudioName = table.Column<string>(type: "TEXT", nullable: true),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmstudios", x => x.FilmStudioId);
                });

            migrationBuilder.InsertData(
                table: "Filmstudios",
                columns: new[] { "FilmStudioId", "FilmStudioCity", "FilmStudioName", "Password", "Username" },
                values: new object[] { 1, "Göteborg", "Testis", "Hej", "Olle" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmstudios");
        }
    }
}
