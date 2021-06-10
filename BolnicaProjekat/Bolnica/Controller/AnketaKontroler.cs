using System.Collections.Generic;
using Servis;
using Model;
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

        public Ocena DodajOcenuLekara(ZdravstvenaUslugaDTO pregled,int idPacijenta, string text,int ocjena)
        {
            return servis.DodajOcenuLekara(pregled,idPacijenta, text,ocjena);
        }

        public List<OcenaDTO> GetSveOceneLekara()
        {
            return servis.GetSveOceneLekara();
        }

        public List<OcenaDTO> GetSveOceneBolnice()
        {
            return servis.GetSveOceneBolnice();
        }

        public List<OcenaDTO> GetOceneOdabranogLekara(int id)
        {
            return servis.GetOceneOdabranogLekara(id);
        }

        public List<OcenaDTO> GetSveOcenePacijenta(int id)
        {
            return servis.GetOcenePacijenta(id);
        }
    }
}
