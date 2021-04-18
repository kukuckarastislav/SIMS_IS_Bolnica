/***********************************************************************
 * Module:  Osoblje.cs
 * Author:  Milica
 * Purpose: Definition of the Class Osoblje
 ***********************************************************************/

using System;

namespace Model
{
   public abstract class Osoblje : Korisnik
   {
      public RadnoVreme radnoVreme { get; set; }

        public RadniStatus RadniStatus { get; set; }

        protected Osoblje(RadnoVreme radnoVreme, RadniStatus radniStatus)
        {
            this.radnoVreme = radnoVreme;
            RadniStatus = radniStatus;
        }

        protected Osoblje(string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja, RadnoVreme radnoVreme, RadniStatus radniStatus) : base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {
            this.radnoVreme = radnoVreme;
            RadniStatus = radniStatus;
        }


    }
}