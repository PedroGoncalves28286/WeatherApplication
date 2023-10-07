using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using WeatherApplication.Data.Entities;
using WeatherApplication.Helpers;

namespace WeatherApplication.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();


            //Add User Admin when create db
            var userAdmin = await _userHelper.GetUserByEmailAsync("pedromfonsecagoncalves@gmail.com");
            if (userAdmin == null)
            {
                userAdmin = new User
                {
                    Email = "pedromfonsecagoncalves@gmail.com",
                    UserName = "pedromfonsecagoncalves@gmail.com",
                    Password = "pedro123",
                    FirstName = "pedro",
                    LastName = "goncalves"
                };
                var result1 = await _userHelper.AddUserAsync(userAdmin, "pedro123");
                if (result1 != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user  in seeder");
                }

            }

        }
    }
}
