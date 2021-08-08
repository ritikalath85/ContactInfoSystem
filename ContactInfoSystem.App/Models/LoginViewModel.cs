using System.ComponentModel.DataAnnotations;

namespace ContactInfoSystem.App.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter username")]
        [EmailAddress(ErrorMessage = "Please enter valid username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Invalid characters in password")]
        public string Password { get; set; }
    }
}
