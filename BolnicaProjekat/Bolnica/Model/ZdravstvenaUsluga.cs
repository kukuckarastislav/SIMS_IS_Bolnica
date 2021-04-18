/***********************************************************************
 * Module:  ZdravstvenaUsluga.cs
 * Author:  lacik
 * Purpose: Definition of the Class ZdravstvenaUsluga
 ***********************************************************************/

using System;
using System.Text.Json.Serialization;
using System.Collections;

namespace Model
{
   public class ZdravstvenaUsluga
   {
      public Termin termin;
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public int IdLekara { get; set; }
        [JsonInclude]
        public TipUsluge TipUsluge { get; set; }
        [JsonInclude]
        public int IdProstorije { get; set; }
        [JsonInclude]
        public bool Obavljena { get; set; }
        [JsonInclude]
        public string RazlogZakazivanja { get; set; }
        [JsonInclude]
        public string RezultatUsluge { get; set; }

        public ZdravstvenaUsluga(Termin termin, int id, int idLekara, TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge)
        {
            this.termin = termin;
            Id = id;
            IdLekara = idLekara;
            TipUsluge = tipUsluge;
            IdProstorije = idProstorije;
            Obavljena = obavljena;
            RazlogZakazivanja = razlogZakazivanja;
            RezultatUsluge = rezultatUsluge;
        }

        public ZdravstvenaUsluga(Termin termin, int id)
        {
            this.termin = termin;
            IdLekara = id;
        }
    }
}