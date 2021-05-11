/***********************************************************************
 * Module:  SekretarServis.cs
 * Author:  Mihajlo
 * Purpose: Definition of the Class Servis.SekretarServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using Repozitorijum;

namespace Servis
{
   public class SekretarServis
   {
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

        public bool ProveriPostojanjeSekretara(string korisnickoIme)
        {
            return SekretarRepozitorijum.GetInstance.ProveriPostojanjeSekretara(korisnickoIme);
        }

        public Sekretar PrijaviSekretara(string korisnickoIme, string lozinka)
        {
            if(ProveriPostojanjeSekretara(korisnickoIme))
            {
                return SekretarRepozitorijum.GetInstance.GetByImeLozinka(korisnickoIme, lozinka);
            }

            return null;
        }
   
      public Repozitorijum.SekretarRepozitorijum sekretarRepozitorijum;
   
   }
}