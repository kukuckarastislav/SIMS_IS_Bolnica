using Bolnica.Controller;
using Model;
using Repozitorijum;
using Servis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;

namespace Controller
{
    class ZdravstvenaUslugaKontroler
    {
        private ZdravstvenaUslugaServis servis;
        private NotifikacijeServis notifikacijaServis;

        public ZdravstvenaUslugaKontroler()
        {
            servis = new ZdravstvenaUslugaServis();
            notifikacijaServis = new NotifikacijeServis();
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUsluga ret = servis.DodajUslugu(usluga);
            notifikacijaServis.ZakaziTermin(usluga);
            return ret;
        }

        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            servis.OtkaziUslugu(usluga);
            NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            kontroler.NotifikujOtkazaniTermin(usluga);
        }

        public DTOUslugaLekar OdloziUslugu(DTOUslugaLekar ul)
        {
            ZdravstvenaUsluga usluga = servis.OdloziUslugu(ul.Usluga);
            if (usluga != null)
            {
                OtkaziUslugu(ul.Usluga);
                usluga.IdPacijenta = ul.Usluga.IdPacijenta;
                ul.Usluga = usluga;
                DodajUslugu(usluga);

                return new DTOUslugaLekar(usluga, ul.Lekar);
            }
            return null;
        }

        public List<ZdravstvenaUsluga> getAppointments(Lekar OdabraniLekar, DateTime datum)
        {
            DateTime pocetak = new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 00);
            DateTime kraj = new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 00);
            return ZdravstvenaUslugaServis.GetSlobodniTerminiLekara(OdabraniLekar,pocetak,kraj);
        }
    }
}
