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
        public int IdPacijenta { get; set; }
        public int IdLeka { get; set; }
        public DateTime DatumPropisivanja { get; set; }
      //  public DateTime VremeUzimanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public bool OslobodjenOdParticipacije { get; set; }
        public string OpisKoriscenja { get; set; }

        public Recept(int id, int idLekara, int idPacijenta, int idLeka, DateTime datumPropisivanja, DateTime datumIsteka, bool oslobodjenOdParticipacije, string opisKoriscenja)
        {
            Id = id;
            IdLekara = idLekara;
            IdPacijenta = idPacijenta;
            IdLeka = idLeka;
            DatumPropisivanja = datumPropisivanja;
            DatumIsteka = datumIsteka;
            OslobodjenOdParticipacije = oslobodjenOdParticipacije;
            OpisKoriscenja = opisKoriscenja;
        }
    }
}