using Odisee.Common.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class ImmoWinViewModel : ViewModel
    {
        public RelayCommand AfsluitenCommand { get; set; }
        public RelayCommand KlantenCommand { get; set; }
        public RelayCommand IetsAndersCommand { get; set; }


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
            IetsAndersCommand = new RelayCommand(IetsAndersCommandExecute);
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

        private void IetsAndersCommandExecute()
        {
            GegevensViewModel = null;
        }
        
    }
}
