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

        public PodsjetnikServis()
        {
            Repozitorijum = PodsjetnikRepozitorijum.GetInstance;
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
