using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Servis;
using DTO;

namespace Kontroler
{
    public class PacijentKontroler
    {
        private Servis.PacijentServis pacijentServis;
        public PacijentKontroler()
        {
            pacijentServis = new PacijentServis();
        }
        public Pacijent DodajPacijenta(MedicinskiKarton medicinskiKarton, ArrayList ocene, int id, bool pacijentGost, bool hospitalizovan, bool spamUser, bool logickiObrisan, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja)
        {
            medicinskiKarton.IdPacijent = id;
            Model.Pacijent noviPacijent = new Pacijent(medicinskiKarton, ocene, id, pacijentGost, hospitalizovan, spamUser, logickiObrisan, korisnickoIme, sifra, ime,
             prezime, pol, email, telefon, datumRodjenja,
             jmbg, drzavljanstvo, adresaStanovanja);

            //pacijentServis.DodajPacijenta(noviPacijent);
            return noviPacijent;
        }

        public void DodajPacijenta(RegistracijaPacijentaDTO podaci)
        {
            pacijentServis.DodajPacijenta(podaci);
        }

        public Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
        {
            pacijentServis.AzurirajPacijenta(pacijent);
            return pacijent;
        }
        public void AzurirajPacijenta(PacijentDTO noviPodaci)
        {
            pacijentServis.AzurirajPacijenta(noviPodaci);
        }

        public void ObrisiPacijenta(PacijentDTO pacijent)
        {
            pacijentServis.ObrisiPacijenta(pacijent);
        }

        public ObservableCollection<PacijentDTO> GetPacijentiDto()
        {
            return pacijentServis.GetPacijentiDTO();
        }

        public void SaveData()
        {
            pacijentServis.SaveData();
        }

        public PacijentDTO PrijavaPacijenta(String korisnickoIme, String lozinka)
        {
            return pacijentServis.PrijaviPacijenta(korisnickoIme, lozinka);
        }

        public List<string> GetAlergeniPacijenta(int id)
        {
            return pacijentServis.GetAlergeniPacijenta(id);
        }

        public void DodajAlergen(int idPacijenta, string alergen)
        {
            pacijentServis.DodajAlergen(idPacijenta, alergen);
        }

        public void ObrisiAlergen(int idPacijenta, string alergen)
        {
            pacijentServis.ObrisiAlergen(idPacijenta, alergen);
        }

        public bool JelPostojiKorisnickoIme(string korisnickoIme)
        {
            return pacijentServis.JelPostojiKorisnickoIme(korisnickoIme);
        }

    }
}