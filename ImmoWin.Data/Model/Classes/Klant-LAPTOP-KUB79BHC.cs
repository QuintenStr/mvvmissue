using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class Klant : Persoon, ICloneable
    {
        #region Fields & properties

        private KlantType _klantType = KlantType.Onbekend;

        public KlantType KlantType
        {
            get { return _klantType; }
            set
            {
                SetProperty(ref _klantType, value);
            }
        }

        #endregion

        #region Constructors
        public Klant(string familienaam, IAdres adres) 
            : base(familienaam, adres)
        {}

        public Klant(string voornaam, string familienaam, IAdres adres) 
            : base(voornaam, familienaam, adres)
        {}

        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString() + $" ({KlantType})";
        }


        #endregion
    }
}
