using Mobile.Models;
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
    public partial class AddUpdateUserPage : ContentPage
    {
        User User { get; set; }
        public AddUpdateUserPage(User user = null)
        {
            InitializeComponent();
            User = user;
            RenderForm();
            SetUserAsCommandParameter();
        }
        private void RenderForm()
        {
            if(User != null)
            {
                entryName.Text = User.Name;
                entrySurName.Text = User.SurName;
                entryAge.Text = User.Age.ToString();
                addUserUpdateBtn.Text = "Update";
                titlePage.Text = "Update User";
            }
        }
        private void SetUserAsCommandParameter()
        {
            if(User != null)
            {
                addUserUpdateBtn.CommandParameter = User;
            }
        }
    }
}