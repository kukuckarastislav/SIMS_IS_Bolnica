/***********************************************************************
 * Module:  Termin.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Util.Termin
 ***********************************************************************/

using System;

namespace Model
{
   public class Termin
   {
      public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public Termin(DateTime pocetak, DateTime kraj)
        {
            Pocetak = pocetak;
            Kraj = kraj;
        }

        public Termin()
        {
        }
    }
}