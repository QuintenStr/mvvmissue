using ImmoWin.Data;
using ImmoWin.Data.Services;
using Odisee.Common.Commands;
using Odisee.Common.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class KlantNieuwViewModel : ViewModel
    {
        public RelayCommand ToevoegenCommand { get; set; }

        public KlantNieuwViewModel()
        {
            Titel = "Klant toevoegen";
            initKlant();
            ToevoegenCommand = new RelayCommand(ToevoegenCommandExecute, ToevoegenCommandCanExecute);
        }

        private void initKlant()
        {
            NieuwAdres = new Adres();
            NieuweKlant = new Klant(NieuwAdres);
        }

        private Adres _nieuwAdres;

        public Adres NieuwAdres
        {
            get { return _nieuwAdres; }
            set
            {
                SetProperty(ref _nieuwAdres, value);
            }
        }

        private Klant _nieuweKlant;

        public Klant NieuweKlant
        {
            get { return _nieuweKlant; }
            set
            {
                SetProperty(ref _nieuweKlant, value);
            }
        }

        private void ToevoegenCommandExecute()
        {
            KlantenRepository.AddKlant(NieuweKlant);
            initKlant();
        }

        private Boolean ToevoegenCommandCanExecute()
        {
            // form checking?
            return true;
        }
    }
}
