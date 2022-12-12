using System;

namespace ImmoWin.ConsoleApp
{
    internal interface IWoning : IComparable<IWoning>
    {
        IAdres Adres { get; set; }
        Persoon Eigenaar { get; set; }
        float Prijs { get; set; }
    }
}