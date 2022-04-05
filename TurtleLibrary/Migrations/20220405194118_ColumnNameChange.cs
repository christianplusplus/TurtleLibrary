using Microsoft.EntityFrameworkCore.Migrations;

namespace TurtleLibrary.Migrations
{
    public partial class ColumnNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OriginalImage",
                table: "Turtle",
                newName: "Portrait");

            migrationBuilder.RenameColumn(
                name: "CurrentImage",
                table: "Turtle",
                newName: "OriginalPortrait");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Portrait",
                table: "Turtle",
                newName: "OriginalImage");

            migrationBuilder.RenameColumn(
                name: "OriginalPortrait",
                table: "Turtle",
                newName: "CurrentImage");
        }
    }
}
