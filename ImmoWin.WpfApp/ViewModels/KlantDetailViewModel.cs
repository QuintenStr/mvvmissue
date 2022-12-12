using ImmoWin.Data;
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
    internal class KlantDetailViewModel : ViewModel
    {
        public RelayCommand KlantWijzigenOpslaanCommand { get; set; }
        public RelayCommand KlantWijzigenAnnuleerCommand { get; set; }

        private Persoon _geslecteerdeKlant;

        public Persoon GeselecteerdeKlant
        {
            get { return _geslecteerdeKlant; }
            set
            {
                SetProperty(ref _geslecteerdeKlant, value);
                MessageBox.Show("Klant Data View Model : Geselecteerde klant instellen");
            }
        }

        public KlantDetailViewModel()
        {
            Titel = null;
            IsEnabled = false;

            Mediator.GetInstance().Register(this, "Geselecteerde klant gewijzigd");
            Mediator.GetInstance().Register(this, "Geselecteerde klant wijzigen");

            KlantWijzigenOpslaanCommand = new RelayCommand(KlantWijzigenOpslaanCommandExecute, KlantWijzigenOpslaanCommandCanExecute);
            KlantWijzigenAnnuleerCommand = new RelayCommand(KlantWijzigenAnnuleerCommandExecute, KlantWijzigenAnnuleerCommandCanExecute);
        }


        private void KlantWijzigenOpslaanCommandExecute()
        {
            Mediator.GetInstance().Notify(this, "Geselecteerde klant wijzigen : opslaan", GeselecteerdeKlant);
            IsEnabled = false;
        }

        private Boolean KlantWijzigenOpslaanCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }

        private void KlantWijzigenAnnuleerCommandExecute()
        {
            Mediator.GetInstance().Notify(this, "Geselecteerde klant wijzigen : annuleren", GeselecteerdeKlant);
            IsEnabled = false;
        }

        private Boolean KlantWijzigenAnnuleerCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }


        public override void MediatorNotification(object from, string message, object data)
        {
            switch (message)
            {
                case "Geselecteerde klant gewijzigd":
                    GeselecteerdeKlant = (data as Persoon);
                    break;
                case "Geselecteerde klant wijzigen":
                    //GeselecteerdeKlant = new Persoon((data as Persoon).Voornaam, (data as Persoon).Familienaam, null);
                    GeselecteerdeKlant = (data as Persoon).Clone() as Persoon;
                    IsEnabled = true;
                    break;
                default:
                    base.MediatorNotification(from, message, data);
                    break;
            }
        }
    }
}
