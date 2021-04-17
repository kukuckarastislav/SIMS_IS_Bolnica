/***********************************************************************
 * Module:  Racun.cs
 * Author:  Milica
 * Purpose: Definition of the Class Racun
 ***********************************************************************/

using System;

namespace Model
{
   public class Racun
   {
      public int IdUsluge { get; set; }
        public DateTime DatumPlacanja { get; set; }
        public double Iznos { get; set; }
        public bool Placeno { get; set; }

    }
}