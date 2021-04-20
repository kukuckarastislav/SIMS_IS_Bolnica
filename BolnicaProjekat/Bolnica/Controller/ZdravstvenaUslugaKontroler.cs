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

        public ZdravstvenaUsluga OdloziUslugu(DTOUslugaLekar ul)
        {
            ZdravstvenaUsluga usluga = ul.Usluga;
            int maxDanaOdlaganja = 3;
            DateTime datum = usluga.Termin.Pocetak;
            bool odlozeno = false;
            for(int i=1;i <= maxDanaOdlaganja; i++)
            {
                for (int j = 0; j < 8; j++) {
                    DateTime d = new DateTime(datum.Year, datum.Month, datum.Day+i, datum.Hour+j, datum.Minute, datum.Second);
                    if (servis.OdloziUslugu(usluga, d))
                    {
                        odlozeno = true;
                        DateTime dk = new DateTime(d.Year, d.Month, d.Day, d.Hour, d.Minute, d.Second);
                        dk.AddMinutes(30);
                        usluga.Termin.Pocetak = d;
                        usluga.Termin.Kraj = dk;
                    }
                }
            }
            //NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            // kontroler.NotifikujOtkazaniTermin(usluga);
            if (odlozeno)
            {
                ZdravstvenaUslugaRepozitorijum.GetInstance.SaveData();
                return usluga;
            }
            return null;
        }
    }
}
