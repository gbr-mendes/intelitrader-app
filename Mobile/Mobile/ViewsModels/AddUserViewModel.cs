using Mobile.Models;
using Mobile.Models.Dtos;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewsModels
{
    public class AddUserViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly IUserRegistrationAPI APIService;
        public AddUserViewModel() 
        {
            APIService = DependencyService.Get<IUserRegistrationAPI>();
        }

        public ICommand AddUserCommand => new Command(AddUser);
        
        private string _name = "";
        public string Name
        { 
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        private string _surName = "";
        public string SurName
        {
            get { return _surName; }
            set
            {
                _surName = value;
                NotifyPropertyChanged();
            }
        }
        private int _age = 0;
        public int Age 
        { 
            get { return _age; }
            set 
            {
                _age = value;
                NotifyPropertyChanged();
            }
        }
        public async void AddUser()
        {
            try
            {
                AddUpdateUserDto newUser = new AddUpdateUserDto(Name, SurName, Age);
                await APIService.AddUser(newUser);
                CleanFields();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void CleanFields()
        {
            Name = "";
            SurName = "";
            Age = 0;
        }
    }
}
