using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class RegisterViewModel
    {
        [EmailAddress(ErrorMessage = "Invalid email")]
        [Required(ErrorMessage = "Email is required")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "minimum password length is 5")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare(nameof(Password), ErrorMessage = "password mismatch")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "phone is required")]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool IsAgree { get; set; }

    }
}
