/***********************************************************************
 * Module:  PotpunoRegistrovaniPacijent.cs
 * Author:  Milica
 * Purpose: Definition of the Class PotpunoRegistrovaniPacijent
 ***********************************************************************/

using System;
using System.Text.Json.Serialization;
using System.Collections;

namespace Model
{
   public class Pacijent : Korisnik
   {

        
        [JsonInclude]
        public MedicinskiKarton MedicinskiKarton { get; set; }
        [JsonInclude]
        public System.Collections.ArrayList Ocene { get; set; }

        /*
        public Pacijent(int idPacijenta, bool pacijentGost, bool hospitalizovan, bool spamUser, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {
            this.Id = idPacijenta;
            this.PacijentGost = pacijentGost;
            this.Hospitalizovan = hospitalizovan;
            this.SpamUser = spamUser;
            this.MedicinskiKarton = new MedicinskiKarton(idPacijenta, false);

        }*/

        public Pacijent(MedicinskiKarton medicinskiKarton, ArrayList ocene, int id, bool pacijentGost, bool hospitalizovan, bool spamUser, bool logickiObrisan, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {

            this.MedicinskiKarton = medicinskiKarton;
            this.Ocene = ocene;
            this.Id = id;
            this.PacijentGost = pacijentGost;
            this.Hospitalizovan = hospitalizovan;
            this.SpamUser = spamUser;
            this.LogickiObrisan = logickiObrisan;
            //this.medicinskiKarton = new MedicinskiKarton(idPacijenta, false);

        }

        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public Boolean PacijentGost { get; set; }
        [JsonInclude]
        public Boolean Hospitalizovan { get; set; }
        [JsonInclude]
        public Boolean SpamUser { get; set; }
        [JsonInclude]
        public bool LogickiObrisan { get; set; }

    }
}