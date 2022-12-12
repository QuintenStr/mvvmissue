using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Interfaces
{
    public interface IAppartement : IWoning, IComparable<IAppartement>
    {
        byte Verdieping { get; }
    }
}
