/***********************************************************************
 * Module:  NotifikacijeServis.cs
 * Author:  lacik
 * Purpose: Definition of the Class Servis.NotifikacijeServis
 ***********************************************************************/

using System;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using Model;
using Bolnica.Repository;
using Repozitorijum;

namespace Servis
{
   public class NotifikacijeServis
   {
        private PacijentRepozitorijum pacijentRepozitorijum;
        private LekarRepozitorijum lekarRepozitorijum;
        private NotifikacijaRepozitorijum notifikacijaRepozitorijum;

        public void ZakaziTermin(ZdravstvenaUsluga usluga)
        {
            int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;
            // public Notifikacija(int id, int idZdravstveneUsluge, int idPacijenta, int idLekara,bool pacijentProcitao, bool lekarProcitao, string opis)
            Notifikacija novaNotifikacija = new Notifikacija(id + 1, usluga.Id, usluga.IdPacijenta, usluga.IdLekara, false, false, "");
            if (usluga.TipUsluge == TipUsluge.Pregled)
                novaNotifikacija.Opis = "Zakazan vam je pregled,";
            else
                novaNotifikacija.Opis = "Zakazana vam je operacija, ";
            novaNotifikacija.Opis = novaNotifikacija.Opis + " dana " + usluga.Termin.Pocetak.ToShortDateString() + ", sa pocetkom u " + usluga.Termin.Pocetak.ToShortTimeString()+".";
            NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(novaNotifikacija);
        }
        public static void ReceptNotifikacija(Recept recept, DateTime VremeUzimanja)
        {
            TimeSpan ts = new TimeSpan(0,3,0,0,0);
            DateTime vrijemePojavljivanja = VremeUzimanja - ts;
            String vrPojavljivanja = vrijemePojavljivanja.ToString("yyyy-MM-dd HH:mm tt");

            int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;

            Notifikacija novaNotifikacija = new Notifikacija(0 - id-1, recept.Id, recept.IdPacijenta, recept.IdLekara, false, true, "");
            novaNotifikacija.Opis = vrPojavljivanja+"*"+"   Podsjecamo vas da danas, u " + VremeUzimanja.ToString("HH:mm tt") + " treba da popijete vas lijek.";
            NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(novaNotifikacija);
        
        }
  
        public void OtkaziTermin(ZdravstvenaUsluga usluga)
        {
            int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;
            Notifikacija novaNotifikacija = new Notifikacija(id + 1, -1, usluga.IdPacijenta, usluga.IdLekara, false, false, "");
            if (usluga.TipUsluge == TipUsluge.Pregled)
                novaNotifikacija.Opis = "Otkazan vam je pregled,";
            else
                novaNotifikacija.Opis = "Otkazana vam je operacija, ";
            novaNotifikacija.Opis = novaNotifikacija.Opis + " dana " + usluga.Termin.Pocetak.ToShortDateString() + ", sa pocetkom u " + usluga.Termin.Pocetak.ToShortTimeString() + ".";
            NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(novaNotifikacija);
        }

    }
}