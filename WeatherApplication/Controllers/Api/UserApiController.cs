using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WeatherApplication.Data;

namespace WeatherApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : Controller
    {
        private DataContext _dataContext;
        public UserApiController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dataContext.Users.ToList());
        }
    }
}
