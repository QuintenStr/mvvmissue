using ImmoWin.Data.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Interfaces
{
    public interface IHuis : IWoning
    {
        HuisType Type { get; }
    }
}
