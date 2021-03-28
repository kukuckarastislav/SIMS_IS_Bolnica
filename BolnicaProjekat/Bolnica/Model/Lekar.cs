/***********************************************************************
 * Module:  OpstiLekar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Lekar.OpstiLekar
 ***********************************************************************/

using System;

namespace Model
{
   public class Lekar : Osoblje
   {
      public Pregled KreiranjePregleda()
      {
         // TODO: implement
         return null;
      }
      
      public Recept KreiranjeRecepta()
      {
         // TODO: implement
         return null;
      }
      
      public bool AzuriranjePregleda(Pregled pregled)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzuriranjeRecepta(Recept recept)
      {
         // TODO: implement
         return false;
      }
      
      public bool OtkazivanjePregleda(Pregled pregled)
      {
         // TODO: implement
         return false;
      }
   
      private int IdLekara;
      private bool Specijalista;
      private Odeljenje Odeljenje;
   
   }
}