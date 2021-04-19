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
        public int IdZdravstveneUsluge { get; set; }
        public int IdPacijenta { get; set; }
        public int IdLekara { get; set; }
        public bool PacijentProcitao { get; set; }
        public bool LekarProcitao { get; set; }

        public string Opis { get; set; }

        public Notifikacija(int id, int idZdravstveneUsluge, int idPacijenta, int idLekara,bool pacijentProcitao, bool lekarProcitao, string opis)
        {
            Id = id;
            IdZdravstveneUsluge = idZdravstveneUsluge;
            IdPacijenta = idPacijenta;
            IdLekara = idLekara;
            PacijentProcitao = pacijentProcitao;
            LekarProcitao = lekarProcitao;
        }
    }
}