using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Podsjetnik
    {
        public int Id { get; set; }
        public int IdPacijenta { get; set; }
        public DateTime VrijemePojavljivanja { get; set; }
        public bool Vidljiv { get; set; }
        public string Tekst { get; set; }
        public bool Procitan { get; set; }
        public bool JePodsjetnikZaLijekove { get; set; }

        public Podsjetnik(int id, int idPacijenta, DateTime vrijemePojavljivanja, bool vidljiv, string tekst, bool procitan, bool jePodsjetnikZaLijekove)
        {
            Id = id;
            IdPacijenta = idPacijenta;
            VrijemePojavljivanja = vrijemePojavljivanja;
            Vidljiv = vidljiv;
            Tekst = tekst;
            Procitan = procitan;
            JePodsjetnikZaLijekove = jePodsjetnikZaLijekove;
        }
    }
}
