using FoodApplication.Data.Models;
using FoodApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signManager;

        public AccountController(SignInManager<ApplicationUser> signManager)
        {
            this.signManager = signManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await this.signManager.PasswordSignInAsync(model.Email, model.Password, true, true);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("NotLogged", "Invalid Login Attempt!");

                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(returnUrl))
                return LocalRedirect(returnUrl);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var newUser = new ApplicationUser()
            {
                Name = model.Name,
                Address = model.Address,
                Email = model.Email,
                UserName = model.Email
            };

            var result = await this.signManager.UserManager.CreateAsync(newUser, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

			await this.signManager.PasswordSignInAsync(newUser, model.Password, true, true);

			return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await this.signManager.SignOutAsync();

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}