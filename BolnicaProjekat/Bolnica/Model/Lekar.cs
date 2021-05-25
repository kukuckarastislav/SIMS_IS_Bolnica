/***********************************************************************
 * Module:  OpstiLekar.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Lekar.OpstiLekar
 ***********************************************************************/

using System;
using System.Text.Json.Serialization;

namespace Model
{
   public class Lekar : Osoblje
   {
      public int Id { get; set; }
        public bool Specijalista { get; set; }
        public string Specijalizacija { get; set; }

        
        public Lekar(int id,bool specijalista,string specijalizacija,RadnoVreme radnoVreme, RadniStatus radniStatus,string korisnickoIme,
            string sifra,string ime,string prezime,Pol pol,string email,string telefon, DateTime datumRodjenja,string jmbg,
            string drzavljanstvo, string adresaStanovanja
            ) : base(korisnickoIme,sifra,ime,
            prezime,pol,email,telefon, datumRodjenja,
           jmbg,drzavljanstvo,adresaStanovanja,radnoVreme,radniStatus)
        {
            Id = id;
            Specijalista = specijalista;
            Specijalizacija = specijalizacija;
        }
        public override string ToString()
        {
            return Ime +" "+ Prezime;
        }





    }
}