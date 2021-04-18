/***********************************************************************
 * Module:  Inventar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Inventar
 ***********************************************************************/

using System;

namespace Model
{
   public class Inventar
   {
        public System.Collections.ArrayList dinamickaOprema;

        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetDinamickaOprema()
      {
         if (dinamickaOprema == null)
            dinamickaOprema = new System.Collections.ArrayList();
         return dinamickaOprema;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetDinamickaOprema(System.Collections.ArrayList newDinamickaOprema)
      {
         RemoveAllDinamickaOprema();
         foreach (DinamickaOprema oDinamickaOprema in newDinamickaOprema)
            AddDinamickaOprema(oDinamickaOprema);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddDinamickaOprema(DinamickaOprema newDinamickaOprema)
      {
         if (newDinamickaOprema == null)
            return;
         if (this.dinamickaOprema == null)
            this.dinamickaOprema = new System.Collections.ArrayList();
         if (!this.dinamickaOprema.Contains(newDinamickaOprema))
         {
            this.dinamickaOprema.Add(newDinamickaOprema);
            newDinamickaOprema.SetInventar(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveDinamickaOprema(DinamickaOprema oldDinamickaOprema)
      {
         if (oldDinamickaOprema == null)
            return;
         if (this.dinamickaOprema != null)
            if (this.dinamickaOprema.Contains(oldDinamickaOprema))
            {
               this.dinamickaOprema.Remove(oldDinamickaOprema);
               oldDinamickaOprema.SetInventar((Inventar)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllDinamickaOprema()
      {
         if (dinamickaOprema != null)
         {
            System.Collections.ArrayList tmpDinamickaOprema = new System.Collections.ArrayList();
            foreach (DinamickaOprema oldDinamickaOprema in dinamickaOprema)
               tmpDinamickaOprema.Add(oldDinamickaOprema);
            dinamickaOprema.Clear();
            foreach (DinamickaOprema oldDinamickaOprema in tmpDinamickaOprema)
               oldDinamickaOprema.SetInventar((Inventar)null);
            tmpDinamickaOprema.Clear();
         }
      }
      public System.Collections.ArrayList statickaOprema;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetStatickaOprema()
      {
         if (statickaOprema == null)
            statickaOprema = new System.Collections.ArrayList();
         return statickaOprema;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetStatickaOprema(System.Collections.ArrayList newStatickaOprema)
      {
         RemoveAllStatickaOprema();
         foreach (StatickaOprema oStatickaOprema in newStatickaOprema)
            AddStatickaOprema(oStatickaOprema);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddStatickaOprema(StatickaOprema newStatickaOprema)
      {
         if (newStatickaOprema == null)
            return;
         if (this.statickaOprema == null)
            this.statickaOprema = new System.Collections.ArrayList();
         if (!this.statickaOprema.Contains(newStatickaOprema))
         {
            this.statickaOprema.Add(newStatickaOprema);
            newStatickaOprema.SetInventar(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveStatickaOprema(StatickaOprema oldStatickaOprema)
      {
         if (oldStatickaOprema == null)
            return;
         if (this.statickaOprema != null)
            if (this.statickaOprema.Contains(oldStatickaOprema))
            {
               this.statickaOprema.Remove(oldStatickaOprema);
               oldStatickaOprema.SetInventar((Inventar)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllStatickaOprema()
      {
         if (statickaOprema != null)
         {
            System.Collections.ArrayList tmpStatickaOprema = new System.Collections.ArrayList();
            foreach (StatickaOprema oldStatickaOprema in statickaOprema)
               tmpStatickaOprema.Add(oldStatickaOprema);
            statickaOprema.Clear();
            foreach (StatickaOprema oldStatickaOprema in tmpStatickaOprema)
               oldStatickaOprema.SetInventar((Inventar)null);
            tmpStatickaOprema.Clear();
         }
      }
   
      private int IdProstorije;
      
      private System.Collections.ArrayList lekovi;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetLekovi()
      {
         if (lekovi == null)
            lekovi = new System.Collections.ArrayList();
         return lekovi;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetLekovi(System.Collections.ArrayList newLekovi)
      {
         RemoveAllLekovi();
         foreach (Lek oLek in newLekovi)
            AddLekovi(oLek);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddLekovi(Lek newLek)
      {
         if (newLek == null)
            return;
         if (this.lekovi == null)
            this.lekovi = new System.Collections.ArrayList();
         if (!this.lekovi.Contains(newLek))
         {
            this.lekovi.Add(newLek);
            newLek.SetInventar(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveLekovi(Lek oldLek)
      {
         if (oldLek == null)
            return;
         if (this.lekovi != null)
            if (this.lekovi.Contains(oldLek))
            {
               this.lekovi.Remove(oldLek);
               oldLek.SetInventar((Inventar)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllLekovi()
      {
         if (lekovi != null)
         {
            System.Collections.ArrayList tmpLekovi = new System.Collections.ArrayList();
            foreach (Lek oldLek in lekovi)
               tmpLekovi.Add(oldLek);
            lekovi.Clear();
            foreach (Lek oldLek in tmpLekovi)
               oldLek.SetInventar((Inventar)null);
            tmpLekovi.Clear();
         }
      }
   
   }
}