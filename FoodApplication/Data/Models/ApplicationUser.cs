using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Data.Models
{
	public class ApplicationUser : IdentityUser
	{
		[Required]
		[Comment("User name")]
		public string Name { get; set; } = null!;

		[Required]
		[Comment("User address")]
		public string Address { get; set; } = null!;
    }
}