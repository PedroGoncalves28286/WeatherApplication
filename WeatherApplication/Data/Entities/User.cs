using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(15, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string FirstName { get; set; }

        [MaxLength(20, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string LastName { get; set; }



        [MaxLength(50, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Password { get; set; }


        [MaxLength(100, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public override string Email { get; set; }
    }
}
