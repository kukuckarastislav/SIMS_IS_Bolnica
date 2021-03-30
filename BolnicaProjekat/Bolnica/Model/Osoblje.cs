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
        public RadnoVreme radnoVreme;
        private RadniStatus radniStatus;

        public Osoblje(RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : 
            base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo, 
                adresaStanovanja)
        {
            this.radnoVreme = radnoVreme;
            this.radniStatus = radniStatus;
        }

        protected Osoblje()
        {
        }
    }
}