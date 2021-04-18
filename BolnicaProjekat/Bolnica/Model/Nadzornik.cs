/***********************************************************************
 * Module:  Nadzornik.cs
 * Author:  lacik
 * Purpose: Definition of the Class Model.Nadzornik
 ***********************************************************************/

using System;

namespace Model
{
   public class Nadzornik
   {
      public System.Collections.ArrayList notifikacija;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetNotifikacija()
      {
         if (notifikacija == null)
            notifikacija = new System.Collections.ArrayList();
         return notifikacija;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetNotifikacija(System.Collections.ArrayList newNotifikacija)
      {
         RemoveAllNotifikacija();
         foreach (Notifikacija oNotifikacija in newNotifikacija)
            AddNotifikacija(oNotifikacija);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddNotifikacija(Notifikacija newNotifikacija)
      {
         if (newNotifikacija == null)
            return;
         if (this.notifikacija == null)
            this.notifikacija = new System.Collections.ArrayList();
         if (!this.notifikacija.Contains(newNotifikacija))
            this.notifikacija.Add(newNotifikacija);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveNotifikacija(Notifikacija oldNotifikacija)
      {
         if (oldNotifikacija == null)
            return;
         if (this.notifikacija != null)
            if (this.notifikacija.Contains(oldNotifikacija))
               this.notifikacija.Remove(oldNotifikacija);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllNotifikacija()
      {
         if (notifikacija != null)
            notifikacija.Clear();
      }
   
      public int IdPacijenta { get; set; }

    }
}