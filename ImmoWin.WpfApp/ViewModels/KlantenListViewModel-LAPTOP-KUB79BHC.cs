using ImmoWin.Data;
using ImmoWin.Data.Services;
using Odisee.Common.Commands;
using Odisee.Common.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class KlantenListViewModel : ViewModel
    {
        private Klanten _klanten;

        public Klanten Klanten
        {
            get { return _klanten; }
            set
            {
                SetProperty(ref _klanten, value);
            }
        }

        private Persoon _geslecteerdeKlant;

        public Persoon GeselecteerdeKlant
        {
            get { return _geslecteerdeKlant; }
            set
            {
                SetProperty(ref _geslecteerdeKlant, value);
                Mediator.GetInstance().Notify(this, "Geselecteerde klant gewijzigd", GeselecteerdeKlant);
            }
        }

        public RelayCommand KlantWijzigenCommand { get; set; }

        public KlantenListViewModel()
        {
            IsEnabled = true;
            Klanten = KlantenRepository.GetKlanten();
            KlantWijzigenCommand = new RelayCommand(KlantWijzigenCommandExecute, KlantWijzigenCommandCanExecute);
        }


        private void KlantWijzigenCommandExecute()
        {
            Mediator.GetInstance().Notify(this, "Geselecteerde klant wijzigen", GeselecteerdeKlant);
            IsEnabled = false;
        }

        private Boolean KlantWijzigenCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }


    }
}
