using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Data.Models
{
	public class Cart
	{
		[Key]
		[Comment("Cart Identifier")]
        public int Id { get; set; }

		[Required]
		[Comment("Cart item image url")]
		public string Image_url { get; set; } = null!;

		[Required]
		[Comment("Cart item publisher")]
		public string Publisher { get; set; } = null!;

		[Required]
		[Comment("Cart item title")]
		public string Title { get; set; } = null!;

		[Comment("User Identifier")]
		public string? UserId { get; set; }

        [Comment("Recipe Identifier")]
        public string? RecipeId { get; set; }
    }
}