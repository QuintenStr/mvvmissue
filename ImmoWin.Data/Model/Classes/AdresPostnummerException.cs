using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class AdresPostnummerException : AdresException
    {
        public AdresPostnummerException()
           : base("Postnummer mag niet leeg zijn.")
        { }
    }
}
