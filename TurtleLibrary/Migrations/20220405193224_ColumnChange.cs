using Microsoft.EntityFrameworkCore.Migrations;

namespace TurtleLibrary.Migrations
{
    public partial class ColumnChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turtle_AspNetUsers_CheckedOutToId",
                table: "Turtle");

            migrationBuilder.RenameColumn(
                name: "CheckedOutToId",
                table: "Turtle",
                newName: "CheckedOutById");

            migrationBuilder.RenameIndex(
                name: "IX_Turtle_CheckedOutToId",
                table: "Turtle",
                newName: "IX_Turtle_CheckedOutById");

            migrationBuilder.AddForeignKey(
                name: "FK_Turtle_AspNetUsers_CheckedOutById",
                table: "Turtle",
                column: "CheckedOutById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turtle_AspNetUsers_CheckedOutById",
                table: "Turtle");

            migrationBuilder.RenameColumn(
                name: "CheckedOutById",
                table: "Turtle",
                newName: "CheckedOutToId");

            migrationBuilder.RenameIndex(
                name: "IX_Turtle_CheckedOutById",
                table: "Turtle",
                newName: "IX_Turtle_CheckedOutToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turtle_AspNetUsers_CheckedOutToId",
                table: "Turtle",
                column: "CheckedOutToId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
