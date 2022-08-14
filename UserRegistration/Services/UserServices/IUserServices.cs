using UserRegistration.Models;

namespace UserRegistration.Services.UserServices
{
    public interface IUserServices
    {
        public Task<List<User>> GetUsers();
        public Task<User?> GetSingleUser(string id);
        public Task<bool> AddUser(User user);
        public Task<bool> UpdateUser(string id, User request);
        public Task<bool> DeleteUser(string id);
    }
}