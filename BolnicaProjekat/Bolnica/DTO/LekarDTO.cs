using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class LekarDTO
    {
        public int Id { get; set; }
        public Boolean Specijalista { get; set; }
        public string Specijalizacija { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public Pol Pol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Jmbg { get; set; }
        public string Drzavljanstvo { get; set; }
        public string AdresaStanovanja { get; set; }
        public string Sifra { get; set; }
        public RadnoVreme radnoVreme { get; set; }

        public LekarDTO()
        {

        }

        public LekarDTO(int id, bool specijalista, string specijalizacija, string ime, string prezime, string korisnickoIme, string email, string telefon, Pol pol, DateTime datumRodjenja, string jmbg, string drzavljanstvo, string adresaStanovanja, string sifra, RadnoVreme radnoVreme)
        {
            Id = id;
            Specijalista = specijalista;
            Specijalizacija = specijalizacija;
            Ime = ime;
            Prezime = prezime;
            KorisnickoIme = korisnickoIme;
            Email = email;
            Telefon = telefon;
            Pol = pol;
            DatumRodjenja = datumRodjenja;
            Jmbg = jmbg;
            Drzavljanstvo = drzavljanstvo;
            AdresaStanovanja = adresaStanovanja;
            Sifra = sifra;
            this.radnoVreme = radnoVreme;
        }

        public LekarDTO(LekarDTO dto)
        {
            Id = dto.Id;
            Specijalista = dto.Specijalista;
            Specijalizacija = dto.Specijalizacija;
            Ime = dto.Ime;
            Prezime = dto.Prezime;
            KorisnickoIme = dto.KorisnickoIme;
            Email = dto.Email;
            Telefon = dto.Telefon;
            Pol = dto.Pol;
            DatumRodjenja = dto.DatumRodjenja;
            Jmbg = dto.Jmbg;
            Drzavljanstvo = dto.Drzavljanstvo;
            AdresaStanovanja = dto.AdresaStanovanja;
            Sifra = dto.Sifra;
            radnoVreme = dto.radnoVreme;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime + " - " + KorisnickoIme;
        }

        public String RadnoVremeIspis
        {
            get
            {
                String pocetak = radnoVreme.PocetakRadnogVremena + "";
                String kraj = radnoVreme.KrajRadnogVremena + "";
                if (radnoVreme.PocetakRadnogVremena < 10)
                    pocetak = "0" + radnoVreme.PocetakRadnogVremena;
                if (radnoVreme.KrajRadnogVremena < 10)
                    kraj = "0" + radnoVreme.KrajRadnogVremena;

                return pocetak + ":00" + " - " + kraj + ":00";
            }
        }
    }
}
