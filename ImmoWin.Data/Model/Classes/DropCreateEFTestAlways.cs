using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Classes
{
    internal class DropCreateEFTestAlways : DropCreateDatabaseAlways<TestContext>
    {
        protected override void Seed(TestContext context)
        {
            base.Seed(context);

            Adres adres1 = new Adres("Krechtenbroeklaan", "29", "1640", "Sint-Genesius-Rode");
            Adres adres2 = new Adres("Steenweg Naar Halle", "369", "1652", "Alsemberg");

            context.Adressen.Add(adres1);
            context.Adressen.Add(adres2);

            Klant klant1 = new Klant("Frank", "Stroobants", adres1, KlantType.Koper);
            Klant klant2 = new Klant("Quinten", "Stroobants", adres2, KlantType.Verkoper);

            context.Klanten.Add(klant1);
            context.Klanten.Add(klant2);

            context.SaveChanges();

            //DropCreateDatabaseIfModelChanges
            //CreateDatabaseIfNotExists
        }
    }
}
