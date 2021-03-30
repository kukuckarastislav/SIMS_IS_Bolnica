/***********************************************************************
 * Module:  PotpunoRegistrovaniPacijent.cs
 * Author:  Milica
 * Purpose: Definition of the Class PotpunoRegistrovaniPacijent
 ***********************************************************************/

using System;

namespace Model
{
   public class Pacijent : Korisnik
   {

        public string IdPacijenta { get; set; }
        private bool PacijentGost = false;
        private bool Hospitalizovan;
        private bool SpamUser = false;


        public MedicinskiKarton MedicinskiKarton;

        public Pacijent(string idPacijenta, bool pacijentGost, bool hospitalizovan, bool spamUser, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
        {
            this.IdPacijenta = idPacijenta;
            this.PacijentGost = pacijentGost;
            this.Hospitalizovan = hospitalizovan;
            this.SpamUser = spamUser;
            this.MedicinskiKarton = new MedicinskiKarton(idPacijenta,false,KategorijaPacijenta.IiiIntermedijalnaNega);
   
        }
        public Pacijent()
        {
            
        }



        public void ZakazivanjePregleda(Pregled pregled)
      {
            this.MedicinskiKarton.AddPregled(pregled);
      }
      
      public void IzmenaPregleda()
      {
        
      }
      
      public void OtkazivanjePregleda(Pregled pregled)
      {
            this.MedicinskiKarton.RemovePregled(pregled);
        }
      
      public void PrikazSvojihPregleda()
      {
         // TODO: implement
      }
   



      public System.Collections.ArrayList ocene;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetOcene()
      {
         if (ocene == null)
            ocene = new System.Collections.ArrayList();
         return ocene;
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
         if (this.ocene == null)
            this.ocene = new System.Collections.ArrayList();
         if (!this.ocene.Contains(newOcena))
         {
            this.ocene.Add(newOcena);
            newOcena.SetPacijent(this);      
         }
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveOcene(Ocena oldOcena)
      {
         if (oldOcena == null)
            return;
         if (this.ocene != null)
            if (this.ocene.Contains(oldOcena))
            {
               this.ocene.Remove(oldOcena);
               oldOcena.SetPacijent((Pacijent)null);
            }
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllOcene()
      {
         if (ocene != null)
         {
            System.Collections.ArrayList tmpOcene = new System.Collections.ArrayList();
            foreach (Ocena oldOcena in ocene)
               tmpOcene.Add(oldOcena);
            ocene.Clear();
            foreach (Ocena oldOcena in tmpOcene)
               oldOcena.SetPacijent((Pacijent)null);
            tmpOcene.Clear();
         }
      }
   

   
   }
}