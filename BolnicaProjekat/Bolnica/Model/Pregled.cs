/***********************************************************************
 * Module:  Pregled.cs
 * Author:  Milica
 * Purpose: Definition of the Class Pregled
 ***********************************************************************/

using System;

namespace Model
{
    public class Pregled : ZdravstvenaUsluga
    {
        public Termin Termin { get; set; }
        // public Racun racun;

        public string TipPregleda { get; set; }
        public string RezultatPregleda { get; set; }

        // private SobaZaPreglede SobaZaPregled;

        public Pregled(Termin termin, string tipPregleda, string rezultatPregleda, string nazivZdrastveneUstanove, string lokacijaZdravsteveUstanove, string idLekara, string zakazivacUsluge, bool obavljena, string id,string komentar) : base(nazivZdrastveneUstanove, lokacijaZdravsteveUstanove, idLekara, zakazivacUsluge, obavljena,id, komentar)
        {
            this.Termin = termin;
            TipPregleda = tipPregleda;
            RezultatPregleda = rezultatPregleda;
        }

        public Pregled(Termin termin, string tipPregleda, string rezultatPregleda, string idLekara, string zakazivacUsluge, bool obavljena, string id,string komentar) : base("Zdravo bolnica", "Novi Sad", idLekara, zakazivacUsluge, obavljena, id,komentar)
        {
            this.Termin = termin;
            TipPregleda = tipPregleda;
            RezultatPregleda = rezultatPregleda;
        }
        public Pregled()
        {
            
        }
    }
}