using System;

namespace ImmoWin.Data
{
    public interface IPersoon : ICloneable
    {
        IAdres Adres { get; set; }
        string Familienaam { get; set; }
        string Voornaam { get; set; }
    }
}