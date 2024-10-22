using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodApplication.Migrations
{
    /// <inheritdoc />
    public partial class CartModelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Cart item image url"),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Cart item publisher"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Cart item title"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}
