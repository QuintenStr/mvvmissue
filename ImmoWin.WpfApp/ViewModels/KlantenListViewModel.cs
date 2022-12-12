using ImmoWin.Data;
using ImmoWin.Data.Services;
using Odisee.Common.Commands;
using Odisee.Common.Mediators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ImmoWin.WpfApp.ViewModels
{
    // niet gebruik gemaakt van de klasse KlantType want ik moet de enum Alles er bij toevoegen en vond geen manier om dit te doen met de bestaande klasse dus heb ik een nieuwe gemaakt
    internal enum KlantTypeFilter
    {
        Alles = 0,
        Onbekend = 1,
        Gast = 2,
        Koper = 3,
        Verkoper = 4,
        KoperEnVerkoper = 5
    }

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
                MessageBox.Show("Klanten List View : geselecteerde klant gewijzigd");
                Mediator.GetInstance().Notify(this, "Geselecteerde klant gewijzigd", GeselecteerdeKlant);
            }
        }

        private KlantTypeFilter _klantTypeFilter = KlantTypeFilter.Alles;
        public KlantTypeFilter KlantTypefilter
        {
            get { return _klantTypeFilter; }
            set
            {
                if (value != _klantTypeFilter)
                {
                    SetProperty(ref _klantTypeFilter, value);
                }
            }
        }

        public static IEnumerable<KlantTypeFilter> KlantTypeFilters => Enum.GetValues(typeof(KlantTypeFilter)).Cast<KlantTypeFilter>();


        private KlantTypeFilter _geselecteerdeFilter;

        public KlantTypeFilter GeselecteerdeFilter
        {
            get { return _geselecteerdeFilter; }
            set
            {
                SetProperty(ref _geselecteerdeFilter, value);
                switch (_geselecteerdeFilter)
                {
                    case KlantTypeFilter.Alles:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Alles);
                        break;
                    case KlantTypeFilter.Onbekend:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Onbekend);
                        break;
                    case KlantTypeFilter.Gast:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Gast);
                        break;
                    case KlantTypeFilter.Koper:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Koper);
                        break;
                    case KlantTypeFilter.Verkoper:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Verkoper);
                        break;
                    case KlantTypeFilter.KoperEnVerkoper:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.KoperEnVerkoper);
                        break;
                    default:
                        Klanten = KlantenRepository.GetKlantenFiltered((KlantenRepository.KlantTypeFilter)KlantTypeFilter.Alles);
                        break;
                }
            }
        }

        public RelayCommand KlantWijzigenCommand { get; set; }
        public RelayCommand KlantVerwijderenCommand { get; set; }
        
        public KlantenListViewModel()
        {
            IsEnabled = true;
            Klanten = KlantenRepository.GetKlanten();
            KlantWijzigenCommand = new RelayCommand(KlantWijzigenCommandExecute, KlantWijzigenCommandCanExecute);
            KlantVerwijderenCommand = new RelayCommand(KlantVerwijderenCommandExecute, KlantVerwijderenCommandCanExecute);
            Mediator.GetInstance().Register(this, "Geselecteerde klant wijzigen : opslaan");
            Mediator.GetInstance().Register(this, "Geselecteerde klant wijzigen : annuleren");
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

        private void KlantVerwijderenCommandExecute()
        {
            KlantenRepository.DeleteKlant(GeselecteerdeKlant);
            Klanten = KlantenRepository.GetKlanten();
        }

        private Boolean KlantVerwijderenCommandCanExecute()
        {
            return GeselecteerdeKlant != null;
        }

        public override void MediatorNotification(object from, string message, object data)
        {
            switch (message)
            {
                case "Geselecteerde klant wijzigen : opslaan":
                    GeselecteerdeKlant.Voornaam = (data as Persoon).Voornaam;
                    GeselecteerdeKlant.Familienaam = (data as Persoon).Familienaam;
                    (GeselecteerdeKlant as Klant).KlantType = (data as Klant).KlantType;
                    GeselecteerdeKlant.Adres.Straat = ((data as Persoon).Adres as Adres).Straat;
                    GeselecteerdeKlant.Adres.Nummer = ((data as Persoon).Adres as Adres).Nummer;
                    GeselecteerdeKlant.Adres.Gemeente = ((data as Persoon).Adres as Adres).Gemeente;
                    GeselecteerdeKlant.Adres.Postnummer = ((data as Persoon).Adres as Adres).Postnummer;

                    KlantenRepository.UpdateKlant(GeselecteerdeKlant);

                    IsEnabled = true;
                    break;
                case "Geselecteerde klant wijzigen : annuleren":
                    Mediator.GetInstance().Notify(this, "Geselecteerde klant gewijzigd", GeselecteerdeKlant);
                    IsEnabled = true;
                    break;
                default:
                    base.MediatorNotification(from, message, data);
                    break;
            }
        }
    }
}
