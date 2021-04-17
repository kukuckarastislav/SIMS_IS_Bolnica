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

        public Pacijent(MedicinskiKarton medicinskiKarton, ArrayList ocene, int Id, bool pacijentGost, bool hospitalizovan, bool spamUser, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {

            this.MedicinskiKarton = medicinskiKarton;
            this.Ocene = ocene;
            this.Id = Id;
            this.PacijentGost = pacijentGost;
            this.Hospitalizovan = hospitalizovan;
            this.SpamUser = spamUser;
            //this.medicinskiKarton = new MedicinskiKarton(idPacijenta, false);

        }


        /// <pdGenerated>default getter</pdGenerated>
        public System.Collections.ArrayList GetOcene()
      {
         if (Ocene == null)
            Ocene = new System.Collections.ArrayList();
         return Ocene;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetOcene(System.Collections.ArrayList newOcene)
      {
         RemoveAllOcene();
         foreach (Ocena oOcena in newOcene)
            AddOcene(oOcena);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddOcene(Ocena newOcena)
      {
         if (newOcena == null)
            return;
         if (this.Ocene == null)
            this.Ocene = new System.Collections.ArrayList();
         if (!this.Ocene.Contains(newOcena))
         {
            this.Ocene.Add(newOcena);
            newOcena.SetPacijent(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOcene(Ocena oldOcena)
      {
         if (oldOcena == null)
            return;
         if (this.Ocene != null)
            if (this.Ocene.Contains(oldOcena))
            {
               this.Ocene.Remove(oldOcena);
               oldOcena.SetPacijent((Pacijent)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOcene()
      {
         if (Ocene != null)
         {
            System.Collections.ArrayList tmpOcene = new System.Collections.ArrayList();
            foreach (Ocena oldOcena in Ocene)
               tmpOcene.Add(oldOcena);
            Ocene.Clear();
            foreach (Ocena oldOcena in tmpOcene)
               oldOcena.SetPacijent((Pacijent)null);
            tmpOcene.Clear();
         }
      }
        [JsonInclude]
        public int Id { get; set; }
        [JsonInclude]
        public Boolean PacijentGost { get; set; }
        [JsonInclude]
        public Boolean Hospitalizovan { get; set; }
        [JsonInclude]
        public Boolean SpamUser { get; set; }

    }
}