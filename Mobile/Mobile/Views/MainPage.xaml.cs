using Mobile.ViewsModels;
using System;
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

            _mainPageViewModel = new MainPageViewModel(Navigation);
            BindingContext = _mainPageViewModel;
        }

        protected override void OnAppearing()
        {
            _mainPageViewModel.PopulateUsers();
        }

        private async void Navigate_to_AddUser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddUpdateUserPage());
        }
    }
}