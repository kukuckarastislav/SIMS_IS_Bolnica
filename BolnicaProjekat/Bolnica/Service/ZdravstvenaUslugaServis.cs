/***********************************************************************
 * Module:  TerminiServis.cs
 * Author:  lacik
 * Purpose: Definition of the Class Servis.TerminiServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Media;
using Model;
using Repozitorijum;

namespace Servis
{
    public class ZdravstvenaUslugaServis
    {
        public Repozitorijum.PacijentRepozitorijum pacijentRepozitorijum;
        public Repozitorijum.LekarRepozitorijum lekarRepozitorijum;
        public Repozitorijum.ProstorijeRepozitorijum prostorijeRepozitorijum;
        public Repozitorijum.ZdravstvenaUslugaRepozitorijum terminiRepozitorijum;
        public  TimeSpan trajanjePregleda = new TimeSpan(0, 0, 30, 0, 0);

        public List<ZdravstvenaUsluga> GetSlobodniTermini(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)
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

        public List<ZdravstvenaUsluga> GetSlobodniTerminiLekara(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
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

        public bool JeTerminZauzet(Lekar OdabraniLekar, ZdravstvenaUsluga pregled)
        {
            List<ZdravstvenaUsluga> terminiLekara = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiBylekarId(OdabraniLekar.Id);

            foreach (ZdravstvenaUsluga termin in terminiLekara)
            {
                if (termin.Termin.Pocetak.Equals(pregled.Termin.Pocetak)) return true;
            }

            return false;
        }

        public Termin GetRadnoVremeLekara(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            int krajSati = OdabraniLekar.radnoVreme.KrajRadnogVremena;
            int pocetakSati = OdabraniLekar.radnoVreme.PocetakRadnogVremena;

            if (pocetak.Hour > pocetakSati) pocetakSati = pocetak.Hour;
            if (kraj.Hour < krajSati) krajSati = kraj.Hour;

            return new Termin(new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0),
                                new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, krajSati, 0, 0));
        }

        public List<ZdravstvenaUsluga> GetPriblizniTerminiPoVremenu(DateTime pocetak, DateTime kraj)
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

        public List<ZdravstvenaUsluga> GetPriblizniTerminiPoLekaru(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
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

            //jako primitivno znam, ali radi posao
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

        public List<ZdravstvenaUsluga> getFirstAvailableAppointments()
        {
            //ovo zasad nije neophodno rekla bih
            return null;
        }

        public static ObservableCollection<DTOUslugaLekar> getUslugePacijenta(Pacijent p)
        {
            ObservableCollection<DTOUslugaLekar> lista = new ObservableCollection<DTOUslugaLekar>();
            ObservableCollection<ZdravstvenaUsluga> usluge = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiByPacijentId(p.Id);
            foreach (ZdravstvenaUsluga zu in usluge)
            {
                lista.Add(new DTOUslugaLekar(zu, LekarRepozitorijum.GetInstance.GetById(zu.IdLekara)));
            }


            return lista;
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {

            usluga.Id = ZdravstvenaUslugaRepozitorijum.GetInstance.getLastId() + 1;
            return ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(usluga);
        }
        public void OtkaziUslugu(ZdravstvenaUsluga usluga)
        {
            ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(usluga);
        }

        public ZdravstvenaUsluga OdloziUslugu(ZdravstvenaUsluga usluga)
        {
            int maxBrojDanaOdlaganja = 3;
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
        internal ObservableCollection<ZdravstvenaUsluga> GetTerminiPacijenta(int id)
        {
            return Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiByPacijentId(id);
        }

    }
}