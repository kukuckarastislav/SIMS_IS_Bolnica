using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class ZakazaniTerminiDTO
    {
        public Termin Termin { get; set; }
        public int Id { get; set; }
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }
        public TipUsluge TipUsluge { get; set; }
        public Prostorija Prostorija { get; set; }

        public ZakazaniTerminiDTO(Termin termin, int id, Pacijent pacijent, Lekar lekar, TipUsluge tipUsluge, Prostorija prostorija)
        {
            Termin = termin;
            Id = id;
            Pacijent = pacijent;
            Lekar = lekar;
            TipUsluge = tipUsluge;
            Prostorija = prostorija;
        }

        public ZakazaniTerminiDTO()
        {
        }
    }
}
