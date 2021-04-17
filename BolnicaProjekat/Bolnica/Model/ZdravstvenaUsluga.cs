/***********************************************************************
 * Module:  ZdravstvenaUsluga.cs
 * Author:  lacik
 * Purpose: Definition of the Class ZdravstvenaUsluga
 ***********************************************************************/

using System;

namespace Model
{
   public class ZdravstvenaUsluga
   {
      public Termin termin;
   
      public int Id { get; set; }
        public int IdLekara { get; set; }
        public TipUsluge TipUsluge { get; set; }
        public int IdProstorije { get; set; }
        public bool Obavljena { get; set; }
        public string RazlogZakazivanja { get; set; }
        public string RezultatUsluge { get; set; }

    }
}