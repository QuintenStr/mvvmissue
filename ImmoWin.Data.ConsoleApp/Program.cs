using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImmoWin.Data;

namespace ImmoWin.Data.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestAdres();
            TestPersoon();

            Console.Clear();
            Console.Write($"\n\nDruk toets om te stoppen...");
            Console.ReadKey(true);
        }

        static void TestAdres()
        {
            Console.Clear();
            Console.WriteLine("Test Adres.\n-----------\n");

            Adres adres = null;

            try
            {
                adres = new Adres("Stormstraat", "8", "1000", "Brussel");
                adres.PropertyChanged += X_PropertyChanged;
                Console.WriteLine($"adres: {adres}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            try
            {
                Console.WriteLine($"adres.Straat = adres.Straat.ToUpper()");
                adres.Straat = adres.Straat.ToUpper();
                Console.WriteLine("adres.Straat = null:");
                adres.Straat = null;
                Console.WriteLine("adres.Nummer = null:");
                adres.Nummer = null;
                Console.WriteLine("adres.Postnummer = null:");
                adres.Postnummer = null;
                Console.WriteLine($"adres: {adres}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.GetType().Name}: {ex.Message}");
            }
            Console.Write($"\n\nEinde test Adres.\nDruk toets om verder te gaan...");
            Console.ReadKey(true);
        }

        private static void X_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine($"\tPropertyChanged {e.PropertyName}: {sender}");
        }

        static void TestPersoon()
        {
            Console.Clear();
            Console.WriteLine("Test Persoon.\n-------------\n");

            Adres adres = new Adres("Stormstraat", "8", "1000", "Brussel");
            Persoon persoon = null;

            try
            {
                persoon = new Persoon("Piet", "Pienter", adres);
                persoon.PropertyChanged += X_PropertyChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.GetType().Name}: {ex.Message}");
            }

            try
            {
                Console.WriteLine($"persoon: {persoon}\n");

                Console.WriteLine($"persoon.Voornaam = persoon.Voornaam.ToUpper()");
                persoon.Voornaam = persoon.Voornaam.ToUpper();

                Console.WriteLine($"\npersoon: {persoon}\n");

                Console.WriteLine($"persoon.Voornaam = null");
                persoon.Voornaam = null;

                Console.WriteLine($"\npersoon: {persoon}\n");

                Console.WriteLine($"persoon.Adres = null");
                persoon.Adres = null;

                Console.WriteLine($"\npersoon: {persoon}\n");

                Console.WriteLine($"persoon.Adres = adres");
                persoon.Adres = adres;

                Console.WriteLine($"\npersoon: {persoon}\n");

                Console.WriteLine($"persoon.Adres.Straat = persoon.Adres.Straat.ToUpper()");
                persoon.Adres.Straat = persoon.Adres.Straat.ToUpper();

                Console.WriteLine($"\npersoon: {persoon}\n");

                Console.WriteLine($"persoon.Familienaam = null");
                persoon.Familienaam = null;

                Console.WriteLine($"\npersoon: {persoon}\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception {ex.GetType().Name}: {ex.Message}");
            }

            Console.Write($"\n\nEinde test Persoon.\nDruk toets om verder te gaan...");
            Console.ReadKey(true);
        }
    }
}
