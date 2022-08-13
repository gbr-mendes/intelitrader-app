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
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(_userServices.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetSingleUser(string id)
        {
            User user = _userServices.GetSingleUser(id);

            if (user == null)
            {
                return NotFound(new CustomResponse(404, $"User with id {id} not found"));
            }
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<CustomResponse> AddUser(User user)
        {
            _userServices.AddUser(user);
            CustomResponse resp = new CustomResponse(201, "User registered successfully");
            return CreatedAtAction(nameof(AddUser), resp);
        }

        [HttpPut("{id}")]
        public ActionResult<User> UpdateUser(string id, User request)
        {
            User user = _userServices.UpdateUser(id, request);
            if (user == null)
            {
                return BadRequest(new CustomResponse(404, $"User with id {id} not found"));
            }
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult<CustomResponse> DeleteUser(string id)
        {
            User user = _userServices.DeleteUser(id);
            if (user != null)
            {
                return Ok(new CustomResponse(200, "User deleted successfully"));
            }
            return BadRequest(new CustomResponse(400, $"User with id {id} not found"));
        }
    }
}