/***********************************************************************
 * Module:  ZdravstvenaUsluga.cs
 * Author:  lacik
 * Purpose: Definition of the Class ZdravstvenaUsluga
 ***********************************************************************/

using System;

namespace Model
{
    public abstract class ZdravstvenaUsluga
    {
        public string NazivZdrastveneUstanove { get; set; }
        public string LokacijaZdravsteveUstanove { get; set; }
        public string IdLekara { get; set; }

        public string ZakazivacUsluge { get; set; }
        public bool Obavljena { get; set; }

        public string IdUsluge { get; set; }
        public string Komentar { get; set; } 

        protected ZdravstvenaUsluga(string nazivZdrastveneUstanove, string lokacijaZdravsteveUstanove, string idLekara,string zakazivacUsluge, bool obavljena,string idUsluge, string komentar)
        {
            NazivZdrastveneUstanove = nazivZdrastveneUstanove;
            LokacijaZdravsteveUstanove = lokacijaZdravsteveUstanove;
            IdLekara = idLekara;
            ZakazivacUsluge = zakazivacUsluge;
            Obavljena = obavljena;
            idUsluge = idUsluge;
            Komentar = komentar;
        }
    }
}