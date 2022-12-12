using ImmoWin.Data.Model.Classes;
using Odisee.Common.Observables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows;

namespace ImmoWin.Data.Services
{


    // ik delete en add een persoon ipv een klant omdat deze twee gelinkt zijn dmv TPT.
    public static class KlantenRepository
    {
        public enum KlantTypeFilter
        {
            Alles = 0,
            Onbekend = 1,
            Gast = 2,
            Koper = 3,
            Verkoper = 4,
            KoperEnVerkoper = 5
        }

        public static Klanten GetKlanten()
        {
            TestContext context = new TestContext();
            Klanten klanten = new Klanten(context.Klanten.Include(k => k.Adres).ToList()); ;
            return klanten;
        }

        public static Klanten GetKlantenFiltered(KlantTypeFilter filter)
        {
            TestContext context = new TestContext();
            Klanten klanten;
            switch (filter)
            {
                case KlantTypeFilter.Alles:
                    klanten = new Klanten(context.Klanten.Include(k => k.Adres).ToList()); ;
                    break;
                case KlantTypeFilter.Onbekend:
                    klanten = new Klanten(context.Klanten.Where(e => e.KlantType == KlantType.Onbekend).Include(k => k.Adres).ToList());
                    break;
                case KlantTypeFilter.Gast:
                    klanten = new Klanten(context.Klanten.Where(e => e.KlantType == KlantType.Gast).Include(k => k.Adres).ToList());
                    break;
                case KlantTypeFilter.Koper:
                    klanten = new Klanten(context.Klanten.Where(e => e.KlantType == KlantType.Koper).Include(k => k.Adres).ToList());
                    break;
                case KlantTypeFilter.Verkoper:
                    klanten = new Klanten(context.Klanten.Where(e => e.KlantType == KlantType.Verkoper).Include(k => k.Adres).ToList());
                    break;
                case KlantTypeFilter.KoperEnVerkoper:
                    klanten = new Klanten(context.Klanten.Where(e => e.KlantType == KlantType.KoperEnVerkoper).Include(k => k.Adres).ToList());
                    break;
                default:
                    klanten = new Klanten(context.Klanten.Include(k => k.Adres).ToList()); ;
                    break;
            }
            return klanten;
        }


        public static void DeleteKlant(Persoon p)
        {
            TestContext context = new TestContext();

            if(context.Entry(p).State == EntityState.Detached)
            {
                context.Personen.Attach(p);
            }
            context.Personen.Remove(p);
            context.SaveChanges();
        }

        public static void AddKlant(Persoon p)
        {
            TestContext context = new TestContext();
            context.Personen.Add(p);
            context.SaveChanges();
        }

        static public void UpdateKlant(Persoon p)
        {
            TestContext context = new TestContext();
            context.Entry(p).State = EntityState.Modified;
            context.Entry(p.Adres).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
