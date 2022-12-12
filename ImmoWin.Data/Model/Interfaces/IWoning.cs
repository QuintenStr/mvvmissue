using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Interfaces
{
    public interface IWoning : IComparable<IWoning>
    {
        Adres Adres { get; set; }
        Persoon Eigenaar { get; set; }
        float Prijs { get; set; }
    }
}
