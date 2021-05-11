using Bolnica.Controller;
using Model;
using Repozitorijum;
using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ZdravstvenaUsluga HitnoDodajUslugu(Lekar lekar,ZdravstvenaUsluga usluga)
        {
            notifikacijaServis.ZakaziTermin(usluga);
            ZdravstvenaUsluga ret = servis.HitnoDodajUslugu(lekar, usluga);
            if(ret!=null)notifikacijaServis.OtkaziTermin(ret);
            return ret;
        }

        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            servis.OtkaziUslugu(usluga);
        }

        internal ObservableCollection<ZdravstvenaUsluga> GetTerminiPacijenta(int id)
        {
            return servis.GetTerminiPacijenta(id);
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

        public List<ZdravstvenaUsluga> GetSlobodniTermini(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)
        {
            return ZdravstvenaUslugaServis.GetSlobodniTermini(OdabraniLekar,pocetak,kraj,prioritet);
        }

        public List<ZdravstvenaUsluga> GetSviTerminiZaDatum(Lekar lekar, DateTime datum)
        {
            return servis.GetSviTerminiZaDatum(lekar,datum);
        }

        public bool PomjeranjeTerminaMoguce(ZdravstvenaUsluga Pregled,DateTime NoviPocetak)
        {
            return servis.PomjeranjeTerminaMoguce(Pregled, NoviPocetak);
        }


    }
}
