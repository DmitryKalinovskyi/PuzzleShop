using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderPuzzleMigrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Categories_CategoryId",
                table: "Puzzles");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Puzzles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Categories_CategoryId",
                table: "Puzzles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puzzles_Categories_CategoryId",
                table: "Puzzles");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Puzzles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Puzzles_Categories_CategoryId",
                table: "Puzzles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
