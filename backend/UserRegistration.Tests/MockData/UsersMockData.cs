using UserRegistration.Dtos.User;

namespace UserRegistration.Tests.MockData
{
    public class UsersMockData
    {
        private static readonly List<GetUserDto> _getUsers = new List<GetUserDto>
            {
                new GetUserDto{Id = "uniq_id",Name="John",SurName="Doe", Age=22}
            };
        private static readonly List<AddUpdateUserDto> _addUpdateUsers = new List<AddUpdateUserDto>
            {
                new AddUpdateUserDto{Name="John",SurName="Doe", Age=22}
            };
        public static List<GetUserDto> GetUsers()
        {
            return _getUsers;
        }
        public static GetUserDto GetSingleUser(string id)
        {
            return _getUsers.Find(user => user.Id == id);
        }
        public static bool AddUser(AddUpdateUserDto user)
        {
            _addUpdateUsers.Add(user);
            return true;
        }
        public static bool UpdateUser(string id, AddUpdateUserDto request)
        {
            _addUpdateUsers[0].SetId("uniq_id");
            AddUpdateUserDto user = _addUpdateUsers.Find(u => u.GetId() == id);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public static bool DeleteUser(string id)
        {
            _addUpdateUsers[0].SetId("uniq_id");
            GetUserDto user = _getUsers.Find(u => u.Id == id);
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}