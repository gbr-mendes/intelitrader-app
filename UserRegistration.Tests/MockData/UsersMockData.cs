using UserRegistration.Models;
using UserRegistration.Dtos.User;

namespace UserRegistration.Tests.MockData
{
    public class UsersMockData
    {
        private static readonly List<GetUserDto> _getUsers = new List<GetUserDto>
            {
                new GetUserDto{Id = "uniq_id",Name="Gabriel",SurName="Mendes", Age=22},
                new GetUserDto{Name="Thiago",Age=33},
                new GetUserDto{Name="Leticia",SurName="Fernandes",Age=26},
                new GetUserDto{Name="Brenda", Age=15}
            };
        private static readonly List<AddUserDto> _addUsers = new List<AddUserDto>
            {
                new AddUserDto{Name="Gabriel",SurName="Mendes", Age=22},
                new AddUserDto{Name="Thiago",Age=33},
                new AddUserDto{Name="Leticia",SurName="Fernandes",Age=26},
                new AddUserDto{Name="Brenda", Age=15}
            };
        public static List<GetUserDto> GetUsers()
        {
            return _getUsers;
        }
        public static GetUserDto GetSingleUser(string id)
        {
            return _getUsers.Find(user => user.Id == id);
        }
        public static bool AddUser(AddUserDto user)
        {
            _addUsers.Add(user);
            return true;
        }
    }
}