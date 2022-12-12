using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmoWin.Data.Model.Classes
{
    public class TestContext : DbContext
    {
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Adres> Adressen { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Woning> Woningen { get; set; }
        public DbSet<Huis> Huizen { get; set; }
        public DbSet<Appartement> Appartementen { get; set; }

        public TestContext() : base("ImmoWin")
        {
            Database.SetInitializer(new DropCreateEFTestAlways());
        }
    }
}
