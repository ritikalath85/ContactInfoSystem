using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ContactInfoSystem.App.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Please enter Full Name")]
        public string UserFullName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Invalid characters in password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [RegularExpression("^[a-zA-Z0-9_]*$", ErrorMessage = "Invalid characters in password")]
        [Compare("Password", ErrorMessage = "Password and confirm password should be same")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select designation")]
        public int DesignationId { get; set; }
        [Required(ErrorMessage = "Please select country")]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Please select gender")]
        public int Gender { get; set; }
        public string UserImageName { get; set; }

       // [FileExtensions(Extensions = "png, jpeg, jpg")]
        public IFormFile File { get; set; }

        [Required(ErrorMessage = "Please enter email")]
        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please enter MobileNo")]
        public string MobileNo { get; set; }

    }
}
