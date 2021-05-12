/***********************************************************************
 * Module:  UpravnikKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.UpravnikKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Servis;

namespace Kontroler
{
    public class UpravnikKontroler
   {
        public UpravnikServis upravnikServis;
        public UpravnikKontroler()
        {
            upravnikServis = new UpravnikServis();
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

        public Upravnik PrijavaUpravnika(String korisnickoIme, String lozinka)
        {
            return upravnikServis.PrijaviUpravnika(korisnickoIme, lozinka);
        }

    }
}