using Mobile.Helpers;
using Mobile.Models;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mobile.ViewsModels
{
    public class MainPageViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Properties
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<ListRow> Rows { get; set; } = new ObservableCollection<ListRow>();


        private bool _showUsersList = false;
        public bool ShowUsersList {
            get { return _showUsersList; }
            set
            {
                _showUsersList = value;
                NotifyPropertyChanged();
            }
        }

        private bool _showNoUsersLabel = true;
        public bool ShowNoUsersLabel {
            get { return _showNoUsersLabel; }
            set
            {
                _showNoUsersLabel = value;
                NotifyPropertyChanged();
            }
        }
        
        //Services declaration
        private readonly IUserRegistrationAPI APIService;

        // Constructors
        public MainPageViewModel()
        {
            APIService = DependencyService.Get<IUserRegistrationAPI>();

        }
        public void GenerateRows()
        {
            foreach(User user in Users)
            {
                ListRow row = new ListRow(user);
                Rows.Add(row);
            }
        }
        // methods
        public async void PopulateUsers()
        {
            try
            {
                Users.Clear();
                Rows.Clear();
                var users = await APIService.GetUsers();
                foreach (User user in users)
                {
                    Users.Add(user);
                }
                if(Users.Count > 0)
                {
                    ShowNoUsersLabel = false;
                    ShowUsersList = true;
                }else
                {
                    ShowNoUsersLabel = true;
                }
                GenerateRows();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        // Commands
        public ICommand LongPressCommand => new Command(ShowRowIcons);
        private void ShowRowIcons(object o)
        {
            ListRow row = o as ListRow;
            row.SetShowIcon(this);
        }

        public ICommand DeleteUserCommand => new Command(DeleteUser);
        private void DeleteUser(object o)
        {
            ListRow row = o as ListRow;
            try
            {
                APIService.DeleteUser(row.User.Id);
                Users.Remove(row.User);
                Rows.Remove(row);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
