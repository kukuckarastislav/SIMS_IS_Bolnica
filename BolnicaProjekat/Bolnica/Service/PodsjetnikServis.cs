using System;
using Repozitorijum;
using Model;
using DTO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Interface;
using Threads;

namespace Servis
{
    class PodsjetnikServis: IObserver
    {
        private PodsjetnikRepozitorijum Repozitorijum;
        private LekoviRepozitorijum lekoviRepozitorijum;

        public PodsjetnikServis()
        {
            Repozitorijum = PodsjetnikRepozitorijum.GetInstance;
            lekoviRepozitorijum = LekoviRepozitorijum.GetInstance;
        }



        internal Podsjetnik DodajPodsjetnik(PodsjetnikParametriDTO parametri)
        {
            while(DateTime.Compare(parametri.Pocetak,parametri.Kraj) <= 0)
            {
                int id = Repozitorijum.getNewId();
                DateTime Vrijeme = new DateTime(parametri.Pocetak.Year,parametri.Pocetak.Month,parametri.Pocetak.Day,
                                            parametri.VrijemePojavljivanja.Hour,parametri.VrijemePojavljivanja.Minute,00);
                Repozitorijum.DodajPodsjetnik(new Podsjetnik(id,parametri.IdPacijenta,Vrijeme, false, parametri.Tekst,false,false));
                parametri.Pocetak += new TimeSpan(1, 0, 0, 0, 0);
            }
            return null;
        }


        internal void DodajPodsjetnikZaUzimanjeLijeka(ParametriUzimanjaTerapijeDTO parametri, int idLeka,int idPacijenta)
        {
            while (DateTime.Compare(parametri.PocetakTerapije, parametri.KrajTerapije) <= 0)
            {
                DateTime Vrijeme = new DateTime(parametri.PocetakTerapije.Year, parametri.PocetakTerapije.Month, parametri.PocetakTerapije.Day,
                                                   parametri.PredlozenoVrijeme,00, 00);

                int id = Repozitorijum.getNewId();
                Podsjetnik Podsjetnik = new Podsjetnik(id, idPacijenta, Vrijeme, false, GenerisiTekstPodsjetnika(idLeka), false,true);
                Repozitorijum.DodajPodsjetnik(Podsjetnik);
                parametri.PocetakTerapije += new TimeSpan(1, 0, 0, 0, 0);
                DodajOstalePodsjetnikeZaDan(parametri,Podsjetnik);
            }
        }

        public void DodajOstalePodsjetnikeZaDan(ParametriUzimanjaTerapijeDTO parametri,Podsjetnik p)
        {
            if(parametri.DnevniBrojUzimanja > 1)
            {
                int id = Repozitorijum.getNewId();
                TimeSpan period = new TimeSpan(0, parametri.VremenskiRazmak, 0, 0, 0);
                Podsjetnik noviPodsjetnik = new Podsjetnik(id,p.IdPacijenta,p.VrijemePojavljivanja + period,p.Vidljiv,p.Tekst,p.Procitan,true);
                Repozitorijum.DodajPodsjetnik(noviPodsjetnik);

                if(parametri.DnevniBrojUzimanja == 3)
                {
                    int newid = Repozitorijum.getNewId();
                    Podsjetnik NoviPodsjetnik = new Podsjetnik(newid, p.IdPacijenta, p.VrijemePojavljivanja+period+period, p.Vidljiv, p.Tekst, p.Procitan,true);
                    Repozitorijum.DodajPodsjetnik(NoviPodsjetnik);
                }
            }
        }

        public String GenerisiTekstPodsjetnika(int idLeka)
        {
            return "Podsjecamo vas da je vrijeme da uzmete vas lijek " + lekoviRepozitorijum.GetLekById(idLeka).Naziv;
        }

        internal ObservableCollection<Podsjetnik> GetPodsjetnikPacijenta(int id)
        {
            ObservableCollection<Podsjetnik> ret = new ObservableCollection<Podsjetnik>();

            foreach (Podsjetnik p in Repozitorijum.GetPodsjetnikByPatientId(id))
            {
                if (p.Vidljiv)
                    ret.Add(p);
            }
            return ret;
        }

        public void AzurirajStanjePosleCitanja(int idPacijenta)
        {
            foreach (Podsjetnik p in Repozitorijum.GetPodsjetnikByPatientId(idPacijenta))
            {
                p.Procitan = true;
                Repozitorijum.AzurirajPodsjetnik(p);
            }
        }

        public int GetBrojNeprocitanihPodsjetnika(int idPacijenta)
        {
            int count = 0;
            foreach (Podsjetnik p in Repozitorijum.GetPodsjetnikByPatientId(idPacijenta))
            {
                if (p.Procitan == false)
                    count++;
            }
            return count;
        }

        public List<StavkaIzvjestajaDTO> GetPodsjetnikAktuelneSedmice(int idPacijenta)
        {
            List<StavkaIzvjestajaDTO> ret = new List<StavkaIzvjestajaDTO>();
            foreach(Podsjetnik p in Repozitorijum.GetPodsjetnikByPatientId(idPacijenta))
            {
                if((DateTime.Compare(p.VrijemePojavljivanja, GetPocetakIzvjestaja()) >= 0) &&
                    (DateTime.Compare(p.VrijemePojavljivanja, GetPocetakIzvjestaja().AddDays(7)) <= 0) && p.JePodsjetnikZaLijekove)
                {
                    String[] tokens = p.Tekst.Split(' ');
                    string nazivLijeka = tokens[9];
                    ret.Add(new StavkaIzvjestajaDTO(p.VrijemePojavljivanja.DayOfWeek.ToString(),nazivLijeka,p.VrijemePojavljivanja));
                }
            }
            return ret;
        }

        public List<StavkaIzvjestajaDTO> GetStavkaIzvjestajaZaDan(int idPacijenta,string DanUSedmici)
        {
            List<StavkaIzvjestajaDTO> ret = new List<StavkaIzvjestajaDTO>();
            foreach(StavkaIzvjestajaDTO s in GetPodsjetnikAktuelneSedmice(idPacijenta))
            {
                if (s.DanUSedmici.Equals(DanUSedmici))
                    ret.Add(s);
            }
            return ret;
        }

        public DateTime GetPocetakIzvjestaja()
        {
            DateTime pocetakIzvjestaja = new DateTime();
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday) pocetakIzvjestaja = DateTime.Now;
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday) pocetakIzvjestaja = DateTime.Now - new TimeSpan(1, 0, 0, 0);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday) pocetakIzvjestaja = DateTime.Now - new TimeSpan(2, 0, 0, 0);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday) pocetakIzvjestaja = DateTime.Now - new TimeSpan(3, 0, 0, 0);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday) pocetakIzvjestaja = DateTime.Now - new TimeSpan(4, 0, 0, 0);
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday) pocetakIzvjestaja = DateTime.Now - new TimeSpan(5, 0, 0, 0);
            else pocetakIzvjestaja = DateTime.Now - new TimeSpan(6, 0, 0, 0);

            return pocetakIzvjestaja;
        }

        public void Update(ISubject subject)
        {
            if(subject is MedicationConsumption medicationConsumption)
            {
                Podsjetnik p = Repozitorijum.GetPodsjetnikById(medicationConsumption.Reminderid);
                p.Vidljiv = true;
                Repozitorijum.AzurirajPodsjetnik(p);
            }
        }
    }
}
