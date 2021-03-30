/***********************************************************************
 * Module:  StatickaOprema.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class StatickaOprema
 ***********************************************************************/

using System;

namespace Model
{
   public class StatickaOprema
   {
      public Inventar inventar;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Inventar GetInventar()
      {
         return inventar;
      }

        public StatickaOprema()
        {
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
               oldInventar.RemoveStatickaOprema(this);
            }
            if (newInventar != null)
            {
               this.inventar = newInventar;
               this.inventar.AddStatickaOprema(this);
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