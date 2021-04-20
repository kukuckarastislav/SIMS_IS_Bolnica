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

namespace Kontroler
{
   public class PacijentKontroler
   {
       
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
      
      public Model.Pacijent ObrisiPacijenta(Model.Pacijent pacijent)
      {
            pacijentServis.ObrisiPacijenta(pacijent);
         return pacijent;
      }
      
      public ObservableCollection<Model.Pacijent> GetAll()
      {
            return pacijentServis.GetAll();
      }
      
      public Model.Pacijent GetById(long id)
      {
         // TODO: implement
         return null;
      }
        public void SaveData()
        {
            pacijentServis.SaveData();
        }
   
      public Servis.PacijentServis pacijentServis;
   
   }
}