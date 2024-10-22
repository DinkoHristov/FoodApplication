using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApplication.Migrations
{
    /// <inheritdoc />
    public partial class CartModelUpdateColumnsRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "User Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Recipe Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "Recipe Identifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "User Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "User Identifier");

            migrationBuilder.AlterColumn<string>(
                name: "RecipeId",
                table: "Carts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Recipe Identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "Recipe Identifier");
        }
    }
}
