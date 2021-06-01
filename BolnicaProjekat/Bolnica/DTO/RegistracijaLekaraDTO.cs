using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.utils;
using Model;
using Kontroler;
namespace DTO
{
    public class RegistracijaLekaraDTO : ValidationBase
    {
        public int id;
        public Boolean specijalista;
        public string specijalizacija;
        public string ime;
        public string prezime;
        public string korisnickoIme;
        public string email;
        public string telefon;
        public Pol pol;
        public DateTime datumRodjenja;
        public string jmbg;
        public string drzavljanstvo;
        public string adresaStanovanja;
        public string sifra;


        public RegistracijaLekaraDTO()
        {

        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public bool Specijalista
        {
            get { return specijalista; }
            set
            {
                if (specijalista != value)
                {
                    specijalista = value;
                    OnPropertyChanged("Specijalista");
                }
            }
        }

        public string Specijalizacija
        {
            get { return specijalizacija; }
            set
            {
                if (specijalizacija != value)
                {
                    specijalizacija = value;
                    OnPropertyChanged("Specijalizacija");
                }
            }
        }

        public string Ime
        {
            get { return ime; }
            set
            {
                if (ime != value)
                {
                    ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string Prezime
        {
            get { return prezime; }
            set
            {
                if (prezime != value)
                {
                    prezime = value;
                    OnPropertyChanged("Prezime");
                }
            }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                if (korisnickoIme != value)
                {
                    korisnickoIme = value;
                    OnPropertyChanged("KorisnickoIme");
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Telefon
        {
            get { return telefon; }
            set
            {
                if (telefon != value)
                {
                    telefon = value;
                    OnPropertyChanged("Telefon");
                }
            }
        }

        public string Jmbg
        {
            get { return jmbg; }
            set
            {
                if (jmbg != value)
                {
                    jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }
        public string Drzavljanstvo
        {
            get { return drzavljanstvo; }
            set
            {
                if (drzavljanstvo != value)
                {
                    drzavljanstvo = value;
                    OnPropertyChanged("Drzavljanstvo");
                }
            }
        }

        public string AdresaStanovanja
        {
            get { return adresaStanovanja; }
            set
            {
                if (adresaStanovanja != value)
                {
                    adresaStanovanja = value;
                    OnPropertyChanged("AdresaStanovanja");
                }
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                if (sifra != value)
                {
                    sifra = value;
                    OnPropertyChanged("Sifra");
                }
            }
        }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                if (datumRodjenja != value)
                {
                    datumRodjenja = value;
                    OnPropertyChanged("DatumRodjenja");
                }
            }
        }
        public Pol Pol
        {
            get { return pol; }
            set
            {
                if (pol != value)
                {
                    pol = value;
                    OnPropertyChanged("Pol");
                }
            }
        }

        protected override void ValidateSelf()
        {
            ValidirajIme();
            ValidirajPrezime();
            ValidirajJmbg();
            ValidirajTelefon();
            ValidirajAdresu();
            ValidirajKorisnickoIme();
            ValidirajEmail();
        }

        private void ValidirajIme()
        {
            if (string.IsNullOrWhiteSpace(this.ime))
            {
                this.ValidationErrors["Ime"] = "Polje ne može biti prazno!";
            }
        }
        private void ValidirajPrezime()
        {
            if (string.IsNullOrWhiteSpace(this.prezime))
            {
                this.ValidationErrors["Prezime"] = "Polje ne može biti prazno!";
            }
        }
        private void ValidirajJmbg()
        {
            if (String.IsNullOrWhiteSpace(this.jmbg))
            {
                this.ValidationErrors["Jmbg"] = "Polje ne može biti prazno!";
            }
            else
            {
                if (this.jmbg.Length != 13)
                {
                    this.ValidationErrors["Jmbg"] = "Polje mora sadržati 13 cifara!";
                }
                else
                {
                    if (!Validator.ValidanJmbg(this.jmbg))
                    {
                        this.ValidationErrors["Jmbg"] = "Polje mora sadržati 13 cifara!";
                    }
                }
            }
        }
        private void ValidirajTelefon()
        {
            if (String.IsNullOrWhiteSpace(this.telefon))
            {
                this.ValidationErrors["Telefon"] = "Polje ne može biti prazno!";
            }
        }
        private void ValidirajAdresu()
        {
            if (String.IsNullOrWhiteSpace(this.adresaStanovanja))
            {
                this.ValidationErrors["AdresaStanovanja"] = "Polje ne može biti prazno!";
            }
        }
        private void ValidirajKorisnickoIme()
        {
            if (String.IsNullOrWhiteSpace(this.korisnickoIme))
            {
                this.ValidationErrors["KorisnickoIme"] = "Polje ne može biti prazno!";
            }
            else
            {
                PacijentKontroler kontroler = new PacijentKontroler();
                if (kontroler.JelPostojiKorisnickoIme(this.korisnickoIme))
                {
                    this.ValidationErrors["KorisnickoIme"] = "Korisničko ime je zauzeto!";
                }

            }
        }

        private void ValidirajEmail()
        {
            if (String.IsNullOrWhiteSpace(this.email))
            {
                this.ValidationErrors["Email"] = "Polje ne može biti prazno!";
            }
            else
            {
                if (!Validator.ValidanEmail(this.email))
                {
                    this.ValidationErrors["Email"] = "Pogrešan formajt email-a!";
                }
            }
        }


    }
}
