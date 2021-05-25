/***********************************************************************
 * Module:  MedicinskiKarton.cs
 * Author:  Milica
 * Purpose: Definition of the Class MedicinskiKarton
 ***********************************************************************/

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Model
{
   public class MedicinskiKarton
   {

        public MedicinskiKarton(int idPacijenta, bool osiguran, ArrayList zdravstvenaUsluga, Terapija terapija, List<string> alergeni)
        {
            IdPacijent = idPacijenta;
            Osiguran = osiguran;
            ZdravstvenaUsluga = zdravstvenaUsluga;
            Terapija = terapija;
            Alergeni = alergeni;
        }

        public MedicinskiKarton()
        {
        }

        [JsonInclude]
        public int IdPacijent { get; set; }
        [JsonInclude]
        public bool Osiguran { get; set; }
        [JsonInclude]
        public ArrayList ZdravstvenaUsluga { get; set; }
        [JsonInclude]
        public Terapija Terapija { get; set; }
        public List<string> Alergeni { get; set; }

        /*
        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetZdravstvenaUsluga()
      {
         if (zdravstvenaUsluga == null)
            zdravstvenaUsluga = new System.Collections.ArrayList();
         return zdravstvenaUsluga;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetZdravstvenaUsluga(System.Collections.ArrayList newZdravstvenaUsluga)
      {
         RemoveAllZdravstvenaUsluga();
         foreach (ZdravstvenaUsluga oZdravstvenaUsluga in newZdravstvenaUsluga)
            AddZdravstvenaUsluga(oZdravstvenaUsluga);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddZdravstvenaUsluga(ZdravstvenaUsluga newZdravstvenaUsluga)
      {
         if (newZdravstvenaUsluga == null)
            return;
         if (this.zdravstvenaUsluga == null)
            this.zdravstvenaUsluga = new System.Collections.ArrayList();
         if (!this.zdravstvenaUsluga.Contains(newZdravstvenaUsluga))
            this.zdravstvenaUsluga.Add(newZdravstvenaUsluga);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveZdravstvenaUsluga(ZdravstvenaUsluga oldZdravstvenaUsluga)
      {
         if (oldZdravstvenaUsluga == null)
            return;
         if (this.zdravstvenaUsluga != null)
            if (this.zdravstvenaUsluga.Contains(oldZdravstvenaUsluga))
               this.zdravstvenaUsluga.Remove(oldZdravstvenaUsluga);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllZdravstvenaUsluga()
      {
         if (zdravstvenaUsluga != null)
            zdravstvenaUsluga.Clear();
      }
      
      

        /// <pdGenerated>default getter</pdGenerated>
       // public System.Collections.ArrayList GetTerapija()
    //  {
       //  if (terapija == null)
        //    terapija = new System.Collections.ArrayList();
      //   return terapija;
    //  }
      /*
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
        
    */
    }
}