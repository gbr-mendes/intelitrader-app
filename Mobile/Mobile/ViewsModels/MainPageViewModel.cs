using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewsModels
{
    public class MainPageViewModel
    {
        private INavigation navigation;
        private readonly IUserRegistrationAPI Services;
        public INavigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }
        public ObservableCollection<User> Users { get; set; }
        public MainPageViewModel() { }
        public MainPageViewModel(INavigation navigation, IUserRegistrationAPI services)
        {
            Navigation = navigation;
            Services = services;
            Users = new ObservableCollection<User>();
        }
        public async void PopulateUsers()
        {
            try
            {
                Users.Clear();
                var users = await Services.GetUsers();
                foreach (User user in users)
                {
                    Users.Add(user);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Commands
        public ICommand NavigateCommand => new Command(NavigateToAddUserPage);
        void NavigateToAddUserPage()
        {
            Navigation.PushAsync(new AddUserPage());
        }
    }
}
