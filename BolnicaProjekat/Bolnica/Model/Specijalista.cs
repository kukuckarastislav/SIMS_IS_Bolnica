/***********************************************************************
 * Module:  Specijalista.cs
 * Author:  lacik
 * Purpose: Definition of the Class Specijalista
 ***********************************************************************/

using System;

namespace Model
{
   public class Specijalista : Lekar
   {

        private VrstaSpecijaliste VrstaSpecijalista;


        public Specijalista(VrstaSpecijaliste vrstaSpecijalista, int idLekara, bool specialista, Odeljenje odeljenje, RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(idLekara, specialista, odeljenje, radnoVreme, radniStatus, korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
         adresaStanovanja)
        {
            this.VrstaSpecijalista = vrstaSpecijalista;
        }


        public Operacija KreiranjeOperacije()
      {
         // TODO: implement
         return null;
      }
      
      public bool AzuriranjeOperacije(Operacija operacija)
      {
         // TODO: implement
         return false;
      }
      
      public bool OtkazivanjeOperacije(Operacija operacija)
      {
         // TODO: implement
         return false;
      }
   
      
   
   }
}