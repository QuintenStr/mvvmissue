using System;

namespace ImmoWin.Data
{
    public interface IPersoon : ICloneable
    {
        Adres Adres { get; set; }
        string Familienaam { get; set; }
        string Voornaam { get; set; }
    }
}