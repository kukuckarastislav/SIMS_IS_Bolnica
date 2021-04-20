/***********************************************************************
 * Module:  Terapija.cs
 * Author:  Milica
 * Purpose: Definition of the Class Terapija
 ***********************************************************************/

using System;

namespace Model
{
   public class Terapija
   {
      public Recept[] recept;
   
        public int Id { get; set; }
        public String Naziv { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public string Anamneza { get; set; }

    }
}