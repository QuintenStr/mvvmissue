using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class KlantenViewModel : ViewModel
    {
        private ViewModel _klantenListViewModel;

        public ViewModel KlantenListViewModel
        {
            get { return _klantenListViewModel; }
            set
            {
                SetProperty(ref _klantenListViewModel, value);
            }
        }

        private ViewModel _klantDetailViewModel;

        public ViewModel KlantDetailViewModel
        {
            get { return _klantDetailViewModel; }
            set
            {
                SetProperty(ref _klantDetailViewModel, value);
            }
        }


        public KlantenViewModel()
        {
            Titel = "Klanten";

            KlantenListViewModel = new KlantenListViewModel();
            KlantDetailViewModel = new KlantDetailViewModel();
            //KlantenListViewModel.PropertyChanged += KlantenListViewModel_PropertyChanged;
        }

        //private void KlantenListViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    switch (e.PropertyName)
        //    {
        //        case "GeselecteerdeKlant":
        //            KlantDetailViewModel = new KlantDetailViewModel();
        //            (KlantDetailViewModel as KlantDetailViewModel).GeselecteerdeKlant = (KlantenListViewModel as KlantenListViewModel).GeselecteerdeKlant;
        //            break;
        //    }
        //}
    }
}
