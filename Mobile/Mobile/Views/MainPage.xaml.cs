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

            _mainPageViewModel = new MainPageViewModel(Navigation, new UserRegistrationAPI());
            BindingContext = _mainPageViewModel;
        }

        protected override void OnAppearing()
        {
            _mainPageViewModel.PopulateUsers();
        }
    }
}