using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
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
    }
}
