using System;
using Repozitorijum;
using Model;
using DTO;
using System.Collections.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace Servis
{
    public class PodsjetnikServis
    {
        private PodsjetnikRepozitorijum Repozitorijum;
        private LekoviRepozitorijum lekoviRepozitorijum;

        public PodsjetnikServis()
        {
            Repozitorijum = PodsjetnikRepozitorijum.GetInstance;
            lekoviRepozitorijum = LekoviRepozitorijum.GetInstance;
        }

        public void ThreadPodsjetnik()
        {
            List<Podsjetnik> lista = Repozitorijum.GetAll();
            while (true)
            {
                foreach (Podsjetnik p in lista)
                {
                    if (!p.Vidljiv && DateTime.Compare(p.VrijemePojavljivanja, DateTime.Now) <= 0)
                    {
                        p.Vidljiv = true;
                        Repozitorijum.AzurirajPodsjetnik(p);
                    }
                }

                Thread.Sleep(60 * 1000);      // na svkaih 60 sekundi   
            }

        }

        internal Podsjetnik DodajPodsjetnik(PodsjetnikParametriDTO parametri)
        {
            while(DateTime.Compare(parametri.Pocetak,parametri.Kraj) <= 0)
            {
                int id = Repozitorijum.getNewId();
                DateTime Vrijeme = new DateTime(parametri.Pocetak.Year,parametri.Pocetak.Month,parametri.Pocetak.Day,
                                            parametri.VrijemePojavljivanja.Hour,parametri.VrijemePojavljivanja.Minute,00);
                Repozitorijum.DodajPodsjetnik(new Podsjetnik(id,parametri.IdPacijenta,Vrijeme, false, parametri.Tekst,false));
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
                Podsjetnik Podsjetnik = new Podsjetnik(id, idPacijenta, Vrijeme, false, GenerisiTekstPodsjetnika(idLeka), false);
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
                Podsjetnik noviPodsjetnik = new Podsjetnik(id,p.IdPacijenta,p.VrijemePojavljivanja + period,p.Vidljiv,p.Tekst,p.Procitan);
                Repozitorijum.DodajPodsjetnik(noviPodsjetnik);

                if(parametri.DnevniBrojUzimanja == 3)
                {
                    int newid = Repozitorijum.getNewId();
                    Podsjetnik NoviPodsjetnik = new Podsjetnik(newid, p.IdPacijenta, p.VrijemePojavljivanja+period+period, p.Vidljiv, p.Tekst, p.Procitan);
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



    }
}
