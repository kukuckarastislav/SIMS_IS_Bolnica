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
      private string IdLeka;
      private string Naziv;
      private int Kolicina;
      private bool Odobren;
      private double Cena;
      
      private Inventar inventar;
      
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