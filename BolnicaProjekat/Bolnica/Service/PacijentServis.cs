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
      
        public Model.Pacijent ObrisiPacijenta(Model.Pacijent pacijent)
        {
            PacijentRepozitorijum.GetInstance.ObrisiPacijenta(pacijent);
            return pacijent;
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

        public void SaveData()
        {
            PacijentRepozitorijum.GetInstance.SaveData();
        }
    }
}