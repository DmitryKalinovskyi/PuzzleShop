using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PuzzleShop.Migrations
{
    /// <inheritdoc />
    public partial class OrderOrderPuzzleMigration_dbsetadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    DestinationPlace = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderPuzzles",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    PuzzleId = table.Column<int>(type: "int", nullable: false),
                    FixedPrice = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderPuzzles", x => new { x.OrderId, x.PuzzleId });
                    table.ForeignKey(
                        name: "FK_OrderPuzzles_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderPuzzles_Puzzles_PuzzleId",
                        column: x => x.PuzzleId,
                        principalTable: "Puzzles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderPuzzles_PuzzleId",
                table: "OrderPuzzles",
                column: "PuzzleId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderPuzzles");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
