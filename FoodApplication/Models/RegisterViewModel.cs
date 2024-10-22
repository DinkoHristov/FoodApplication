using System.ComponentModel.DataAnnotations;

namespace FoodApplication.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}