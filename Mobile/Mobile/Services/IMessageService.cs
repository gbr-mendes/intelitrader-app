using System.Threading.Tasks;

namespace Mobile.Services
{
    public  interface IMessageService
    {
        Task ShowAsync(string message);
        Task ShowAsync(string message, string title);
    }
}
