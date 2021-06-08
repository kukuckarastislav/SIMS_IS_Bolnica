using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PacijentDTO
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string AdresaStanovanja { get; set; }
        public string Drzavljanstvo { get; set; }
        public Pol Pol { get; set; }
        public string KorisnickoIme { get; set; }

        public PacijentDTO()
        {

        }

        public PacijentDTO  (int id, 
                            string ime, 
                            string prezime, 
                            string email, 
                            string telefon, 
                            string jmbg,
                            string adresaStanovanja, 
                            string drzavljanstvo,
                            Pol pol,
                            DateTime datumRodjenja ,
                            string korisnickoIme)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Telefon = telefon;
            Jmbg = jmbg;
            AdresaStanovanja = adresaStanovanja;
            Pol = pol;
            DatumRodjenja = datumRodjenja;
            Drzavljanstvo = drzavljanstvo;
            KorisnickoIme = korisnickoIme;
        }


        public PacijentDTO(PacijentDTO noviPodaci)
        {
            Id = noviPodaci.Id;
            Ime = noviPodaci.Ime;
            Prezime = noviPodaci.Prezime;
            Email = noviPodaci.Email;
            Telefon = noviPodaci.Telefon;
            Jmbg = noviPodaci.Jmbg;
            AdresaStanovanja = noviPodaci.AdresaStanovanja;
            Pol = noviPodaci.Pol;
            DatumRodjenja = noviPodaci.DatumRodjenja;
            Drzavljanstvo = noviPodaci.Drzavljanstvo;
            KorisnickoIme = noviPodaci.KorisnickoIme;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime + " - " + Jmbg;
        }
    }
}
