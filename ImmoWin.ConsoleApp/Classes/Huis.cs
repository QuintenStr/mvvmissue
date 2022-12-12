using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.ConsoleApp
{
    internal class Huis : Woning
    {
        #region Fields & properties

        public HuisType Type { get; set; }

        #endregion

        #region Constructors

        public Huis(HuisType type, Adres adres, Single prijs = 0)
            : base(adres, prijs)
        {
            Type = type;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{Type} {base.ToString()}";
        }

        #endregion
    }
}
