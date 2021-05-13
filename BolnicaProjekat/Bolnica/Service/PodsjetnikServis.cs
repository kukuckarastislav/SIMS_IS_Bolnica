using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repozitorijum;
using Model;
using System.Collections.ObjectModel;
using System.Threading;

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
            ObservableCollection<Podsjetnik> lista = Repozitorijum.GetAll();
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

        internal Podsjetnik DodajPodsjetnik(int idPacijenta, DateTime pocetak, string text)
        {
            int id = Repozitorijum.GetAll().Count();
            return Repozitorijum.DodajPodsjetnik(new Podsjetnik(id, idPacijenta, pocetak, false, text));
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



    }
}
