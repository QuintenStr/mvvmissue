using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data
{
    public enum KlantType : byte
    {
        Onbekend,
        Gast,
        Koper,
        Verkoper,
        KoperEnVerkoper = 5
    }
}
