using Mobile.Models;
using Mobile.Models.Dtos;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewsModels
{
    public class AddUserViewModel
    {
        private readonly IUserRegistrationAPI Services;
        public AddUserViewModel() 
        {
            Services = new UserRegistrationAPI();
        }
        public ICommand AddUserCommand => new Command(AddUser);
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age { get; set; }
        public async void AddUser()
        {
            try
            {
                AddUpdateUserDto newUser = new AddUpdateUserDto(Name, SurName, Age);
                await Services.AddUser(newUser);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
