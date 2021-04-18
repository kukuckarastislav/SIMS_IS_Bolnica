/***********************************************************************
 * Module:  TerminiServis.cs
 * Author:  lacik
 * Purpose: Definition of the Class Servis.TerminiServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
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

            
        public List<ZdravstvenaUsluga> getAvailableAppointments(Lekar OdabraniLekar,DateTime pocetak,DateTime kraj,int prioritet)
        {
            List<ZdravstvenaUsluga> pregledi = getAppointments(OdabraniLekar, pocetak, kraj);

            if (pregledi == null && prioritet == 0)
                pregledi = getCloseAppointmentsByTime(pocetak, kraj);
            else
                pregledi = getCloseAppointmentsByDoctor(OdabraniLekar,pocetak,kraj);
            return pregledi;
        }


        public List<ZdravstvenaUsluga> getAppointments(Lekar OdabraniLekar, DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>(); //ret value

            List<ZdravstvenaUsluga> terminiLekara = terminiRepozitorijum.getTerminiBylekarId(OdabraniLekar.Id); //dobavi zauzete termine iz repoz

            int krajSati = Convert.ToInt32(OdabraniLekar.radnoVreme.KrajRadnogVremena);
            int pocetakSati = Convert.ToInt32(OdabraniLekar.radnoVreme.PocetakRadnogVremena);

            DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetakSati, 0, 0);
            DateTime krajkRadnogVremena_ = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, krajSati, 0, 0);

            TimeSpan period = new TimeSpan(0, 0, 30, 0, 0); //fiksan period od 30 minuta

            //redom generise listu slobodnih termina lekara 
            while (pocetakRadnogVremena + period < krajkRadnogVremena_)
            {
                ZdravstvenaUsluga pregled = new ZdravstvenaUsluga(new Termin(pocetakRadnogVremena, pocetakRadnogVremena + period), OdabraniLekar.Id);
                if (terminiLekara.Contains(pregled))
                    continue;

                pregledi.Add(pregled);
                pocetakRadnogVremena += period;
            }

            return pregledi;
        }

        public List<ZdravstvenaUsluga> getCloseAppointmentsByTime(DateTime pocetak, DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();

            foreach (Lekar lekar in lekarRepozitorijum.GetAll())
            {
                int krajSati = Convert.ToInt32(lekar.radnoVreme.KrajRadnogVremena);
                int pocetakSati = Convert.ToInt32(lekar.radnoVreme.PocetakRadnogVremena); 

                DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetak.Hour, 0, 0);
                DateTime krajkRadnogVremena_ = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, kraj.Hour, 0, 0);

               // pregledi.AddRange(getAppointments(lekar, pocetakRadnogVremena, krajkRadnogVremena_);
            }
            return pregledi;
        }
        public List<ZdravstvenaUsluga> getCloseAppointmentsByDoctor(Lekar OdabraniLekar,DateTime pocetak,DateTime kraj)
        {
            List<ZdravstvenaUsluga> pregledi = new List<ZdravstvenaUsluga>();

            int krajSati = Convert.ToInt32(OdabraniLekar.radnoVreme.KrajRadnogVremena);
            int pocetakSati = Convert.ToInt32(OdabraniLekar.radnoVreme.PocetakRadnogVremena);

            DateTime pocetakRadnogVremena = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, pocetak.Hour, 0, 0);
            DateTime krajkRadnogVremena_ = new DateTime(pocetak.Year, pocetak.Month, pocetak.Day, kraj.Hour, 0, 0);

            pregledi = getAppointments(OdabraniLekar, pocetakRadnogVremena, krajkRadnogVremena_);
            return pregledi;
        }

        public static List<ZdravstvenaUsluga> getFirstAvailableAppointments()
        {
            //ovo zasad nije neophodno rekla bih
            return null;
        }



   
   }
}