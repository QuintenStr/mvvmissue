using ImmoWin.Data.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Classes
{
    [Table("Appartementen")]
    public class Appartement : Woning, IAppartement
    {
        #region Fields & properties

        public Byte Verdieping { get; set; }

        #endregion

        #region Constructors

        public Appartement(Byte verdieping, Adres adres, Single prijs = 0)
            : base(adres, prijs)
        {
            Verdieping = verdieping;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{base.ToString()}, verdieping: {Verdieping}";
        }

        #region IComparable<IWoning>

        public override int CompareTo(IWoning other)
        {
            Debug.WriteLine($"{GetType().Name} [{this}].CompareTo([{other}])");
            int resultaat;
            if ((resultaat = base.CompareTo(other)) == 0)
                if (other is IAppartement appartement)
                    resultaat = CompareTo(appartement);
            return resultaat;
        }

        #endregion IComparable<IWoning>

        #region IComparable<IAppartement>

        public int CompareTo(IAppartement other)
        {
            Debug.WriteLine($"{GetType().Name} [{this}].CompareTo([{other}])");
            int resultaat;
            if ((resultaat = base.CompareTo(other)) == 0)
                resultaat = Verdieping.CompareTo(other.Verdieping);
            return resultaat;
        }

        #endregion IComparable<IAppartement>

        #endregion
    }
}
