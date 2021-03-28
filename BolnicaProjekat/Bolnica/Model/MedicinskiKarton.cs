/***********************************************************************
 * Module:  MedicinskiKarton.cs
 * Author:  Milica
 * Purpose: Definition of the Class MedicinskiKarton
 ***********************************************************************/

using System;

namespace Model
{
   public class MedicinskiKarton
   {
      public System.Collections.ArrayList recept;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetRecept()
      {
         if (recept == null)
            recept = new System.Collections.ArrayList();
         return recept;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetRecept(System.Collections.ArrayList newRecept)
      {
         RemoveAllRecept();
         foreach (Recept oRecept in newRecept)
            AddRecept(oRecept);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddRecept(Recept newRecept)
      {
         if (newRecept == null)
            return;
         if (this.recept == null)
            this.recept = new System.Collections.ArrayList();
         if (!this.recept.Contains(newRecept))
            this.recept.Add(newRecept);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveRecept(Recept oldRecept)
      {
         if (oldRecept == null)
            return;
         if (this.recept != null)
            if (this.recept.Contains(oldRecept))
               this.recept.Remove(oldRecept);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllRecept()
      {
         if (recept != null)
            recept.Clear();
      }
      public System.Collections.ArrayList pregled;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetPregled()
      {
         if (pregled == null)
            pregled = new System.Collections.ArrayList();
         return pregled;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetPregled(System.Collections.ArrayList newPregled)
      {
         RemoveAllPregled();
         foreach (Pregled oPregled in newPregled)
            AddPregled(oPregled);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddPregled(Pregled newPregled)
      {
         if (newPregled == null)
            return;
         if (this.pregled == null)
            this.pregled = new System.Collections.ArrayList();
         if (!this.pregled.Contains(newPregled))
            this.pregled.Add(newPregled);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemovePregled(Pregled oldPregled)
      {
         if (oldPregled == null)
            return;
         if (this.pregled != null)
            if (this.pregled.Contains(oldPregled))
               this.pregled.Remove(oldPregled);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllPregled()
      {
         if (pregled != null)
            pregled.Clear();
      }
      public System.Collections.ArrayList operacija;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetOperacija()
      {
         if (operacija == null)
            operacija = new System.Collections.ArrayList();
         return operacija;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetOperacija(System.Collections.ArrayList newOperacija)
      {
         RemoveAllOperacija();
         foreach (Operacija oOperacija in newOperacija)
            AddOperacija(oOperacija);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddOperacija(Operacija newOperacija)
      {
         if (newOperacija == null)
            return;
         if (this.operacija == null)
            this.operacija = new System.Collections.ArrayList();
         if (!this.operacija.Contains(newOperacija))
            this.operacija.Add(newOperacija);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOperacija(Operacija oldOperacija)
      {
         if (oldOperacija == null)
            return;
         if (this.operacija != null)
            if (this.operacija.Contains(oldOperacija))
               this.operacija.Remove(oldOperacija);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOperacija()
      {
         if (operacija != null)
            operacija.Clear();
      }
      public Pacijent pacijent;
      public System.Collections.ArrayList terapija;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetTerapija()
      {
         if (terapija == null)
            terapija = new System.Collections.ArrayList();
         return terapija;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetTerapija(System.Collections.ArrayList newTerapija)
      {
         RemoveAllTerapija();
         foreach (Terapija oTerapija in newTerapija)
            AddTerapija(oTerapija);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddTerapija(Terapija newTerapija)
      {
         if (newTerapija == null)
            return;
         if (this.terapija == null)
            this.terapija = new System.Collections.ArrayList();
         if (!this.terapija.Contains(newTerapija))
            this.terapija.Add(newTerapija);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveTerapija(Terapija oldTerapija)
      {
         if (oldTerapija == null)
            return;
         if (this.terapija != null)
            if (this.terapija.Contains(oldTerapija))
               this.terapija.Remove(oldTerapija);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllTerapija()
      {
         if (terapija != null)
            terapija.Clear();
      }
   
      private string IdPacijenta;
      private bool Osiguran;
      private KategorijaPacijenta Kategorija;
   
   }
}