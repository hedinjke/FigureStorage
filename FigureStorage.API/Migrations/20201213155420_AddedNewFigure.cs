using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureStorage.API.Migrations
{
    public partial class AddedNewFigure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewFigure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Side = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewFigure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewFigure_Figures_Id",
                        column: x => x.Id,
                        principalTable: "Figures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewFigure");
        }
    }
}
