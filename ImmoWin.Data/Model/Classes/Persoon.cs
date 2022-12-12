using Odisee.Common;
using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    [Table("Personen")]
    public class Persoon : ObservableObject, IPersoon
    {
        #region Fields & properties

        //public String Voornaam { get; set; }
        //public String Familienaam { get; set; }
        //public IAdres Adres { get; set; }
        //public List<IWoning> Eigendommen { get; }
        [Key]
        public int Id { get; set; }

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

        private Adres _adres;

        public Adres Adres
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

        public Persoon(String voornaam, String familienaam, Adres adres)
        {
            Voornaam = voornaam;
            Familienaam = familienaam;
            Adres = adres;
            //Eigendommen = new List<IWoning>();
        }
        public Persoon(String familienaam, Adres adres) : this(null, familienaam, adres)
        {
        }

        public Persoon(Adres adres)
        {
            Adres = adres;
        }

        public Persoon()
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            String resultaat = $"{Voornaam ?? "<onbekend>"} {Familienaam ?? "<onbekend>"}";
            return resultaat;
        }

        public object Clone()
        {
            Persoon clone = MemberwiseClone() as Persoon;
            clone.Adres = Adres.Clone() as Adres;

            return clone;
        }

        #endregion
    }
}
