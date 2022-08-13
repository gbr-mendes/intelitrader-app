using UserRegistration.Models;


namespace UserRegistration.Services.UserServices
{
    public class UserServices : IUserServices
    {
        private static List<User> _users = new List<User>()
            {
                new User(){Name="Gabriel", Age=22},
                new User(){Name="Thiago", Age=35}
            };
        public List<User> GetUsers()
        {
            return _users;
        }
        public User GetSingleUser(string id)
        {
            return _users.Find(user => user.Id == id);
        }
        public List<User> AddUser(User user)
        {
            _users.Add(user);
            return _users;
        }
        public User UpdateUser(string id, User request)
        {
            User? user = _users.Find(user => user.Id == id);
            if (user != null)
            {
                user.Name = request.Name;
                user.SurName = request.SurName;
                user.Age = request.Age;
            }
            return user;
        }
        public User DeleteUser(string id)
        {
            User? user = _users.Find(user => user.Id == id);
            if (user != null)
            {
                _users.Remove(user);
                return user;
            }
            return user;
        }
    }
}