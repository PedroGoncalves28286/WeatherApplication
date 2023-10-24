using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApplication.Prism.Models
{
    public class RegisterResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Confirm { get; set; }
    }
}
