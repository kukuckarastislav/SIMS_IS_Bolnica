using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis;
using Model;

namespace Bolnica.Controller
{
    class PodsjetnikKontroler
    {
        private PodsjetnikServis servis;

        public PodsjetnikKontroler()
        {
            servis = new PodsjetnikServis();
        }

        internal ObservableCollection<Podsjetnik> GetPodsjetnikPacijenta(int id)
        {
            return servis.GetPodsjetnikPacijenta(id);
        }

        internal void DodajPodsjetnik(int id, DateTime pocetak, string text)
        {
            servis.DodajPodsjetnik(id,pocetak,text);
        }
    }
}
