using Odisee.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmoWin.Data.Model.Classes;
using System.Data.Entity;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class ImmoWinViewModel : ViewModel
    {
        public RelayCommand AfsluitenCommand { get; set; }
        public RelayCommand KlantenCommand { get; set; }
        public RelayCommand KlantenNieuwCommand { get; set; }
        public RelayCommand WoningenCommand { get; set; }
        public RelayCommand WoningenNieuwCommand { get; set; }


        private ViewModel _gegevensViewModel;

        public ViewModel GegevensViewModel
        {
            get { return _gegevensViewModel; }
            set { SetProperty(ref _gegevensViewModel, value); }
        }

        public ImmoWinViewModel()
        {
            AfsluitenCommand = new RelayCommand(AfsluitenCommandExecute);
            KlantenCommand = new RelayCommand(KlantenCommandExecute, KlantenCommandCanExecute);
            KlantenNieuwCommand = new RelayCommand(KlantenNieuwCommandExecute, KlantenNieuwCommandCanExecute);
            WoningenCommand = new RelayCommand(WoningenCommandExecute, WoningenCommandCanExecute);
            WoningenNieuwCommand = new RelayCommand(WoningenNieuwCommandExecute, WoningenNieuwCommandCanExecute);
        }

        private void AfsluitenCommandExecute()
        {
            App.Current.Shutdown();
        }

        private void KlantenCommandExecute()
        {
            GegevensViewModel = new KlantenViewModel();
        }

        private Boolean KlantenCommandCanExecute()
        {
            return !(GegevensViewModel is KlantenViewModel);
        }

        private void KlantenNieuwCommandExecute()
        {
            GegevensViewModel = new KlantNieuwViewModel();
        }

        private Boolean KlantenNieuwCommandCanExecute()
        {
            return !(GegevensViewModel is KlantNieuwViewModel);
        }

        private void WoningenCommandExecute()
        {
            GegevensViewModel = new WoningenViewModel();
        }

        private Boolean WoningenCommandCanExecute()
        {
            return !(GegevensViewModel is WoningenViewModel);
        }

        private void WoningenNieuwCommandExecute()
        {
            GegevensViewModel = new WoningenNieuwViewModel();
        }

        private Boolean WoningenNieuwCommandCanExecute()
        {
            return !(GegevensViewModel is WoningenNieuwViewModel);
        }

    }
}
