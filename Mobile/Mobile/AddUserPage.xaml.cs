using Mobile.Models;
using Mobile.Models.Dtos;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        private readonly IUserRegistrationAPI _services;
        public AddUserPage()
        {
            InitializeComponent();
            _services = new UserRegistrationAPI();
        }

        private void addUserBtn_Clicked(object sender, EventArgs e)
        {
            AddUpdateUserDto user = new AddUpdateUserDto();
            user.Name = entryName.Text;
            user.SurName = entrySurName.Text;
            user.Age = int.Parse(entryAge.Text);

            _services.AddUser(user);
            CleanFields();
        }
        private void CleanFields()
        {
            entryName.Text = "";
            entrySurName.Text = "";
            entryAge.Text = "";
        }
    }
}