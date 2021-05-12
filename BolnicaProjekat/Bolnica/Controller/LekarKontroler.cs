/***********************************************************************
 * Module:  LekarKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.LekarKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Servis;

namespace Kontroler
{
   public class LekarKontroler
   {

        public LekarKontroler()
        {
            lekarServis = new LekarServis();
        }
      public Lekar DodajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Lekar AzurirajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Lekar ObrisiLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public List<Lekar> GetAll()
      {
         // TODO: implement
         return null;
      }

        public ObservableCollection<Model.Lekar> GetAllObs()
        {
            return lekarServis.GetAllObs();
        }

        public Model.Lekar GetById(long id)
      {
         // TODO: implement
         return null;
      }

        public Lekar PrijavaLekara(String korisnickoIme, String lozinka)
        {
            return lekarServis.PrijaviLekara(korisnickoIme, lozinka);
        }

        public Servis.LekarServis lekarServis;
   
   }
}