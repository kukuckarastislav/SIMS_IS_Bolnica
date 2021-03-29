/***********************************************************************
 * Module:  Operacija.cs
 * Author:  Milica
 * Purpose: Definition of the Class Operacija
 ***********************************************************************/

using System;

namespace Model
{
    public class Operacija : ZdravstvenaUsluga
    {
        public Termin termin;
        // public Racun racun;

        private string TipOperacije;
        private string RezultatOperacije;

        // private OperacionaSala OperacionaSala;

        public Operacija(Termin termin, string tipOperacije, string rezultatOperacije, string nazivZdrastveneUstanove, string lokacijaZdravsteveUstanove, string idLekara, string zakazivacUsluge, bool obavljena, string komentar)
            : base(nazivZdrastveneUstanove, lokacijaZdravsteveUstanove, idLekara, zakazivacUsluge, obavljena, komentar)
        {
            this.termin = termin;
            TipOperacije = tipOperacije;
            RezultatOperacije = rezultatOperacije;
        }




    }
}