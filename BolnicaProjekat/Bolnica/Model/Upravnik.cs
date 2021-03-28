/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Upravnik.Upravnik
 ***********************************************************************/

using System;

namespace Model
{
   public class Upravnik : Osoblje
   {

        public Upravnik(RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(radnoVreme, radniStatus, korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {

        }


      public Prostorija KreirajProstoriju()
      {
            Model.Prostorija prostorija = new Prostorija(1, 3, 10*10, 1);
            return prostorija;
      }
      
      public OperacionaSala KreirajOperacionuSalu()
      {
         // TODO: implement
         return null;
      }
      
      public SobaZaPreglede KreirajSobuZaPreglede()
      {
         // TODO: implement
         return null;
      }
      
      public BolesnickaSoba KreirajBolesnickuSobu()
      {
         // TODO: implement
         return null;
      }
      
      public bool ObrisiProstoriju(int idProstorije)        // (Prostorija prostorija)
      {
            //Model.Bolnica.GetProstorijaByID(idProstorije);
            Prostorija pro = Model.Bolnica.GetInstance().GetProstorijaByID(idProstorije);
            if(pro == null)
            {
                return false;
            }
            else 
            { 
                return true; 
            }
      }
      
      public bool ObrisiOperacionuSalu(OperacionaSala operacionaSala)
      {
         // TODO: implement
         return false;
      }
      
      public bool ObrisiSobuZaPreglede(SobaZaPreglede sobaZaPreglede)
      {
         // TODO: implement
         return false;
      }
      
      public bool ObrisiBolesnickuSobu(BolesnickaSoba bolesnickaSoba)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzurirajProstoriju(Prostorija editProstorija)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzurirajOperacionuSalu(OperacionaSala editOperacionaSala)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzurirajSobuZaPreglede(SobaZaPreglede editSobuZaPregled)
      {
         // TODO: implement
         return false;
      }
      
      public bool AzurirajBolesnickuSobu(BolesnickaSoba editBolesnickaSoba)
      {
         // TODO: implement
         return false;
      }
   
   }
}