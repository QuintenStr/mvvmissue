using System;
using System.ComponentModel;

namespace ImmoWin.Data
{
    public interface IAdres : IComparable<IAdres>, ICloneable
    {
        string Gemeente { get; set; }
        string Nummer { get; set; }
        string Postnummer { get; set; }
        string Straat { get; set; }
    }
}