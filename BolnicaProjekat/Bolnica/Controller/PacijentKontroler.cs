/***********************************************************************
 * Module:  PacijentKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.PacijentKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
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
      public Model.Pacijent DodajPacijenta(Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
      {
            pacijentServis.AzurirajPacijenta(pacijent);
         return pacijent;
      }
      
      public Model.Pacijent ObrisiPacijenta(Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public List<Pacijent> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pacijent GetById(long id)
      {
         // TODO: implement
         return null;
      }
   
      public Servis.PacijentServis pacijentServis;
   
   }
}