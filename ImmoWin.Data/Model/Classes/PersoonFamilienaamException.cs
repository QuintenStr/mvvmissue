using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    internal class PersoonFamilienaamException : PersoonException
    {
        public PersoonFamilienaamException()
            : base("Naam mag niet leeg zijn.")
        {}
    }
}
