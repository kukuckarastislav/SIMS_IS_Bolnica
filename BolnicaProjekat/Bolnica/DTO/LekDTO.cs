using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LekDTO
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public bool Odobren { get; set; }
        public string Opis { get; set; }
        public int Kolicina { get; set; }
        public double Cena { get; set; }
        public List<string> Alergeni { get; set; }
        public List<RevizijaLeka> Revizije { get; set; }

        public LekDTO(int id, string sifra, string naziv, bool odobren, string opis, int kolicina, double cena, List<string> alergeni, List<RevizijaLeka> revizije)
        {
            Id = id;
            Sifra = sifra;
            Naziv = naziv;
            Odobren = odobren;
            Opis = opis;
            Kolicina = kolicina;
            Cena = cena;
            Alergeni = alergeni;
            Revizije = revizije;
        }

        public LekDTO()
        {

        }
    }
}
