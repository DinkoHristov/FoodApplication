using FoodApplication.Data;
using FoodApplication.Data.Models;
using FoodApplication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApplication.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IData data;
        private readonly FoodDbContext dbContext;

        public CartController(IData data, FoodDbContext dbContext)
        {
            this.data = data;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await this.data.GetUser(HttpContext.User);
            var cartList = await this.dbContext.Carts.AsNoTracking().Where(c => c.UserId == user.Id).ToListAsync();

            return View(cartList);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCart(Cart cart)
        {
            var user = await this.data.GetUser(HttpContext.User);
            cart.UserId = user?.Id;

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.dbContext.Carts.AddAsync(cart);
            await this.dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAddedCarts()
        {
            var user = await this.data.GetUser(HttpContext.User);
            var carts = await this.dbContext.Carts.AsNoTracking().Where(c => c.UserId == user.Id).Select(c => c.RecipeId).ToListAsync();

            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveCartFromList(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            var cart = await this.dbContext.Carts.Where(c => c.RecipeId == id).FirstOrDefaultAsync();

            if (cart != null)
            {
                this.dbContext.Carts.Remove(cart);
                await this.dbContext.SaveChangesAsync();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetCartList()
        {
            var user = await this.data.GetUser(HttpContext.User);
            var cartList = await this.dbContext.Carts.AsNoTracking().Where(c => c.UserId == user.Id).Take(3).ToListAsync();

            return PartialView("_CartList", cartList);
        }
    }
}
