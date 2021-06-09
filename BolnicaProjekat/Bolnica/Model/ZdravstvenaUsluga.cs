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
        [JsonInclude]
        public Termin Termin { get; set; }
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public int IdLekara { get; set; }
        [JsonInclude]
        public int IdPacijenta { get; set; }
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

        public ZdravstvenaUsluga(Termin termin, int id, int idLekara, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge)
        {
            Termin = termin;
            Id = id;
            IdLekara = idLekara;
            IdPacijenta = idPacijenta;
            TipUsluge = tipUsluge;
            IdProstorije = idProstorije;
            Obavljena = obavljena;
            RazlogZakazivanja = razlogZakazivanja;
            RezultatUsluge = rezultatUsluge;
        }


        public string GetTipUslugeStr()
        {
            string tipUslugeStr = "";
            if(TipUsluge == TipUsluge.Operacija)
            {
                tipUslugeStr = "Operacija";
            }else if(TipUsluge == TipUsluge.Pregled)
            {
                tipUslugeStr = "Pregled";
            }

            return tipUslugeStr;
        }
    }
}