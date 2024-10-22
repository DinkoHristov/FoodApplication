using FoodApplication.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.Data
{
	public class FoodDbContext : IdentityDbContext<ApplicationUser>
	{
        public FoodDbContext() 
		{ }

        public FoodDbContext(DbContextOptions<FoodDbContext> options) : base(options) 
		{ }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}