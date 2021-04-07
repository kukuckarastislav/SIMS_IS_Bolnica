/***********************************************************************
 * Module:  OpstiLekar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Lekar.OpstiLekar
 ***********************************************************************/

using System;

namespace Model
{
   public class Lekar : Osoblje
   {

        public int IdLekara { get; set; }
        private bool Specijalista;
        private Odeljenje Odeljenje;

        public Lekar()
        {
        }

        public Lekar(int idLekara, bool specialista, Odeljenje odeljenje, RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(radnoVreme, radniStatus, korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {
            this.IdLekara = idLekara;
            this.Specijalista = specialista;
            this.Odeljenje = odeljenje;
        }





        public Pregled KreiranjePregleda()
      {
         // TODO: implement
         return null;
      }
      
      public Recept KreiranjeRecepta()
      {
         // TODO: implement
         return null;
      }
      
      public bool AzuriranjePregleda(Pregled pregled)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzuriranjeRecepta(Recept recept)
      {
         // TODO: implement
         return false;
      }
      
      public bool OtkazivanjePregleda(Pregled pregled)
      {
         // TODO: implement
         return false;
      }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }


    }
}