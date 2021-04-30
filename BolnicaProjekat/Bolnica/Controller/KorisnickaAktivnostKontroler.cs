using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis;
using Model;

namespace Controller
{
    class KorisnickaAktivnostKontroler
    {
        private KorisnickaAktivnostServis servis;

        public KorisnickaAktivnostKontroler()
        {
            servis = new KorisnickaAktivnostServis();
        }

        public Aktivnost DodajKorisnickuAktivnostZakazivanja(int idPacijenta)
        {
            Aktivnost aktivnost = new Aktivnost(idPacijenta, DateTime.Now, "ZAKAZIVANJE");
            return servis.DodajKorisnickuAktivnost(aktivnost);
        }

        public Aktivnost DodajKorisnickuAktivnostPomjeranja(int idPacijenta)
        {
            Aktivnost aktivnost = new Aktivnost(idPacijenta, DateTime.Now, "POMJERANJE");
            return servis.DodajKorisnickuAktivnost(aktivnost);
        }

        public bool JeSpamUser(int idPacijenta)
        {
            return servis.JeSpamUser(idPacijenta);
        }
    }
}
