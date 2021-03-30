/***********************************************************************
 * Module:  Ocjena.cs
 * Author:  Milica
 * Purpose: Definition of the Class Ocjena
 ***********************************************************************/

using System;

namespace Model
{
   public class Ocena
   {
      public string Komentar;
      public VrijednostOcjene OdabranaOcena;
      
      public Pacijent pacijent;
      
      /// <pdGenerated>default parent getter</pdGenerated>
      public Pacijent GetPacijent()
      {
         return pacijent;
      }

      public Ocena()
      {
        
      }
      
      /// <pdGenerated>default parent setter</pdGenerated>
      /// <param>newPacijent</param>
      public void SetPacijent(Pacijent newPacijent)
      {
         if (this.pacijent != newPacijent)
         {
            if (this.pacijent != null)
            {
               Pacijent oldPacijent = this.pacijent;
               this.pacijent = null;
               oldPacijent.RemoveOcene(this);
            }
            if (newPacijent != null)
            {
               this.pacijent = newPacijent;
               this.pacijent.AddOcene(this);
            }
         }
      }
   
   }
}