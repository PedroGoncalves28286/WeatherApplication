using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Models
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        [Required]

        public string UserName { get; set; }



        [Required]
        [MinLength(6, ErrorMessage = "Password must be longer than 6 characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
