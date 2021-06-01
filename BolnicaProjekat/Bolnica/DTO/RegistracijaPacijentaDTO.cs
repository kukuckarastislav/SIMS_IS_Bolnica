using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bolnica.utils;
using Model;

namespace Bolnica.DTO
{
    class RegistracijaPacijentaDTO : ValidationBase
    {
        public int id;
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
        public bool pacijentGost;

        public RegistracijaPacijentaDTO()
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

        public bool PacijentGost
        {
            get { return pacijentGost; }
            set
            {
                if (pacijentGost != value)
                {
                    pacijentGost = value;
                    OnPropertyChanged("PacijentGost");
                }
            }
        }

        protected override void ValidateSelf()
        {

        }
    }
}
