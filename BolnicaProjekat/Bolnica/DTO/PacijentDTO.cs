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

        public PacijentDTO(int id, string ime, string prezime, string email, string telefon, string jmbg)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Email = email;
            Telefon = telefon;
            Jmbg = jmbg;
        }
        public PacijentDTO()
        {

        }
    }
}
