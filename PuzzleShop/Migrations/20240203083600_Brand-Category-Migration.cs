using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleShop.Migrations
{
    /// <inheritdoc />
    public partial class BrandCategoryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsConfirmed",
                table: "Brands",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Brands",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_OwnerId",
                table: "Brands",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_OwnerId",
                table: "Brands",
                column: "OwnerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_OwnerId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_OwnerId",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsConfirmed",
                table: "Brands");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Brands");
        }
    }
}
