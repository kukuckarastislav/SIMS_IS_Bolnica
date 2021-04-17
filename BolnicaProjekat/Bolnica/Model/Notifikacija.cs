/***********************************************************************
 * Module:  Notifikacija.cs
 * Author:  lacik
 * Purpose: Definition of the Class Model.Notifikacija
 ***********************************************************************/

using System;

namespace Model
{
   public class Notifikacija
   {
      public int Id { get; set; }
        public DateTime Vreme { get; set; }
        public string Sadrzaj { get; set; }

    }
}