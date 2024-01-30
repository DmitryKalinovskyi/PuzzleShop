using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleShop.Migrations
{
    /// <inheritdoc />
    public partial class Updated_user_info3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Users",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Users",
                newName: "Adress");
        }
    }
}
