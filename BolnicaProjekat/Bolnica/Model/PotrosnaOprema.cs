/***********************************************************************
 * Module:  PotrosnaOprema.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class PotrosnaOprema
 ***********************************************************************/

using System;

namespace Model
{
   public class PotrosnaOprema
   {
      public Inventar inventar;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Inventar GetInventar()
      {
         return inventar;
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newInventar</param>
      public void SetInventar(Inventar newInventar)
      {
         if (this.inventar != newInventar)
         {
            if (this.inventar != null)
            {
               Inventar oldInventar = this.inventar;
               this.inventar = null;
               oldInventar.RemovePotrosnaOprema(this);
            }
            if (newInventar != null)
            {
               this.inventar = newInventar;
               this.inventar.AddPotrosnaOprema(this);
            }
         }
      }
   
      private string Naziv;
      private string Opis;
      private int Id;
      private int Kolicina;
      private double Cena;
   
   }
}