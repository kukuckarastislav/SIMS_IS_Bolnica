/***********************************************************************
 * Module:  PacijentServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.PacijentServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Repozitorijum;
using DTO;
using Bolnica.view.sekretar;

namespace Servis
{
   public class PacijentServis
   {
        public Repozitorijum.PacijentRepozitorijum pacijentRepozitorijum;
        public Model.Pacijent DodajPacijenta(Model.Pacijent pacijent)
        {
            pacijent.Id = PacijentRepozitorijum.GetInstance.GetNewId();
            PacijentRepozitorijum.GetInstance.DodajPacijenta(pacijent);
            return pacijent;
        }
      
        public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
        {
            PacijentRepozitorijum.GetInstance.AzurirajPacijenta(pacijent);
            return pacijent;
        }
      
        public void ObrisiPacijenta(PacijentDTO pacijent)
        {
            PacijentRepozitorijum.GetInstance.ObrisiPacijenta(pacijent);
        }

        public bool ProveriPostojanjePacijenta(string korisnickoIme)
        {
            return PacijentRepozitorijum.GetInstance.ProveriPostojanjePacijenta(korisnickoIme);
        }

        public Pacijent PrijaviPacijenta(string korisnickoIme, string lozinka)
        {
            if (ProveriPostojanjePacijenta(korisnickoIme))
            {
                return PacijentRepozitorijum.GetInstance.GetByImeLozinka(korisnickoIme, lozinka);
            }

            return null;
        }

        public ObservableCollection<Model.Pacijent> GetAll()
        {
            return PacijentRepozitorijum.GetInstance.GetAll();
        }

        public ObservableCollection<PacijentDTO> GetPacijentiDto()
        {
            ObservableCollection<Pacijent> sviPacijenti = PacijentRepozitorijum.GetInstance.GetNeobrisaniPacijenti();
            ObservableCollection<PacijentDTO> dtoPacijenti = new ObservableCollection<PacijentDTO>();

            foreach(Pacijent pacijent in sviPacijenti)
            {
                dtoPacijenti.Add(KonvertujPacijentaUPacijentDTO(pacijent));
            }

            return dtoPacijenti;
        }

        public PacijentDTO KonvertujPacijentaUPacijentDTO(Pacijent pacijent)
        {
            return new PacijentDTO(pacijent.Id, pacijent.Ime, pacijent.Prezime, pacijent.Email, pacijent.Telefon, pacijent.Jmbg);
        }

        public void SaveData()
        {
            PacijentRepozitorijum.GetInstance.SaveData();
        }
    }
}