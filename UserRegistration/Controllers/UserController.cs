using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserRegistration.Models;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Users : ControllerBase
    {
        public static List<User> _users = new List<User>()
            {
                new User(){Name="Gabriel", Age=22},
                new User(){Name="User 2", Age=35}
            };

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(_users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(string id)
        {
            User? user = _users.Find(user => user.Id == id);

            if (user == null)
            {
                return NotFound(new Responses.HttpResponse(404, $"User with id {id} not found"));
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<Responses.HttpResponse>> AddUser(User user)
        {
            _users.Add(user);
            Responses.HttpResponse resp = new Responses.HttpResponse(201, "User registered successfully");
            return Ok(resp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, User request)
        {
            User? user = _users.Find(user => user.Id == id);
            if (user == null)
            {
                return BadRequest(new Responses.HttpResponse(404, $"User with id {id} not found"));
            }
            user.Name = request.Name;
            user.SurName = request.SurName;
            user.Age = request.Age;

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Responses.HttpResponse>> DeleteUser(string id)
        {
            User? user = _users.Find(user => user.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return new Responses.HttpResponse(200, "User deleted successfully");
            }
            return BadRequest(new Responses.HttpResponse(400, $"User with id {id} not found"));
        }
    }
}