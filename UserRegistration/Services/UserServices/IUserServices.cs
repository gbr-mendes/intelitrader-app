using UserRegistration.Models;

namespace UserRegistration.Services.UserServices
{
    public interface IUserServices
    {
        public Task<List<User>> GetUsers();
        public Task<User> GetSingleUser(string id);
        public Task<List<User>> AddUser(User user);
        public Task<User> UpdateUser(string id, User request);
        public Task<User> DeleteUser(string id);
    }
}