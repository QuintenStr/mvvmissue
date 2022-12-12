using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    [Table("Klanten")]
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
        public Klant(string familienaam, Adres adres) : base(familienaam, adres)
        {}

        public Klant(string voornaam, string familienaam, Adres adres, KlantType type) : base(voornaam, familienaam, adres)
        {
            KlantType = type;
        }
        public Klant(Adres adres) : base(adres)
        {

        }

        public Klant()
        {

        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString() + $" ({KlantType})";
        }


        #endregion
    }
}
