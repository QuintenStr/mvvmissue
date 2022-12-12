using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public class AdresException : Exception
    {
        public AdresException(String bericht)
            : base(bericht) { }
    }
}
