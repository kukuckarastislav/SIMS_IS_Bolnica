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
using Repozitorijum;
using Interface;
using Threads;

namespace Servis
{
   class NotifikacijeServis : IObserver
   {
        private PacijentRepozitorijum pacijentRepozitorijum;
        private LekarRepozitorijum lekarRepozitorijum;
        private NotifikacijaRepozitorijum notifikacijaRepozitorijum;
        private readonly DateTime PrviDanAnkete = new DateTime(2021,1,1);
        private readonly DateTime DrugiDanAnkete = new DateTime(2021,7,1);


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

        internal void ObrisiNotifikaciju(int idPacijenta, int idNotifikacije)
        {
            NotifikacijaRepozitorijum.GetInstance.ObrisiNotifikacijuPacijenta(idPacijenta, idNotifikacije);
        }

        internal ObservableCollection<Notifikacija> GetNotifikacijePacijenta(int idPacijenta)
        {
            DateTime now = DateTime.Now;
            if ((now.Day == PrviDanAnkete.Day && now.Month == PrviDanAnkete.Month && !DobioNotifikaciju(idPacijenta)) ||
                (now.Day == DrugiDanAnkete.Day && now.Month == DrugiDanAnkete.Month) && !DobioNotifikaciju(idPacijenta))
            {
                if (!DobioNotifikaciju(idPacijenta))
                {
                    string text = "Kliknite na ovu notifikaciju da biste popunili anketu o nasoj bolnici!";
                    NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(new Notifikacija(0, 0, idPacijenta, 0, false, false, text));
                }
            }
            return NotifikacijaRepozitorijum.GetInstance.GetByPatientId(idPacijenta);
        }
        public bool DobioNotifikaciju(int idPacijenta)
        {
            ObservableCollection<Notifikacija> notifikacije = Repozitorijum.NotifikacijaRepozitorijum.GetInstance.GetByPatientId(idPacijenta);
            foreach (Notifikacija n in notifikacije)
            {
                if (n.Id == 0)
                    return true;
            }
            return false;
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

        public void Update(ISubject subject)
        {
            if(subject is UserSuspension userSuspension)
            {
                int id = NotifikacijaRepozitorijum.GetInstance.GetAll().Count;
                NotifikacijaRepozitorijum.GetInstance.DodajNotifikaciju(new Notifikacija(id + 1, -1, userSuspension.Patientid, -1, false, false,
                                                                         " Vas period suspenzije je istekao i sa tim u vezi, vise niste blokirani."));
            }
            
        }
    }
}