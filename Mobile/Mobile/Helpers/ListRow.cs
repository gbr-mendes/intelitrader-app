using Mobile.Models;
using Mobile.ViewsModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mobile.Helpers
{
    public class ListRow: INotifyPropertyChanged
    {
        public User User { get; set; }
        public bool ShowIcons { get; set; }

        public ListRow(User user)
        {
            User = user;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(object viewModel, [CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(viewModel, new PropertyChangedEventArgs(propertyName));
        }

        public void SetShowIcon(object viewModel)
        {
            ShowIcons = !ShowIcons;
            NotifyPropertyChanged(viewModel, nameof(ShowIcons));
        }
    }
}
