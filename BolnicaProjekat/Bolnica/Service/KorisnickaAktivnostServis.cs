using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;
using Model;
using Interface;
using Threads;

namespace Servis
{
    class KorisnickaAktivnostServis : IObserver
    {
        private KorisnickaAktivnostRepozitorijum _KorisnickaAktivnostRepozitorijum;
        private NotifikacijaRepozitorijum _NotifikacijeRepozitorijum;   //posalji mu upozorenje da ce biti banovan
        private PacijentRepozitorijum _PacijentRepozitorijum;

        private readonly TimeSpan JedanMjesec = new TimeSpan(30, 0, 0, 0, 0);
        private readonly TimeSpan PeriodSuspenzije = new TimeSpan(14, 0, 0, 0, 0);
  

        public bool JeSpamUser(int IdPacijenta)
        {
            if (PacijentRepozitorijum.GetInstance.GetById(IdPacijenta).SpamUser)
                return true;
            else return AnalizaAktivnostiPacijenta(IdPacijenta);
        }


        public bool AnalizaAktivnostiPacijenta(int IdPacijenta)
        {
            ObservableCollection<Aktivnost> aktivnosti = GetRelevantneAktivnosti(IdPacijenta);

            if (GetBrojPomjeranjaTermina(aktivnosti) > 3 || GetBrojZakazivanjaTermina(aktivnosti) > 3)
            {
                Pacijent p = PacijentRepozitorijum.GetInstance.GetById(IdPacijenta);
                p.SpamUser = true;
                PacijentRepozitorijum.GetInstance.AzurirajPacijenta(p);

                KorisnickaAktivnostRepozitorijum.GetInstance.DodajAktivnost(new Aktivnost(IdPacijenta, DateTime.Now, "TRENUTNA SUSPENZIJA")); //jer moze biti vise suspenzija
                return true;
            }
            else if (GetBrojPomjeranjaTermina(aktivnosti) == 3 || GetBrojZakazivanjaTermina(aktivnosti) == 3)
            {
                PosaljiUpozorenje(IdPacijenta);
                return false;
            }
            else return false;
        }

        public int GetBrojPomjeranjaTermina(ObservableCollection<Aktivnost> aktivnosti)
        {
            int count = 0;
            foreach (Aktivnost a in aktivnosti)
            {
                if (a.Vrsta.Equals("POMJERANJE")) count++;
            }
            return count;
        }

        public int GetBrojZakazivanjaTermina(ObservableCollection<Aktivnost> aktivnosti)
        {
            int count = 0;
            foreach (Aktivnost a in aktivnosti)
            {
                if (a.Vrsta.Equals("ZAKAZIVANJE")) count++;
            }
            return count;
        }

        public ObservableCollection<Aktivnost> GetRelevantneAktivnosti(int idPacijenta)
        {
            ObservableCollection<Aktivnost> aktivnosti = KorisnickaAktivnostRepozitorijum.GetInstance.GetPatientActivityById(idPacijenta);
            ObservableCollection<Aktivnost> relevantneAktivnosti = new ObservableCollection<Aktivnost>();

            foreach (Aktivnost a in aktivnosti)
            {
                if (DateTime.Compare(a.Datum, DateTime.Now - JedanMjesec) > 0)
                {
                    relevantneAktivnosti.Add(a);
                }
            }
            return relevantneAktivnosti;
        }


        public void PosaljiUpozorenje(int idPacijenta)
        {
            int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;
            NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(new Notifikacija(id + 1, -1, idPacijenta, -1, false, false,
                                                                     " Upozoravamo vas da cete bannovani ako uradite jos jedno pomjeranje ili zakazivanje termina!"));
        }

        public Aktivnost DodajKorisnickuAktivnost(Aktivnost aktivnost)
        {
            return KorisnickaAktivnostRepozitorijum.GetInstance.DodajAktivnost(aktivnost);
        }

        public void Update(ISubject subject)
        {
            if(subject is UserSuspension userSuspension)
            {
                KorisnickaAktivnostRepozitorijum.GetInstance.AzurirajStareSuspenzije(userSuspension.Patientid);
            }
        }
    }
}
