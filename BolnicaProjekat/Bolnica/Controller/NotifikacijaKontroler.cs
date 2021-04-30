using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Collections.ObjectModel;
using Servis;

namespace Bolnica.Controller
{
    class NotifikacijaKontroler
    {
        private NotifikacijeServis ServisNotifikacije;

        public NotifikacijaKontroler()
        {
            ServisNotifikacije = new NotifikacijeServis();
        }

        public void NotifikujZakazaniTermin(ZdravstvenaUsluga usluga)
        {
            ServisNotifikacije.ZakaziTermin(usluga);
        }

        public void NotifikujOtkazaniTermin(ZdravstvenaUsluga usluga)
        {
            ServisNotifikacije.OtkaziTermin(usluga);
        }

        public ObservableCollection<Notifikacija> GetNotifikacijePacijenta(int idPacijenta)
        {
            return ServisNotifikacije.GetNotifikacijePacijenta(idPacijenta);
        }

    }
}
