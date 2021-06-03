/***********************************************************************
 * Module:  PacijentKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.PacijentKontroler
 ***********************************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Servis;
using DTO;

namespace Kontroler
{
   class PacijentKontroler
   {
        private Servis.PacijentServis pacijentServis;
        public PacijentKontroler()
        {
            pacijentServis = new PacijentServis();
        }
        public Model.Pacijent DodajPacijenta(MedicinskiKarton medicinskiKarton, ArrayList ocene, int id, bool pacijentGost, bool hospitalizovan, bool spamUser, bool logickiObrisan, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja)
        {
            medicinskiKarton.IdPacijent = id;
            Model.Pacijent noviPacijent = new Model.Pacijent( medicinskiKarton,  ocene,  id,  pacijentGost,  hospitalizovan,  spamUser,  logickiObrisan,  korisnickoIme,  sifra,  ime,
             prezime,  pol,  email,  telefon,  datumRodjenja,
             jmbg,  drzavljanstvo,  adresaStanovanja);

            pacijentServis.DodajPacijenta(noviPacijent);
            return noviPacijent;
        }
      
        public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
        {
            pacijentServis.AzurirajPacijenta(pacijent);
             return pacijent;
         }
      
        public void ObrisiPacijenta(PacijentDTO pacijent)
        {
            pacijentServis.ObrisiPacijenta(pacijent);
        }
      
        public ObservableCollection<Model.Pacijent> GetAll()
        {
            return pacijentServis.GetAll();
        }

        public ObservableCollection<PacijentDTO> GetPacijentiDto()
        {
            return pacijentServis.GetPacijentiDto();
        }

        public void SaveData()
        {
            pacijentServis.SaveData();
        }

        public PacijentDTO PrijavaPacijenta(String korisnickoIme, String lozinka)
        {
            return pacijentServis.PrijaviPacijenta(korisnickoIme, lozinka);
        }

    }
}