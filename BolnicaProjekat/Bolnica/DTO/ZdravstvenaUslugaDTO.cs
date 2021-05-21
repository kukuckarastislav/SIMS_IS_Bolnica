using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class ZdravstvenaUslugaDTO
    {
        public Termin Termin { get; set; }
        public int Id { get; set; }
        public int IdPacijenta { get; set; }
        public int IdLekara { get; set; }
        public string ImePrezimeLekara { get; set; }
        public TipUsluge TipUsluge { get; set; }
        public int IdProstorije { get; set; }
        public string RazlogZakazivanja { get; set; }
        public string RezultatUsluge { get; set; }

        public ZdravstvenaUslugaDTO(Termin termin, int id, int idPacijenta, int idLekara, string imePrezimeLekara, TipUsluge tipUsluge, int idProstorije, string razlogZakazivanja, string rezultatUsluge)
        {
            Termin = termin;
            Id = id;
            IdPacijenta = idPacijenta;
            IdLekara = idLekara;
            ImePrezimeLekara = imePrezimeLekara;
            TipUsluge = tipUsluge;
            IdProstorije = idProstorije;
            RazlogZakazivanja = razlogZakazivanja;
            RezultatUsluge = rezultatUsluge;
        }
    }
}
