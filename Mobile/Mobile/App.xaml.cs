using Mobile.Services;
using Mobile.Views;
using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<IUserRegistrationAPI, UserRegistrationAPI>();
            DependencyService.Register<IMessageService, MessageService>();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
