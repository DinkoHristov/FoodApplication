using FoodApplication.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace FoodApplication.Repository
{
    public class Data : IData
    {
        private readonly UserManager<ApplicationUser> userManager;

        public Data(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<ApplicationUser?> GetUser(ClaimsPrincipal claims)
            => await this.userManager.GetUserAsync(claims);
    }
}
