using Microsoft.AspNetCore.Mvc;
using UserRegistration.Controllers.Responses;
using UserRegistration.Models;
using UserRegistration.Services.UserServices;

namespace UserRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _userServices.GetUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(string id)
        {
            User user = await _userServices.GetSingleUser(id);

            if (user == null)
            {
                return NotFound(new CustomResponse(404, $"User with id {id} not found"));
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<CustomResponse>> AddUser(User user)
        {
            await _userServices.AddUser(user);
            CustomResponse resp = new CustomResponse(201, "User registered successfully");
            return CreatedAtAction(nameof(AddUser), resp);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, User request)
        {
            User user = await _userServices.UpdateUser(id, request);
            if (user == null)
            {
                return BadRequest(new CustomResponse(404, $"User with id {id} not found"));
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResponse>> DeleteUser(string id)
        {
            User user = await _userServices.DeleteUser(id);
            if (user != null)
            {
                return Ok(new CustomResponse(200, "User deleted successfully"));
            }
            return BadRequest(new CustomResponse(400, $"User with id {id} not found"));
        }
    }
}