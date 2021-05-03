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
        public static Repozitorijum.LekarRepozitorijum lekarRepozitorijum;
        public Repozitorijum.ProstorijeRepozitorijum prostorijeRepozitorijum;
        public static Repozitorijum.ZdravstvenaUslugaRepozitorijum terminiRepozitorijum;


        public static List<ZdravstvenaUsluga> getAvailableAppointments(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj, int prioritet)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();
            pregledi = getAppointments(OdabraniLekar, pocetak, kraj);

            if (pregledi.Count == 0 && prioritet == 0)
            {
                pregledi = getCloseAppointmentsByTime(pocetak, kraj);
            }
            else if (pregledi.Count == 0 && prioritet == 1)
            {
                pregledi = getCloseAppointmentsByDoctor(OdabraniLekar, pocetak, kraj);
            }
            return pregledi;
        }


        public static List<ZdravstvenaUsluga> getAppointments(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>(); //ret value
            List<ZdravstvenaUsluga> terminiLekara = ZdravstvenaUslugaRepozitorijum.GetInstance.getTerminiBylekarId(OdabraniLekar.Id);


            int krajSati = OdabraniLekar.radnoVreme.KrajRadnogVremena;
            int pocetakSati = OdabraniLekar.radnoVreme.PocetakRadnogVremena;


            if (pocetak.Hour > pocetakSati)
                pocetakSati = pocetak.Hour;
            if (kraj.Hour < krajSati)
                krajSati = kraj.Hour;


            DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0);
            DateTime krajkRadnogVremena_ = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, krajSati, 0, 0);

            TimeSpan period = new TimeSpan(0, 0, 30, 0, 0); //ovo izvuci kao konstantu na nivou klase, ali neka ga zasad
            bool fleg = false;
            //redom generise listu slobodnih termina lekara 
            while (pocetakRadnogVremena + period <= krajkRadnogVremena_)
            {
                ZdravstvenaUsluga pregled = new ZdravstvenaUsluga(new Termin(pocetakRadnogVremena, pocetakRadnogVremena + period), 1, OdabraniLekar.Id, -1, TipUsluge.Pregled, -1, false, "", "");

                //if (terminiLekara.Contains(pregled))
                //continue;
                foreach (ZdravstvenaUsluga zu in terminiLekara)
                {
                    if (zu.Termin.Pocetak.Equals(pregled.Termin.Pocetak))
                    {
                        fleg = true;
                        break;
                    }

                }
                if (fleg == false) pregledi.Add(pregled);
                pocetakRadnogVremena += period;
                fleg = false;
            }

            return pregledi;
        }


        public static List<ZdravstvenaUsluga> getCloseAppointmentsByTime(DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();
            List<ZdravstvenaUsluga> pomocna = new List<ZdravstvenaUsluga>();

            foreach (Lekar lekar in Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs())
            {
                pomocna = getAppointments(lekar, pocetak, kraj);
                pregledi.AddRange(pomocna);

            }
            return pregledi;
        }
        public static List<ZdravstvenaUsluga> getCloseAppointmentsByDoctor(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();

            int krajSati = Convert.ToInt32(OdabraniLekar.radnoVreme.KrajRadnogVremena);
            int pocetakSati = Convert.ToInt32(OdabraniLekar.radnoVreme.PocetakRadnogVremena);

            DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0); //posto sam stavila d=DateTime u construktor pa ne mogu samo int
            DateTime krajkRadnogVremena_ = new DateTime(kraj.Year, kraj.Month, kraj.Day, krajSati, 0, 0);

            pregledi = getAppointments(OdabraniLekar, pocetakRadnogVremena, krajkRadnogVremena_);
            return pregledi;
        }


        public static bool PomjeranjeTerminaMoguce(ZdravstvenaUsluga pregled, DateTime noviPocetak)
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



        public static List<ZdravstvenaUsluga> getFirstAvailableAppointments()
        {
            //ovo zasad nije neophodno rekla bih
            return null;
        }

       public static ObservableCollection<DTORadniKalendar> getUslugeLekara(Lekar l)
        {
            ObservableCollection<DTORadniKalendar> lista = new ObservableCollection<DTORadniKalendar>();
            ObservableCollection<ZdravstvenaUsluga> usluge = ZdravstvenaUslugaRepozitorijum.GetInstance.GetTerminByLekarId(l.Id);
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
                List<ZdravstvenaUsluga> slobodniTerminiLekara = getAppointments(LekarRepozitorijum.GetInstance.GetById(usluga.IdLekara),
                                                                new DateTime(datum.Year, datum.Month, datum.Day, 0, 0, 0),
                                                                new DateTime(datum.Year, datum.Month, datum.Day, 23, 59, 0));
                if (slobodniTerminiLekara.Count > 0)
                {
                    return slobodniTerminiLekara.ElementAt(0);
                }

            }



            return null;
        }

    }
}