using UserRegistration.Models;
namespace UserRegistration.Tests.MockData
{
    public class UsersMockData
    {
        private static readonly List<User> _users = new List<User>
            {
                new User("uniq_id","Gabriel","Mendes", 22),
                new User("Thiago",33),
                new User("Leticia","Fernandes",26),
                new User("Brenda", 15)
            };
        public static List<User> GetUsers()
        {
            return _users;
        }
        public static User? GetSingleUser(string id)
        {
            return _users.Find(user => user.Id == id);
        }
        public static bool AddUser(User user)
        {
            _users.Add(user);
            return true;
        }
    }
}