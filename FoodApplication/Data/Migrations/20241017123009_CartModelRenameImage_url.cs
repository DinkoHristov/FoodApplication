using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApplication.Migrations
{
    /// <inheritdoc />
    public partial class CartModelRenameImage_url : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Carts",
                newName: "Image_url");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image_url",
                table: "Carts",
                newName: "ImageUrl");
        }
    }
}
