using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleShop.Migrations
{
    /// <inheritdoc />
    public partial class PuzzleNameIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Puzzles_Name",
                table: "Puzzles",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Puzzles_Name",
                table: "Puzzles");
        }
    }
}
