using Odisee.Common;
using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class Persoon : ObservableObject, IPersoon
    {
        #region Fields & properties

        //public String Voornaam { get; set; }
        //public String Familienaam { get; set; }
        //public IAdres Adres { get; set; }
        //public List<IWoning> Eigendommen { get; }

        private String _voornaam;

        public String Voornaam
        {
            get { return _voornaam; }
            set
            {
                SetProperty(ref _voornaam, value);
            }
        }

        private String _familienaam;

        public String Familienaam
        {
            get { return _familienaam; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new PersoonFamilienaamException();
                SetProperty(ref _familienaam, value);
            }
        }

        private IAdres _adres;

        public IAdres Adres
        {
            get { return _adres; }
            set
            {
                SetProperty(ref _adres, value);
                if (Adres != null)
                    (Adres as Adres).PropertyChanged += Persoon_PropertyChanged;
            }
        }

        private void Persoon_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            OnPropertyChanged("Adres");
        }

        //private FullObservableCollection<Woning> _eigendommen;

        //public FullObservableCollection<Woning> Eigendommen
        //{
        //    get { return _eigendommen; }
        //    set { _eigendommen = value; }
        //}

        #endregion

        #region Constructors

        public Persoon(String voornaam, String familienaam, IAdres adres)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Adres = adres;
            //Eigendommen = new List<IWoning>();
        }
        public Persoon(String familienaam, IAdres adres)
            : this(null, familienaam, adres)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            String resultaat = $"{Familienaam} adres: {Adres?.ToString() ?? "<onbekend>"}";

            if (Voornaam != null)
                return $"{Voornaam} {resultaat}";
            return resultaat;
        }

        public object Clone()
        {
            Persoon clone = MemberwiseClone() as Persoon;
            clone.Adres = Adres.Clone() as IAdres;

            return clone;
        }

        #endregion
    }
}
