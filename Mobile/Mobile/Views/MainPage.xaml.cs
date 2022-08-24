using Mobile.Services;
using Mobile.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _mainPageViewModel;

        public MainPage()
        {
            InitializeComponent();

            _mainPageViewModel = new MainPageViewModel();
            BindingContext = _mainPageViewModel;
        }

        protected override void OnAppearing()
        {
            _mainPageViewModel.PopulateUsers();
        }

        private async void Navigate_to_AddUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUserPage());
        }
    }
}