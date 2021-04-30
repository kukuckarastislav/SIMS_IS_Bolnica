using System;
using System.Text.Json.Serialization;
using System.Collections;

namespace Model
{
    public class Aktivnost
    {
        [JsonInclude]
        public int IdPacijenta { get; set; }
        [JsonInclude]
        public DateTime Datum { get; set; }
        [JsonInclude]
        public string Vrsta { get; set; }


        public Aktivnost(int idPacijenta, DateTime datum, string vrsta)
        {
            IdPacijenta = idPacijenta;
            Datum = datum;
            Vrsta = vrsta;
        }
    }
}