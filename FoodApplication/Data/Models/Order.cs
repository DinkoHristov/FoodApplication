using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Data.Models
{
	public class Order
    {
        [Key]
        [Comment("Order Identifier")]
        public int Id { get; set; }

        [Required]
        [Comment("Recipe Identifier")]
        public string RecipeId { get; set; } = null!;

        [Required]
        [Comment("Recipe name")]
        public string RecipeName { get; set; } = null!;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = null!;

        [Required]
        [Comment("Order address")]
        public string Address { get; set; } = null!;

        [Required]
        [Precision(15, 4)]
        [Comment("Order price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Order quantity")]
        public int Quantity { get; set; }

        [Required]
		[Precision(15, 4)]
		[Comment("Order total amount price")]
        public decimal TotalAmount { get; set; }

        [Required]
        [Comment("Order date")]
        public DateTime OrderDate { get; set; }
    }
}