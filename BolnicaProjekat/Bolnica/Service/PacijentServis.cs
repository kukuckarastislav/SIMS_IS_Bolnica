/***********************************************************************
 * Module:  PacijentServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.PacijentServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repozitorijum;

namespace Servis
{
   public class PacijentServis
   {
      public Model.Pacijent DodajPacijenta(Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
      {
            PacijentRepozitorijum.GetInstance.AzurirajPacijenta(pacijent);
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
   
      public Repozitorijum.PacijentRepozitorijum pacijentRepozitorijum;
   
   }
}