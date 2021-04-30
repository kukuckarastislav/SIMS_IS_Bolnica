/***********************************************************************
 * Module:  Ocjena.cs
 * Author:  Milica
 * Purpose: Definition of the Class Ocjena
 ***********************************************************************/

using System;
using System.Text.Json.Serialization;

namespace Model
{
    public class Ocena
    {
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public string Komentar { get; set; }
        [JsonInclude]
        public int Vrednost { get; set; }
        [JsonInclude]
        public int IdPacijenta { get; set; }
        [JsonInclude]
        public int IdLekara { get; set; }
        [JsonInclude]
        public DateTime Datum { get; set; }

        public Ocena(int id,string komentar, int vrednost, int idPacijenta, int idLekara, DateTime datum)
        {
            Id = id;
            Komentar = komentar;
            Vrednost = vrednost;
            IdPacijenta = idPacijenta;
            IdLekara = idLekara;
            Datum = datum;
        }
    }
}