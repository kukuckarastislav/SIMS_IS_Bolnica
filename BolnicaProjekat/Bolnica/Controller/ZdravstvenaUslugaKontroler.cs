using Bolnica.Controller;
using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    class ZdravstvenaUslugaKontroler
    {
        private ZdravstvenaUslugaServis servis;

        public ZdravstvenaUslugaKontroler()
        {
            servis = new ZdravstvenaUslugaServis();
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUsluga ret = servis.DodajUslugu(usluga);
            NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            kontroler.NotifikujZakazaniTermin(usluga);
            return ret;
        }

        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            servis.OtkaziUslugu(usluga);
            NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            kontroler.NotifikujOtkazaniTermin(usluga);
        }
    }
}
