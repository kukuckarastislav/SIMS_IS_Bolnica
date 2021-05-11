/***********************************************************************
 * Module:  UpravnikServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.UpravnikServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repozitorijum;

namespace Servis
{
   public class UpravnikServis
   {
        public UpravnikServis()
        {

        }
      public Upravnik DodajPacijenta(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik AzurirajUpravnika(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik ObrisiUpravnika(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public List<Upravnik> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik GetById(long id)
      {
         // TODO: implement
         return null;
      }

        public bool ProveriPostojanjeUpravnika(string korisnickoIme)
        {
            return UpravnikRepozitorijum.GetInstance.ProveriPostojanjeUpravnika(korisnickoIme);
        }

        public Upravnik PrijaviUpravnika(string korisnickoIme, string lozinka)
        {
            if (ProveriPostojanjeUpravnika(korisnickoIme))
            {
                return UpravnikRepozitorijum.GetInstance.GetByImeLozinka(korisnickoIme, lozinka);
            }

            return null;
        }

        public Repozitorijum.UpravnikRepozitorijum upravnikRepozitorijum;
   
   }
}