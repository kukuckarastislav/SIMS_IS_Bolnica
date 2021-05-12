using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class OcenaDTO
    {
        public int Id { get; set; }
        public string Komentar { get; set; }
        public int Vrednost { get; set; }
        public int IdPacijenta { get; set; }
        public int IdLekara { get; set; }
        public DateTime Datum { get; set; }
        public String NazivLekara{ get; set; }
        public String NazivAutora { get; set; }
        public bool OcenaBolnice { get; set; }

        public OcenaDTO(int id, string komentar, int vrednost, int idPacijenta, int idLekara, DateTime datum, string nazivLekara, string nazivAutora,bool ocenaBolnice)
        {
            Id = id;
            Komentar = komentar;
            Vrednost = vrednost;
            IdPacijenta = idPacijenta;
            IdLekara = idLekara;
            Datum = datum;
            NazivLekara = nazivLekara;
            NazivAutora = nazivAutora;
            OcenaBolnice = ocenaBolnice;
        }
    }
}
