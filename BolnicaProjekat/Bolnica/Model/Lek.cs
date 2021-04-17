/***********************************************************************
 * Module:  Lek.cs
 * Author:  Milica
 * Purpose: Definition of the Class Lek
 ***********************************************************************/

using System;

namespace Model
{
   public class Lek
   {
      public int Id { get; set; }
        public string Naziv { get; set; }
        public Boolean Odobren { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }

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
               oldInventar.RemoveLekovi(this);
            }
            if (newInventar != null)
            {
               this.inventar = newInventar;
               this.inventar.AddLekovi(this);
            }
         }
      }
   
   }
}