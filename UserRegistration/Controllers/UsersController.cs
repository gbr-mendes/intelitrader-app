using Microsoft.AspNetCore.Mvc;
using UserRegistration.Controllers.Responses;
using UserRegistration.Models;
using UserRegistration.Services.UserServices;
using UserRegistration.Dtos.User;

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
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
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
        public async Task<ActionResult<GetUserDto>> GetSingleUser(string id)
        {
            try
            {
                _logger.LogInformation("Get single user endpoint requested");
                GetUserDto user = await _userServices.GetSingleUser(id);
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
        public async Task<ActionResult<CustomResponse>> AddUser(AddUpdateUserDto user)
        {
            try
            {
                _logger.LogInformation("Add user endpoint requested");

                if (string.IsNullOrEmpty(user.Name))
                {
                    CustomResponse resp = new CustomResponse(400, $"Error: The field name is required");
                    _logger.LogError(resp.Message);
                    return BadRequest(resp);
                }
                else if (user.Age <= 0)
                {
                    CustomResponse resp = new CustomResponse(400, $"Error: The field age is required and must be greater than zero");
                    _logger.LogError(resp.Message);
                    return BadRequest(resp);
                }
                else
                {
                    await _userServices.AddUser(user);
                    CustomResponse resp = new CustomResponse(201, "User registered successfully");
                    return CreatedAtAction(nameof(AddUser), resp);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(exception: e, message: "Error creating an user");
                return StatusCode(500, new CustomResponse(500, $"An unexpected error has ocurred: {e.Message}"));
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, AddUpdateUserDto request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    CustomResponse resp = new CustomResponse(400, $"Error: The field name is required");
                    _logger.LogError(resp.Message);
                    return BadRequest(resp);
                }
                else if (request.Age <= 0)
                {
                    CustomResponse resp = new CustomResponse(400, $"Error: The field age is required and must be greater than zero");
                    _logger.LogError(resp.Message);
                    return BadRequest(resp);
                }
                else
                {
                    _logger.LogInformation("Update user endpoint requested");
                    bool updated = await _userServices.UpdateUser(id, request);
                    if (!updated)
                    {
                        return BadRequest(new CustomResponse(404, $"User with id {id} not found"));
                    }
                    return Ok(request);
                }
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