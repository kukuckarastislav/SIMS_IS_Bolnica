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

        public Lekar Lekar { get; set; } 
        public SobaZaPreglede SobaZaPregled { get; set; }


        public Pregled(Termin termin, string tipPregleda, string rezultatPregleda, string nazivZdrastveneUstanove, string lokacijaZdravsteveUstanove, Model.Lekar idLekara, string zakazivacUsluge, bool obavljena, string id,string komentar, SobaZaPreglede sobaZaPregled) : base(nazivZdrastveneUstanove, lokacijaZdravsteveUstanove, idLekara, zakazivacUsluge, obavljena,id, komentar)
        {
            this.Termin = termin;
            TipPregleda = tipPregleda;
            RezultatPregleda = rezultatPregleda;
            SobaZaPregled = sobaZaPregled;
        }

        public Pregled(Termin termin, string tipPregleda, string rezultatPregleda, Model.Lekar idLekara, string zakazivacUsluge, bool obavljena, string id,string komentar, SobaZaPreglede sobaZaPregled) : base("Zdravo bolnica", "Novi Sad", idLekara, zakazivacUsluge, obavljena, id,komentar)
        {
            this.Termin = termin;
            TipPregleda = tipPregleda;
            RezultatPregleda = rezultatPregleda;
            SobaZaPregled = sobaZaPregled;
        }
    }
}