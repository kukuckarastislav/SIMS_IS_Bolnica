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

        public OperacionaSala OperacionaSala { get; set; }

        private string TipOperacije;
        private string RezultatOperacije;

        // private OperacionaSala OperacionaSala;

        public Operacija(Termin termin, string tipOperacije, string rezultatOperacije, string nazivZdrastveneUstanove, string lokacijaZdravsteveUstanove, Model.Lekar idLekara, string zakazivacUsluge, bool obavljena,string id, string komentar, OperacionaSala operacionaSala)
            : base(nazivZdrastveneUstanove, lokacijaZdravsteveUstanove, idLekara, zakazivacUsluge, obavljena, id,komentar)
        {
            this.termin = termin;
            TipOperacije = tipOperacije;
            RezultatOperacije = rezultatOperacije;
        }




    }
}