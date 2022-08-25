using Mobile.Models;
using Mobile.Models.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    internal class UserRegistrationAPI : IUserRegistrationAPI
    {
        private readonly List<User> Users = new List<User>
        {
            new User{Name="Gabriel", SurName="Mendes", Age=22 },
            new User{Name="Thiago", Age=33 },
            new User{Name="Brenda", SurName="Mendes", Age=16 },
        };
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task AddUser(AddUpdateUserDto user)
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.PostAsync("http://192.168.100.110:8000/api/Users", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUser(string id)
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.DeleteAsync($"http://192.168.100.110:8000/api/Users/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.GetAsync("http://192.168.100.110:8000/api/Users");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonString);
        }
        public User GetSingleUser(string id)
        {
            User user = Users.Find(u => u.Id == id);
            return user;
        }
        public void UpdateUser(string id, AddUpdateUserDto request)
        {
            User user = Users.Find(u => u.Id == id);
            if(user != null)
            {
                user.Name = request.Name;
                user.SurName = request.SurName;
                user.Age = request.Age;
            }
        }
    }
}
