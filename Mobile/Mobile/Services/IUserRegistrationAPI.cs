using Mobile.Models;
using Mobile.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    public interface IUserRegistrationAPI
    {
        HttpClient GetClient();
        Task<IEnumerable<User>> GetUsers();
        Task AddUser(AddUpdateUserDto user);
        void UpdateUser(string id, AddUpdateUserDto request);
        Task DeleteUser(string id);
    }
}
