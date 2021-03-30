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

        public string KorisnickoIme { get; set; }
        public string Sifra { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public Pol Pol { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Jmbg { get; set; }
        public string Drzavljanstvo { get; set; }
        public string AdresaStanovanja { get; set; }

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