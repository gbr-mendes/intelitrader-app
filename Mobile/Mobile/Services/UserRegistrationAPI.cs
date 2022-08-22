using Mobile.Models;
using Mobile.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Mobile.Services
{
    internal class UserRegistrationAPI : IUserRegistrationAPI
    {
        private readonly ObservableCollection<User> Users = new ObservableCollection<User>
        {
            new User{Name="Gabriel", SurName="Mendes", Age=22 },
            new User{Name="Thiago", Age=33 },
            new User{Name="Brenda", SurName="Mendes", Age=16 },
        };
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "Application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public void AddUser(AddUpdateUserDto user)
        {
            User newUser = new User();

            newUser.Name = user.Name;
            newUser.SurName = user.SurName;
            newUser.Age = user.Age;

            Users.Add(newUser);
        }

        public void DeleteUser(string id)
        {
            User user = Users.ToList().Find(u => u.Id == id);
            if(user != null)
            {
                Users.Remove(user);
            }
        }

        public List<User> GetUsers()
        {
            return Users.ToList();
        }
        public User GetSingleUser(string id)
        {
            User user = Users.ToList().Find(u => u.Id == id);
            return user;
        }
        public void UpdateUser(string id, AddUpdateUserDto request)
        {
            User user = Users.ToList().Find(u => u.Id == id);
            if(user != null)
            {
                user.Name = request.Name;
                user.SurName = request.SurName;
                user.Age = request.Age;
            }
        }
    }
}
