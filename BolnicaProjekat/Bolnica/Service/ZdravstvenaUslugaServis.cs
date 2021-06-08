/***********************************************************************
 * Module:  TerminiServis.cs
 * Author:  lacik
 * Purpose: Definition of the Class Servis.TerminiServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using Bolnica.Repository;
using Bolnica.Template;
using DTO;
using Model;
using Org.BouncyCastle.Security;
using Repository;
using Repozitorijum;


namespace Servis
{
    public class ZdravstvenaUslugaServis
    {
        public PacijentRepozitorijum pacijentRepozitorijum;
        public LekarRepozitorijum lekarRepozitorijum;
        public ProstorijeRepozitorijum prostorijeRepozitorijum;
        public ZdravstvenaUslugaRepozitorijum terminiRepozitorijum;

        public static TimeSpan trajanjePregleda = new TimeSpan(0, 0, 30, 0, 0);
        public const int maxBrojDanaOdlaganja = 3;
        public ZdravstvenaUslugaServis()
        {
            terminiRepozitorijum = new ZdravstvenaUslugaRepozitorijum();
            lekarRepozitorijum = new LekarRepozitorijum();

        }

        internal static ObservableCollection<ZdravstvenaUslugaDTO> GetSlobodniTerminiDTO(Lekar odabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)
        {
            return Konvertuj(GetSlobodniTermini(odabraniLekar,pocetak,kraj,prioritet));
        }

        private static ObservableCollection<ZdravstvenaUslugaDTO> Konvertuj(List<ZdravstvenaUsluga> prosliTermini)
        {
            ObservableCollection<ZdravstvenaUslugaDTO> ret = new ObservableCollection<ZdravstvenaUslugaDTO>();
            foreach (ZdravstvenaUsluga u in prosliTermini)
            {
                ret.Add(new ZdravstvenaUslugaDTO(u.Termin, u.Id, u.IdPacijenta, u.IdLekara,
                     "Laslo ",
                        u.TipUsluge, u.IdProstorije, u.RazlogZakazivanja, u.RezultatUsluge));
            }
            return ret;
        }

        public static List<ZdravstvenaUsluga> GetSlobodniTermini(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)

        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();
            pregledi = GetSlobodniTerminiLekara(OdabraniLekar, pocetak, kraj);

            if (pregledi.Count == 0 && prioritet == 0)
            {
                pregledi = GetPriblizniTerminiPoVremenu(pocetak, kraj);
            }
            else if (pregledi.Count == 0 && prioritet == 1)
            {
                pregledi = GetPriblizniTerminiPoLekaru(OdabraniLekar, pocetak, kraj);
            }
            return pregledi;
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsliTerminiPacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach(ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) <= 0)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        private ObservableCollection<ZdravstvenaUslugaDTO> KonverujModelDTO(List<ZdravstvenaUsluga> prosliTermini)
        {
            ObservableCollection<ZdravstvenaUslugaDTO> ret = new ObservableCollection<ZdravstvenaUslugaDTO>();
            foreach (ZdravstvenaUsluga u in prosliTermini)
            {
                ret.Add(new ZdravstvenaUslugaDTO(u.Termin, u.Id, u.IdPacijenta, u.IdLekara,
                    lekarRepozitorijum.GetById(u.IdLekara).Ime+" "+ lekarRepozitorijum.GetById(u.IdLekara).Prezime,
                        u.TipUsluge, u.IdProstorije, u.RazlogZakazivanja, u.RezultatUsluge));
            }
            return ret;
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelniTerminiPacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) >= 0)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelniPreglediPacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) >= 0 && u.TipUsluge==TipUsluge.Pregled)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsliPreglediPacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) <= 0 && u.TipUsluge == TipUsluge.Pregled)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetAktuelneOperacijePacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) >= 0 && u.TipUsluge == TipUsluge.Operacija)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        internal ObservableCollection<ZdravstvenaUslugaDTO> GetProsleOperacijePacijenta(int id)
        {
            List<ZdravstvenaUsluga> prosliTermini = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga u in terminiRepozitorijum.getTerminiByPacijentId(id))
            {
                if (DateTime.Compare(u.Termin.Kraj, DateTime.Now) <= 0 && u.TipUsluge == TipUsluge.Operacija)
                    prosliTermini.Add(u);
            }
            return KonverujModelDTO(prosliTermini);
        }

        public static List<ZdravstvenaUsluga> GetSlobodniTerminiLekara(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();
            Termin radnoVreme = GetRadnoVremeLekara(OdabraniLekar, pocetak, kraj);

            while (radnoVreme.Pocetak + trajanjePregleda <= radnoVreme.Kraj)
            {
                ZdravstvenaUsluga pregled = new ZdravstvenaUsluga(new Termin(radnoVreme.Pocetak, radnoVreme.Pocetak + trajanjePregleda), 1, OdabraniLekar.Id, -1, TipUsluge.Pregled, -1, false, "", "");

                if (!JeTerminZauzet(OdabraniLekar, pregled))
                {
                    pregledi.Add(pregled);
                }
                radnoVreme.Pocetak += trajanjePregleda;
            }

            return pregledi;
        }
        public static bool JeTerminZauzet(Lekar OdabraniLekar, ZdravstvenaUsluga pregled) {

            List<ZdravstvenaUsluga> terminiLekara = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiBylekarId(OdabraniLekar.Id);

            foreach (ZdravstvenaUsluga termin in terminiLekara)
            {
                if (termin.Termin.Pocetak.Equals(pregled.Termin.Pocetak)) return true;
            }

            return false;
        }
        public static Termin GetRadnoVremeLekara(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            int krajSati = OdabraniLekar.radnoVreme.KrajRadnogVremena;
            int pocetakSati = OdabraniLekar.radnoVreme.PocetakRadnogVremena;

            if (pocetak.Hour > pocetakSati) pocetakSati = pocetak.Hour;
            if (kraj.Hour < krajSati) krajSati = kraj.Hour;

            return new Termin(new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0),
                                new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, krajSati, 0, 0));
        }
        public static List<ZdravstvenaUsluga> GetPriblizniTerminiPoVremenu(DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();
            List<ZdravstvenaUsluga> pomocna = new List<ZdravstvenaUsluga>();

            foreach (Lekar lekar in Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs())
            {
                pomocna = GetSlobodniTerminiLekara(lekar, pocetak, kraj);
                pregledi.AddRange(pomocna);
            }
            return pregledi;
        }
        public static List<ZdravstvenaUsluga> GetPriblizniTerminiPoLekaru(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();

            int krajSati = Convert.ToInt32(OdabraniLekar.radnoVreme.KrajRadnogVremena);
            int pocetakSati = Convert.ToInt32(OdabraniLekar.radnoVreme.PocetakRadnogVremena);

            DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0); //posto sam stavila d=DateTime u construktor pa ne mogu samo int
            DateTime krajkRadnogVremena_ = new DateTime(kraj.Year, kraj.Month, kraj.Day, krajSati, 0, 0);

            pregledi = GetSlobodniTerminiLekara(OdabraniLekar, pocetakRadnogVremena, krajkRadnogVremena_);
            return pregledi;
        }

        public bool PomjeranjeTerminaMoguce(ZdravstvenaUsluga pregled, DateTime noviPocetak)
        {
            List<ZdravstvenaUsluga> terminiLekara = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiBylekarId(pregled.IdLekara);


            bool zavrsio = false;
            while (!zavrsio)
            {
                zavrsio = true;
                foreach (var p in terminiLekara)
                {
                    if (p.Termin.Pocetak.Year != noviPocetak.Year || p.Termin.Pocetak.Month != noviPocetak.Month || p.Termin.Pocetak.Day != noviPocetak.Day)
                    {
                        terminiLekara.Remove(p);
                        zavrsio = false;
                        break;
                    }
                }
            }

            //provjera poklapanja sati, ako je izabrao recimo 4 i 15 zaokruzi na 4, ako je posle 30 zaokruzi na 5, ima smisla
            bool afterHalf = false;

            if (noviPocetak.Minute > 30)
                afterHalf = true;

            foreach (var v in terminiLekara)
            {
                if (afterHalf)
                {
                    if (v.Termin.Kraj.Hour == noviPocetak.Hour)
                        return false;
                }
                else
                {
                    if (v.Termin.Pocetak.Hour == noviPocetak.Hour)
                        return false;
                }
            }
            return true;
        }

       public static ObservableCollection<DTORadniKalendar> getUslugeLekara(Lekar l)
        {
            ObservableCollection<DTORadniKalendar> lista = new ObservableCollection<DTORadniKalendar>();
            List<ZdravstvenaUsluga> usluge = ZdravstvenaUslugaRepozitorijum.GetInstance.GetTerminByLekarId(l.Id);
            foreach(ZdravstvenaUsluga zu in usluge)
            {
                //DTORadniKalendar(ZdravstvenaUsluga usluga, Pacijent pacijent, Prostorija prostorija)
                lista.Add(new DTORadniKalendar(zu, PacijentRepozitorijum.GetInstance.GetById(zu.IdPacijenta), ProstorijeRepozitorijum.GetInstance.GetProstorijaById(zu.IdProstorije)));
            }
            return lista;

        }



        public static ObservableCollection<DTOUslugaLekar> getUslugePacijenta(Pacijent p)
        {
            ObservableCollection<DTOUslugaLekar> lista = new ObservableCollection<DTOUslugaLekar>();
            List<ZdravstvenaUsluga> usluge = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiByPacijentId(p.Id);
            foreach (ZdravstvenaUsluga zu in usluge)
            {
                lista.Add(new DTOUslugaLekar(zu, LekarRepozitorijum.GetInstance.GetById(zu.IdLekara)));
            }

            return lista;
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            usluga.Id = ZdravstvenaUslugaRepozitorijum.GetInstance.getNewId();
            return ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(usluga);
        }
        public void OtkaziUslugu(ZakazaniTerminiDTO usluga)
        {
            ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(KonvertujUModel(usluga));
        }

        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(usluga);
        }

        public ZdravstvenaUsluga KonvertujUModel(ZakazaniTerminiDTO dto)
        {
            ZdravstvenaUsluga usluga = new ZdravstvenaUsluga(dto.Termin, dto.Id, dto.Lekar.Id, dto.Pacijent.Id, dto.TipUsluge, dto.Prostorija.Id,
                false, "", "");
            return usluga;
        }

        public ZdravstvenaUsluga OdloziUslugu(ZdravstvenaUsluga usluga)
        {
            DateTime datum = usluga.Termin.Pocetak;
            for (int i = 1; i < maxBrojDanaOdlaganja; i++)
            {
                datum = datum.AddDays(1);
                List<ZdravstvenaUsluga> slobodniTerminiLekara = GetSlobodniTerminiLekara(LekarRepozitorijum.GetInstance.GetById(usluga.IdLekara),
                                                                new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 0),
                                                                new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 0));
                if (slobodniTerminiLekara.Count > 0)
                {
                    return slobodniTerminiLekara.ElementAt(0);
                }

            }
            return null;
        }
        public ObservableCollection<ZdravstvenaUslugaDTO> GetTerminiPacijenta(int id)
        {
            return KonverujModelDTO(ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiByPacijentId(id));
        }

        public void AzurirajVremeUsluga(DTORadniKalendar usluga, DateTime pocetak, DateTime kraj) 
        {
            DTORadniKalendar odabranaUsluga = usluga;
            odabranaUsluga.Usluga.Termin.Pocetak = pocetak;
            odabranaUsluga.Usluga.Termin.Kraj = kraj;
                  
        }

        public void DodajKomentarNaUslugu(int idUsluge,String text)
        {
            ZdravstvenaUsluga u = terminiRepozitorijum.getTerminById(idUsluge);
            u.RazlogZakazivanja = text;
            terminiRepozitorijum.AzurirajUslugu(u);
        }
        public List<ZdravstvenaUsluga> GetSviTerminiZaDatum(Lekar lekar, DateTime datum)
        {
            List<ZdravstvenaUsluga> terminiZaDatum = new List<ZdravstvenaUsluga>();
            Termin radnoVreme = GetRadnoVremeLekara(lekar,
                new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 0),
                new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 59));

            while (radnoVreme.Pocetak + trajanjePregleda <= radnoVreme.Kraj)
            {
                ZdravstvenaUsluga usluga = new ZdravstvenaUsluga(new Termin(radnoVreme.Pocetak, radnoVreme.Pocetak + trajanjePregleda), 1, lekar.Id, -1, TipUsluge.Pregled, -1, false, "", "");
                terminiZaDatum.Add(usluga);
                radnoVreme.Pocetak += trajanjePregleda;
            }

            return terminiZaDatum;
        }
        public List<ZdravstvenaUsluga> GetSviTerminiProstorije(int id)
        {
            List<ZdravstvenaUsluga> terminiProstorije = new List<ZdravstvenaUsluga>();
            List<ZdravstvenaUsluga> listaSviUsluga = ZdravstvenaUslugaRepozitorijum.GetInstance.getAll();
            foreach (ZdravstvenaUsluga usluga in listaSviUsluga)
            {
                if (usluga.IdProstorije == id)
                {
                    terminiProstorije.Add(usluga);
                }
            }
            return terminiProstorije;
        }

        public List<ZdravstvenaUsluga> GetSviTerminiProstorijeZaDatum(int id, DateTime datum)
        {
            List<ZdravstvenaUsluga> terminiProstorije = GetSviTerminiProstorije(id);
            List<ZdravstvenaUsluga> terminiDana = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga usluga in terminiProstorije)
            {
                if (usluga.Termin.Pocetak.Date.Equals(datum.Date))
                {
                    terminiDana.Add(usluga);
                }
            }
            return terminiDana;
        }

        public List<ZakazaniTerminiDTO> getAllDto()
        {
            List<ZakazaniTerminiDTO> uslugeDto = new List<ZakazaniTerminiDTO>();

            foreach(ZdravstvenaUsluga usluga in terminiRepozitorijum.getAll())
            {
                ZakazaniTerminiDTO uslugaDto = new ZakazaniTerminiDTO();
                uslugaDto.Id = usluga.Id;
                uslugaDto.Lekar = LekarRepozitorijum.GetInstance.GetById(usluga.IdLekara);
                uslugaDto.Pacijent = PacijentRepozitorijum.GetInstance.GetById(usluga.IdPacijenta);
                uslugaDto.Prostorija = ProstorijeRepozitorijum.GetInstance.GetProstorijaById(usluga.IdProstorije);
                uslugaDto.Termin = usluga.Termin;
                uslugaDto.TipUsluge = usluga.TipUsluge;
                uslugeDto.Add(uslugaDto);
            }

            return uslugeDto;
        }

        public List<ZakazaniTerminiDTO> getAllDtoZaDatum(DateTime datumPretrage)
        {
            List<ZakazaniTerminiDTO> uslugeDto = getAllDto();
            List<ZakazaniTerminiDTO> odabraneUsluge = new List<ZakazaniTerminiDTO>();
            foreach (ZakazaniTerminiDTO dto in uslugeDto)
            {
                if(dto.Termin.Pocetak.Date.Equals(datumPretrage))
                {
                    odabraneUsluge.Add(dto);
                }
            }

            return odabraneUsluge;
        }

        public ZdravstvenaUsluga HitnoDodajUslugu(Lekar lekar, ZdravstvenaUsluga usluga)
        {
            
            ZdravstvenaUsluga uslugaKojaSeOdlaze = ZdravstvenaUslugaRepozitorijum.GetInstance.GetUslugaZaTermin(lekar, usluga.Termin.Pocetak);
            ZdravstvenaUsluga odlozenaUsluga = OdloziTerminRadiHitnogTermina(lekar, usluga);
            if(uslugaKojaSeOdlaze!=null)OtkaziUslugu(uslugaKojaSeOdlaze);
            if (odlozenaUsluga != null)
            {
                odlozenaUsluga.IdPacijenta = uslugaKojaSeOdlaze.IdPacijenta;
                odlozenaUsluga.IdLekara = usluga.IdLekara;
                odlozenaUsluga.Id = terminiRepozitorijum.getNewId();
                DodajUslugu(odlozenaUsluga);
            }
            DodajUslugu(usluga);

            return uslugaKojaSeOdlaze;
        }

        public ZdravstvenaUsluga OdloziTerminRadiHitnogTermina(Lekar lekar, ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUsluga uslugaKojaSeOdlaze = ZdravstvenaUslugaRepozitorijum.GetInstance.GetUslugaZaTermin(lekar, usluga.Termin.Pocetak);
            if (uslugaKojaSeOdlaze == null) return null;
            return OdloziUslugu(uslugaKojaSeOdlaze);
        }

        public List<ZdravstvenaUsluga> GetUslugeLekaraZaDan(int idLekara, DateTime datum)
        {
            List<ZdravstvenaUsluga> usluge = ZdravstvenaUslugaRepozitorijum.GetInstance.GetTerminByLekarId(idLekara);
            List<ZdravstvenaUsluga> uslugeZaDatum = new List<ZdravstvenaUsluga>();
            foreach(ZdravstvenaUsluga usluga in usluge)
            {
                if(usluga.Termin.Pocetak.Date.Equals(datum))
                {
                    uslugeZaDatum.Add(usluga);
                }
            }
            return uslugeZaDatum;
        }

        public bool jesuliPreklopljeniTermini(Termin termin1, Termin termin2)
        {
            if(termin1.Pocetak <= termin2.Pocetak && termin1.Kraj >= termin2.Kraj)
            {
                return true;
            }
            if(termin2.Pocetak <= termin1.Pocetak && termin2.Kraj >= termin1.Kraj)
            {
                return true;
            }

            return false;
        }

        public ZdravstvenaUsluga KonvertujUModel(ZakaziTetminDTO dto)
        {
            ZdravstvenaUsluga usluga = new ZdravstvenaUsluga(dto.Termin, -1, dto.IdLekara, dto.IdPacijenta, dto.TipUsluge, dto.IdProstorije, false,
                "", "");
            return usluga;
        }

        public ZakaziTetminDTO ZakaziUslugu(ZakaziTetminDTO usluga)
        {
            usluga.ZakazanTermin = true;
            usluga = DalJeLekarNaOdmoru(usluga);
            usluga = DalJeLekarImaSlobodanDan(usluga);
            usluga = DalJeLekarZauzet(usluga);
            usluga = jelRadnoVremeLekara(usluga);
            usluga = DalJeProstorijaZauzeta(usluga);
            if(usluga.ZakazanTermin)
            {
                DodajUslugu(KonvertujUModel(usluga));
            }

            return usluga;
        }

        public ZakaziTetminDTO DalJeLekarImaSlobodanDan(ZakaziTetminDTO usluga)
        {
            if (SlobodniDaniRepozitorijum.GetInstance.DalJeLekarImaSlobodanDan(usluga.IdLekara, usluga.Termin.Pocetak.Date))
            {
                usluga.ZakazanTermin = false;
                usluga.GreskaLekar = "Lekar ima slobodan dan.";
            }
            return usluga;
        }

        public ZakaziTetminDTO DalJeLekarNaOdmoru(ZakaziTetminDTO usluga)
        {
            if(GodisnjiOdmorRepozitorijum.GetInstance.DalJeLekarNaOdmoru(usluga.IdLekara,usluga.Termin.Pocetak.Date))
            {
                usluga.ZakazanTermin = false;
                usluga.GreskaLekar = "Lekar je godi�njem odmoru.";
            }
            return usluga;
        }

        public ZakaziTetminDTO DalJeLekarZauzet(ZakaziTetminDTO uslugaDto)
        {
            List<ZdravstvenaUsluga> usluge = GetUslugeLekaraZaDan(uslugaDto.IdLekara, uslugaDto.Termin.Pocetak);
            foreach(ZdravstvenaUsluga usluga in usluge)
            {
                if(jesuliPreklopljeniTermini(usluga.Termin,uslugaDto.Termin))
                {
                    uslugaDto.GreskaLekar = "Lekar ima zakazan termin u izabranom vremenu.";
                    uslugaDto.ZakazanTermin = false;
                    return uslugaDto;
                }
            }

            return uslugaDto;
        }

        public ZakaziTetminDTO DalJeProstorijaZauzeta(ZakaziTetminDTO uslugaDto)
        {
            List<ZdravstvenaUsluga> uslugePrestorije = GetSviTerminiProstorijeZaDatum(uslugaDto.IdProstorije, uslugaDto.Termin.Pocetak);

            foreach (ZdravstvenaUsluga usluga in uslugePrestorije)
            {
                if (jesuliPreklopljeniTermini(usluga.Termin, uslugaDto.Termin))
                {
                    uslugaDto.GreskaProstorija = "Prostorija je zauzeta u izabranom vremenu.";
                    uslugaDto.ZakazanTermin = false;
                    return uslugaDto;
                }
            }

            return uslugaDto;
        }

        public ZakaziTetminDTO jelRadnoVremeLekara(ZakaziTetminDTO usluga)
        {
       
            RadnoVreme vreme = LekarRepozitorijum.GetInstance.GetById(usluga.IdLekara).radnoVreme;

            if(vreme.PocetakRadnogVremena > usluga.Termin.Pocetak.Hour || vreme.KrajRadnogVremena < usluga.Termin.Kraj.Hour)
            {
                usluga.GreskaRadnoVreme = "Termin nije u granicama radnog vremena lekara";
                usluga.ZakazanTermin = false;
            }

            return usluga;
        }

        public IzvestajDto procenatZauzetosti(int idProstorije,Termin termin)
        {
            
            List<ZdravstvenaUsluga> terminiProstorije = GetSviTerminiProstorije(idProstorije);
            KreatorIzvestajaProstorije kreatorIzvestaja = new KreatorIzvestajaProstorije(terminiProstorije, termin);

            return kreatorIzvestaja.KreirajIzvestaj();
        }


    }
}