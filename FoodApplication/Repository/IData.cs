using FoodApplication.Data.Models;
using System.Security.Claims;

namespace FoodApplication.Repository
{
    public interface IData
    {
        /// <summary>
        /// This method gets the current User
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        Task<ApplicationUser?> GetUser(ClaimsPrincipal claims);
    }
}
