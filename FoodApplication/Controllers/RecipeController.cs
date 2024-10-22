using FoodApplication.Data;
using FoodApplication.Data.Models;
using FoodApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
	public class RecipeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly FoodDbContext dbContext;

        public RecipeController(UserManager<ApplicationUser> userManager, FoodDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetRecipeCard([FromBody] List<Recipe> recipes)
        {
            return PartialView("_RecipeCard", recipes);
        }

        [HttpGet]
        public IActionResult Search([FromQuery] string recipe)
        {
            ViewBag.Recipe = recipe;

            return View();
        }

        [HttpGet]
        public IActionResult Order([FromQuery] string id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ShowOrder(OrderRecipeDetails details)
        {
            var random = new Random();
            ViewBag.Price = random.Next(10, 35);

			var user = await this.userManager.GetUserAsync(User);
			ViewBag.UserId = user?.Id;
			ViewBag.Address = user?.Address;

			return PartialView("_ShowOrder", details);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Order([FromForm]Order order)
        {
			order.OrderDate = DateTime.Now;

			if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Invalid order");

                return View();
			}

            await this.dbContext.Orders.AddAsync(order);
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
		}
    }
}