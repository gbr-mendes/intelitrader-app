using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Users : ControllerBase
    {
        public static List<User> users = new List<User>()
            {
                new User(){Name="Gabriel", Age=22},
                new User(){Name="User 2", Age=35}
            };
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<Responses.HttpResponse>> AddUser(User user)
        {
            users.Add(user);
            Responses.HttpResponse resp = new Responses.HttpResponse(200, "User registered successfully");
            return Ok(resp);
        }
    }
}