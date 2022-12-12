using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Odisee.Common;
using Odisee.Common.Observables;

namespace ImmoWin.Data
{
    [Table("Adressen")]
    public class Adres : ObservableObject, IAdres
    {
        #region Fields & properties

        //public String Straat { get; }
        //public String Nummer { get; }
        //public String Postnummer { get; }
        //public String Gemeente { get; }
        public int Id { get; set; }

        private String _straat;

        public String Straat
        {
            get { return _straat; }
            set
            {
                SetProperty(ref _straat, value);
            }
        }

        private String _nummer;

        public String Nummer
        {
            get { return _nummer; }
            set
            {
                SetProperty(ref _nummer, value);
            }
        }

        private String _postnummer;

        public String Postnummer
        {
            get { return _postnummer; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new AdresPostnummerException();
                SetProperty(ref _postnummer, value);
            }
        }

        private String _gemeente;

        public String Gemeente
        {
            get { return _gemeente; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new AdresGemeenteException();
                SetProperty(ref _gemeente, value);
            }
        }

        #endregion

        #region Constructors

        public Adres(String straat, String nummer, String postnummer, String gemeente)
        {
            Straat = straat;
            Nummer = nummer;
            Postnummer = postnummer;
            Gemeente = gemeente;
        }

        public Adres()
        {

        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Straat} {Nummer}, {Postnummer} {Gemeente}";
        }

        #region IComparable<IAdres>

        public int CompareTo(IAdres other)
        {
            int resultaat;

            if ((resultaat = Postnummer?.CompareTo(other.Postnummer) ?? -1) == 0)
                if ((resultaat = Gemeente?.CompareTo(other.Gemeente) ?? -1) == 0)
                    if ((resultaat = Straat?.CompareTo(other.Straat) ?? -1) == 0)
                        resultaat = Nummer?.CompareTo(other.Nummer) ?? -1;

            return resultaat;
        }

        #endregion IComparable<IAdres>

        public object Clone()
        {
            Adres clone = MemberwiseClone() as Adres;

            return clone;
        }

        #endregion
    }
}
