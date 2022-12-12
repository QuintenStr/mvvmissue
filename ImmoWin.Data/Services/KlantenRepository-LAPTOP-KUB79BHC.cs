using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Services
{
    public static class KlantenRepository
    {
        private static Klanten _klanten { get; set; }

        static KlantenRepository()
        {
            _klanten = new Klanten()
            {
                new Klant("Piet", "Pienter", new Adres("Stormstraat", "8", "1000", "Brussel")),
                new Klant("Bert", "Bibber", new Adres("Stormstraat", "10", "1000", "Brussel")),
                new Klant("Marcel", "Kiekeboe", new Adres("Stormstraat", "12", "1000", "Brussel")),
                new Klant("Charlotte", "Kiekeboe", null)
            };
            _klanten[3].Adres = _klanten[2].Adres;
        }

        public static Klanten GetKlanten()
        {
            return _klanten;
        }
    }
}
