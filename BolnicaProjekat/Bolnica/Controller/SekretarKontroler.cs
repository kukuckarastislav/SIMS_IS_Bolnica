/***********************************************************************
 * Module:  SekretarKontroler.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Kontroler.SekretarKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Servis;

namespace Kontroler
{
    
    public class SekretarKontroler
   {
        public Servis.SekretarServis sekretarServis;
        public SekretarKontroler()
        {
            sekretarServis = new SekretarServis();
        }
      public Model.Sekretar DodajSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar AzurirajSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar ObrisiSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public List<Sekretar> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar GetById(long id)
      {
         // TODO: implement
         return null;
      }

        public Sekretar PrijavaSekretara(String korisnickoIme,String lozinka)
        {
            return sekretarServis.PrijaviSekretara(korisnickoIme, lozinka);
        }
   
   }
}