using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Converters;
using DTO;
using Model;
using Servis;

namespace Kontroler
{
    public class ZdravstvenaUslugaKontroler
    {
        private ZdravstvenaUslugaServis ZdrastvenaUslugaServisObjekat;
        private NotifikacijeServis NotifikacijaServisObjekat;

        public ZdravstvenaUslugaKontroler()
        {
            ZdrastvenaUslugaServisObjekat = new ZdravstvenaUslugaServis();
            NotifikacijaServisObjekat = new NotifikacijeServis();
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUsluga ret = ZdrastvenaUslugaServisObjekat.DodajUslugu(usluga);
            NotifikacijaServisObjekat.ZakaziTermin(usluga);
            return ret;
        }

        public ZdravstvenaUsluga AzurirajVremeUsluga(ZdravstvenaUsluga usluga, DateTime pocetak, DateTime kraj)
        {
            return ZdrastvenaUslugaServisObjekat.AzurirajVremeUsluga(usluga, pocetak, kraj);
        }

        public ZdravstvenaUsluga HitnoDodajUslugu(Lekar lekar,ZdravstvenaUsluga usluga)
        {
            NotifikacijaServisObjekat.ZakaziTermin(usluga);
            ZdravstvenaUsluga ret = ZdrastvenaUslugaServisObjekat.HitnoDodajUslugu(lekar, usluga);
            if(ret!=null)NotifikacijaServisObjekat.OtkaziTermin(ret);
            return ret;
        }

        public ZakaziTetminDTO ZakaziUslugu(ZakaziTetminDTO usluga)
        {
            return ZdrastvenaUslugaServisObjekat.ZakaziUslugu(usluga);
        }

        internal void DodajKomentarNaUslugu(int id, string text)
        {
            ZdrastvenaUslugaServisObjekat.DodajKomentarNaUslugu(id,text);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsliTerminiPacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetProsliTerminiPacijenta(id);
        }

        public void OtkaziUslugu(ZakazaniTerminiDTO usluga)
        {
            ZdrastvenaUslugaServisObjekat.OtkaziUslugu(usluga);
        }

        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            ZdrastvenaUslugaServisObjekat.OtkaziUslugu(usluga);
        }

        public ObservableCollection<ZdravstvenaUslugaDTO> GetTerminiPacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetTerminiPacijenta(id);
        }

        public DTOUslugaLekar OdloziUslugu(DTOUslugaLekar ul)
        {
            ZdravstvenaUsluga usluga = ZdrastvenaUslugaServisObjekat.OdloziUslugu(ul.Usluga);
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

// Lekar - Radni Kalendar

        public List<RadniKalendarDTO> DanasnjiRadniKalendarLekara(LekarDTO l)
        {
            return ZdrastvenaUslugaServisObjekat.DanasnjiRadniKalendarLekara(l);
        }

        public List<RadniKalendarDTO> NedeljniRadniKalendarLekara(LekarDTO l)
        {
            return ZdrastvenaUslugaServisObjekat.NedeljniRadniKalendarLekara(l);
        }
        public List<RadniKalendarDTO> MesecniRadniKalendarLekara(LekarDTO l)
        {
            return ZdrastvenaUslugaServisObjekat.MesecniRadniKalendarLekara(l);

        }
// --------------------

        public List<ZdravstvenaUsluga> getAppointments(Lekar OdabraniLekar, DateTime datum)
        {
            DateTime pocetak = new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 00);
            DateTime kraj = new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 00);
            return ZdravstvenaUslugaServis.GetSlobodniTerminiLekara(OdabraniLekar,pocetak,kraj); 
        }

        public ObservableCollection<ZdravstvenaUslugaDTO> GetSlobodniTermini(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)
        {
            return ZdravstvenaUslugaServis.GetSlobodniTerminiDTO(OdabraniLekar, pocetak, kraj, prioritet);
        }

        public List<ZdravstvenaUsluga> GetSviTerminiZaDatum(Lekar lekar, DateTime datum)
        {
            return ZdrastvenaUslugaServisObjekat.GetSviTerminiZaDatum(lekar,datum);
        }

        public bool PomjeranjeTerminaMoguce(ZdravstvenaUsluga Pregled,DateTime NoviPocetak)
        {
            return ZdrastvenaUslugaServisObjekat.PomjeranjeTerminaMoguce(Pregled, NoviPocetak);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelniTerminiPacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetAktuelniTerminiPacijenta(id);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelniPreglediPacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetAktuelniPreglediPacijenta(id);
        }

        public List<ZakazaniTerminiDTO> getAllDto()
        {
            return ZdrastvenaUslugaServisObjekat.getAllDto();
        }
        public List<ZakazaniTerminiDTO> getAllDto(DateTime datumPretrage)
        {
            return ZdrastvenaUslugaServisObjekat.getAllDtoZaDatum(datumPretrage);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsliPreglediPacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetProsliPreglediPacijenta(id);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelneOperacijePacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetAktuelneOperacijePacijenta(id);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsleOperacijePacijenta(int id)
        {
            return ZdrastvenaUslugaServisObjekat.GetProsleOperacijePacijenta(id);
        }
    }
}
