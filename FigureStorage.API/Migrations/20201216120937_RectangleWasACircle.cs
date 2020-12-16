using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureStorage.API.Migrations
{
    public partial class RectangleWasACircle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rectangles");

            migrationBuilder.CreateTable(
                name: "Circles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Radius = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Circles_Figures_Id",
                        column: x => x.Id,
                        principalTable: "Figures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circles");

            migrationBuilder.CreateTable(
                name: "Rectangles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Radius = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rectangles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rectangles_Figures_Id",
                        column: x => x.Id,
                        principalTable: "Figures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }
    }
}
