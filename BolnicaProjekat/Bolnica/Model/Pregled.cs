/***********************************************************************
 * Module:  Pregled.cs
 * Author:  Milica
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;

namespace Model
{
   public class Pregled : ZdravstvenaUsluga
   {
      public Termin termin;
      public Racun racun;
   
      private string TipPregleda;
      private string RezultatPregleda;
      private SobaZaPreglede SobaZaPregled;
   
   }
}