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
        private readonly ILogger _logger;
        public UsersController(IUserServices userServices, ILogger<UsersController> logger)
        {
            _userServices = userServices;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            try
            {
                _logger.LogInformation("Get users endpoint requested");
                return Ok(await _userServices.GetUsers());
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error retrieving users");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetSingleUser(string id)
        {
            try
            {
                _logger.LogInformation("Get single user endpoint requested");
                User? user = await _userServices.GetSingleUser(id);
                if (user == null)
                {
                    return NotFound(new CustomResponse(404, $"User with id {id} not found"));
                }
                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error retrieving single user");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomResponse>> AddUser(User user)
        {
            try
            {
                _logger.LogInformation("Add user endpoint requested");
                await _userServices.AddUser(user);
                CustomResponse resp = new CustomResponse(201, "User registered successfully");
                return CreatedAtAction(nameof(AddUser), resp);
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error creating an user");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, User request)
        {
            try
            {
                _logger.LogInformation("Update user endpoint requested");
                bool updated = await _userServices.UpdateUser(id, request);
                if (!updated)
                {
                    return BadRequest(new CustomResponse(404, $"User with id {id} not found"));
                }
                return Ok(request);
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error updating an user");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomResponse>> DeleteUser(string id)
        {
            try
            {
                _logger.LogInformation("Delete user endpoint requested");
                bool deleted = await _userServices.DeleteUser(id);
                if (deleted)
                {
                    return Ok(new CustomResponse(200, "User deleted successfully"));
                }
                return BadRequest(new CustomResponse(400, $"User with id {id} not found"));
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error deleting an user");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }
    }
}