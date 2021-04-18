/***********************************************************************
 * Module:  Recept.cs
 * Author:  Milica
 * Purpose: Definition of the Class Recept
 ***********************************************************************/

using System;

namespace Model
{
   public class Recept
   {
      public int Id { get; set; }
        public int IdLekara { get; set; }
        public int IdLeka { get; set; }
        public DateTime DatumPropisivanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public bool OslobodjenOdParticipacije { get; set; }
        public string OpisKoriscenja { get; set; }

    }
}