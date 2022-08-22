using Mobile.Models;
using Mobile.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mobile.Services
{
    internal interface IUserRegistrationAPI
    {
        HttpClient GetClient();
        List<User> GetUsers();
        void AddUser(AddUpdateUserDto user);
        void UpdateUser(string id, AddUpdateUserDto request);
        void DeleteUser(string id);
    }
}
