using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.ConsoleApp
{
    internal class Woning : IWoning
    {
        #region Fields & properties

        public IAdres Adres { get; set; }
        public Single Prijs { get; set; }
        public Persoon Eigenaar { get; set; }

        #endregion

        #region Constructors

        public Woning(Adres adres, Single? prijs = null, Persoon eigenaar = null)
        {
            Adres = adres;
            Prijs = prijs ?? 0;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{GetType().Name} - adr: {Adres?.ToString() ?? "<onbekend>"}, prijs: {Prijs}, eig.: {Eigenaar?.ToString() ?? "<onbekend>"}";
        }
        
        #region IComparable<IWoning>

        public virtual int CompareTo(IWoning other)
        {
            return Adres?.CompareTo(other.Adres) ?? -1;
        }

        #endregion IComparable<IWoning>


        #endregion
    }
}
