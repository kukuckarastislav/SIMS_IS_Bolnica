using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Servis;
using Model;
using System.Collections.ObjectModel;
using DTO;

namespace Bolnica.Controller
{
    class AnketaKontroler
    {
        private AnketaServis servis;

        public AnketaKontroler()
        {
            servis = new AnketaServis();
        }

        public Ocena DodajOcenuBolnice(int idPacijenta,string text,int ocjena)
        {
            return servis.DodajOcenuBolnice(idPacijenta,text,ocjena);
        }

        public Ocena DodajOcenuLekara(ZdravstvenaUsluga pregled,int idPacijenta, string text,int ocjena)
        {
            return servis.DodajOcenuLekara(pregled,idPacijenta, text,ocjena);
        }

        public ObservableCollection<OcenaDTO> GetSveOceneLekara()
        {
            return servis.GetSveOceneLekara();
        }

        public ObservableCollection<OcenaDTO> GetSveOceneBolnice()
        {
            return servis.GetSveOceneBolnice();
        }

        internal ObservableCollection<OcenaDTO> GetOceneOdabranogLekara(int id)
        {
            return servis.GetOceneOdabranogLekara(id);
        }

        internal ObservableCollection<OcenaDTO> GetSveOcenePacijenta(int id)
        {
            return servis.GetOcenePacijenta(id);
        }
    }
}
