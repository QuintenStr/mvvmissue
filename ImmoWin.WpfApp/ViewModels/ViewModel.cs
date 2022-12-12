using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Odisee.Common.Mediators;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class ViewModel : ObservableObject, IMediatorSubscriber
    {
        private String _titel = "<geen titel>";

        public String Titel
        {
            get { return _titel; }
            set 
            { 
                if (SetProperty(ref _titel, value))
                {
                    OnPropertyChanged(nameof(TitelVisibility));
                } 
            }
        }

        public Visibility TitelVisibility
        {
            get { return String.IsNullOrEmpty(Titel) ? Visibility.Collapsed : Visibility.Visible;}
        }

        public Visibility IdVisibility
        {
            get { return Visibility.Collapsed; }
        }

        public virtual void MediatorNotification(object from, string message, object data)
        {
            MessageBox.Show($"{from} sends \"{message}\" with {data}", "MEDIATOR message", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private Boolean _isEnabled;

        public Boolean IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
            }
        }
    }
}