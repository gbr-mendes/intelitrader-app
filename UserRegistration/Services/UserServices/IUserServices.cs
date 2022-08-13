using UserRegistration.Models;

namespace UserRegistration.Services.UserServices
{
    public interface IUserServices
    {
        public List<User> GetUsers();
        public User GetSingleUser(string id);
        public List<User> AddUser(User user);
        public User UpdateUser(string id, User request);
        public User DeleteUser(string id);
    }
}