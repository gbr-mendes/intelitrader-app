using Mobile.Models;
using Mobile.Models.Dtos;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IUserRegistrationAPI
    {
        HttpClient GetClient();
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(AddUpdateUserDto user);
        Task UpdateUser(string id, AddUpdateUserDto request);
        Task DeleteUser(string id);
    }
}
