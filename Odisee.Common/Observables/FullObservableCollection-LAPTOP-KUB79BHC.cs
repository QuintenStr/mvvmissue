using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odisee.Common.Observables
{
    public class FullObservableCollection<T> : ObservableCollection<T> where T : ObservableObject
    {       
        #region Constructors
        
        public FullObservableCollection()
        {
            this.CollectionChanged += FullObservableCollection_CollectionChanged;
        }

        #endregion

        #region Methods

        private void FullObservableCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (ObservableObject item in e.NewItems)
                    item.PropertyChanged += Item_PropertyChanged;
            }
            if (e.OldItems != null)
            {
                foreach (ObservableObject item in e.OldItems)
                    item.PropertyChanged -= Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.OnCollectionChanged(new System.Collections.Specialized.NotifyCollectionChangedEventArgs(System.Collections.Specialized.NotifyCollectionChangedAction.Reset));
        }

        #endregion
    }
}
