using UserRegistration.Models;
namespace UserRegistration.Tests.MockData
{
    public class UsersMockData
    {
        private static readonly List<User> _users = new List<User>{
                new User("uniq-id", "Gabriel", "Mendes", 22),
                new User{
                    Name = "Thiago",
                    Age = 33
                },
                new User{
                    Name = "Leticia",
                    SurName = "Fernandes",
                    Age = 26
                },
                new User{
                    Name = "Brenda",
                    Age = 15
                },

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