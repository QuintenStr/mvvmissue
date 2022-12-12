using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class WoningenViewModel : ViewModel
    {
        private ViewModel _woningenListViewModel;

        public ViewModel WoningenListViewModel
        {
            get { return _woningenListViewModel; }
            set
            {
                SetProperty(ref _woningenListViewModel, value);
            }
        }

        private ViewModel _woningDetailViewModel;

        public ViewModel WoningDetailViewModel
        {
            get { return _woningDetailViewModel; }
            set
            {
                SetProperty(ref _woningDetailViewModel, value);
            }
        }


        public WoningenViewModel()
        {
            Titel = "Woningen";

            WoningenListViewModel = new WoningenListViewModel();
            WoningDetailViewModel = new WoningDetailViewModel();
            //KlantenListViewModel.PropertyChanged += KlantenListViewModel_PropertyChanged;
        }
    }
}
