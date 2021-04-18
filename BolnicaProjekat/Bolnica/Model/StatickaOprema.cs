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
      public Inventar inventar { get; set; }

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
               oldInventar.RemoveStatickaOprema(this);
            }
            if (newInventar != null)
            {
               this.inventar = newInventar;
               this.inventar.AddStatickaOprema(this);
            }
         }
      }
   
      public string Naziv { get; set; }
        public string Opis { get; set; }
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }

    }
}