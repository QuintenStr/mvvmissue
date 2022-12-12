using ImmoWin.Data;
using Odisee.Common.Mediators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.WpfApp.ViewModels
{
    internal class KlantDetailViewModel : ViewModel
    {
        private Persoon _geslecteerdeKlant;

        public Persoon GeselecteerdeKlant
        {
            get { return _geslecteerdeKlant; }
            set
            {
                SetProperty(ref _geslecteerdeKlant, value);
            }
        }

        public KlantDetailViewModel()
        {
            Titel = null;
            IsEnabled = false;
            Mediator.GetInstance().Register(this, "Geselecteerde klant gewijzigd");
            Mediator.GetInstance().Register(this, "Geselecteerde klant wijzigen");
        }
        public override void MediatorNotification(object from, string message, object data)
        {
            switch (message)
            {
                case "Geselecteerde klant gewijzigd":
                    GeselecteerdeKlant = data as Persoon;
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
