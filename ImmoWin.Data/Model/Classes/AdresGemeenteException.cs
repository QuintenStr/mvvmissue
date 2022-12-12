using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class AdresGemeenteException : AdresException
    {
        public AdresGemeenteException()
            : base("Adres mag niet leeg zijn.") 
        { }
    }
}
