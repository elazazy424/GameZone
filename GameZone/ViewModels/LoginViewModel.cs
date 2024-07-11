using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class LoginViewModel
    {
        [EmailAddress(ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "minimum password length is 5")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
