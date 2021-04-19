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
            Notifikacija novaNotifikacija = new Notifikacija(id + 1, usluga.Id, usluga.IdPacijenta, usluga.IdLekara, false, false, "");
            if (usluga.TipUsluge == TipUsluge.Pregled)
                novaNotifikacija.Opis = "Zakazan vam je pregled,";
            else
                novaNotifikacija.Opis = "Zakazana vam je operacija, ";
            novaNotifikacija.Opis = novaNotifikacija.Opis + " dana " + usluga.Termin.Pocetak.ToShortDateString() + ", sa pocetkom u " + usluga.Termin.Pocetak.ToShortTimeString()+".";
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