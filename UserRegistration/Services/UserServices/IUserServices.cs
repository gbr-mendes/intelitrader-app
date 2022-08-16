using UserRegistration.Models;
using UserRegistration.Dtos.User;

namespace UserRegistration.Services.UserServices
{
    public interface IUserServices
    {
        public Task<List<GetUserDto>> GetUsers();
        public Task<GetUserDto> GetSingleUser(string id);
        public Task<bool> AddUser(AddUserDto user);
        public Task<bool> UpdateUser(string id, User request);
        public Task<bool> DeleteUser(string id);
    }
}