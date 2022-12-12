using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public enum KlantType : byte
    {
        Onbekend = 1,
        Gast = 2,
        Koper = 3,
        Verkoper = 4,
        KoperEnVerkoper = 5
    }
}
