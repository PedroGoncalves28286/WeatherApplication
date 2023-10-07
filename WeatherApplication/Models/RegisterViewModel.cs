using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Models
{
    public class RegisterViewModel
    {

        [Required, StringLength(35)]
        public string FirstName { get; set; }
        [Required, StringLength(30)]
        public string LastName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must have at least 6 characters!")]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password), ErrorMessage = "Password and Confirm Password must be equal!")]
        public string ConfirmPassword { get; set; }
    }
}
