using System.Threading.Tasks;

namespace Mobile.Services
{
    public class MessageService : IMessageService
    {
        public async Task ShowAsync(string message)
        {
            await App.Current.MainPage.DisplayAlert("User Registration", message, "Ok");
        }
        public async Task ShowAsync(string message, string title)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }
    }
}

