using DTO;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Controller
{
    class ObavestenjeKontroler
    {
        private ObavestenjeServis servisObavestenja;

        public ObavestenjeKontroler()
        {
            servisObavestenja = new ObavestenjeServis();
        }

        public ObservableCollection<ObavestenjeDTO> GetAllObavestenja()
        {
            return servisObavestenja.GetAllObavestenja();
        }

        public void ObrisiObavestenje(int id)
        {
            servisObavestenja.ObrisiObavestenje(id);
        }

        public Obavestenje DodajObavestenje(String naslov, String poruka)
        {
            if (String.IsNullOrEmpty(naslov) || String.IsNullOrEmpty(poruka)) return null;
            Obavestenje obavestenje = new Obavestenje(-1, naslov, DateTime.Now, poruka);
            return servisObavestenja.DodajObavestenje(obavestenje);
        }

    }
}
