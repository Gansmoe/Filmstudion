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
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmstudios", x => x.FilmStudioId);
                });

            migrationBuilder.InsertData(
                table: "Filmstudios",
                columns: new[] { "FilmStudioId", "City", "Name" },
                values: new object[] { 1, "Göteborg", "Testis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmstudios");
        }
    }
}
