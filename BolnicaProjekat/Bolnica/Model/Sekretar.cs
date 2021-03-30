/***********************************************************************
 * Module:  Sekretar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Sekretar.Sekretar
 ***********************************************************************/

using System;

namespace Model
{
   public class Sekretar : Osoblje
   {

        public Sekretar(RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(radnoVreme, radniStatus, korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
            adresaStanovanja)
        {

        }

        public Sekretar()
        {

        }

        public Pacijent RegistracijaNovogPacijenata()
      {
         // TODO: implement
         return null;
      }
      
      public Pacijent RegistracijaGostPacijenta()
      {
         // TODO: implement
         return null;
      }
      
      public bool AzuriranjePacijenta()
      {
         // TODO: implement
         return false;
      }
      
      public bool BrisanjePacijenta(Pacijent pacijent)
      {
         // TODO: implement
         return false;
      }
   
   }
}