using Mobile.Models;
using Mobile.Models.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Services
{
    internal class UserRegistrationAPI : IUserRegistrationAPI
    {
        private readonly string _url = "http://192.168.100.110:8000/api";
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.GetAsync($"{_url}/Users");
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<User>>(jsonString);
        }
        public async Task AddUser(AddUpdateUserDto user)
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.PostAsync($"{_url}/Users", new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task UpdateUser(string id, AddUpdateUserDto request)
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.PutAsync($"{_url}/Users/{id}", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
        public async Task DeleteUser(string id)
        {
            HttpClient httpClient = GetClient();
            var response = await httpClient.DeleteAsync($"{_url}/Users/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
