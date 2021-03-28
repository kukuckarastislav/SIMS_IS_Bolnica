/***********************************************************************
 * Module:  Korisnik.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Util.Korisnik
 ***********************************************************************/

using System;

namespace Model
{
   public abstract class Korisnik
   {

        public bool PrijaviSe()
        {
            // TODO: implement
            return false;
        }
      
        public bool OdjaviSe()
        {
            // TODO: implement
            return false;
        }
      
        public bool PromeniSifru(string novaSifra)
        {
            // TODO: implement
            return false;
        }

        private string KorisnickoIme;
        private string Sifra;
        private string Ime;
        private string Prezime;
        private Pol Pol;
        private string Email;
        private string Telefon;
        private DateTime DatumRodjenja;
        private string Jmbg;
        private string Drzavljanstvo;
        private string AdresaStanovanja;

        public Korisnik(string korisnickoIme, string sifra, string ime, 
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja, 
            string jmbg, string drzavljanstvo, string adresaStanovanja)
        {
            Ime = ime;
            Sifra = sifra;
            KorisnickoIme = korisnickoIme;
            Prezime = prezime;
            Pol = pol;
            Email = email;
            Telefon = telefon;
            DatumRodjenja = datumRodjenja;
            Jmbg = jmbg;
            Drzavljanstvo = drzavljanstvo;
            AdresaStanovanja = adresaStanovanja;
        }



        
    }
}