using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Odisee.Common.Observables
{
    public class ObservableObject : INotifyPropertyChanged
    {
        #region Fields & properties

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Constructors
        #endregion

        #region Methods

        protected Boolean SetProperty<T>(ref T field, T value, [CallerMemberName] String propertyName = null)
        {
            Boolean propertyChanged;
            if (propertyChanged = !Object.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
            return propertyChanged;
        }

        protected virtual void OnPropertyChanged(String propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion
    }
}
