using Microsoft.EntityFrameworkCore.Migrations;

namespace FigureStorage.API.Migrations
{
    public partial class RemoveFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Figures");

            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "Figures");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Figures",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsValid",
                table: "Figures",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
