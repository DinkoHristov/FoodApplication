using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApplication.Migrations
{
    /// <inheritdoc />
    public partial class OrderModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Recipe Identifier"),
                    RecipeName = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Recipe name"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Identifier"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Order address"),
                    Price = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, comment: "Order price"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Order quantity"),
                    TotalAmount = table.Column<decimal>(type: "decimal(15,4)", precision: 15, scale: 4, nullable: false, comment: "Order total amount price"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Order date")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
