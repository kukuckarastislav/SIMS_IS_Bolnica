using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    public class ZakaziTetminDTO
    {
        public Termin Termin { get; set; }
        public int Id { get; set; }
        public int IdLekara { get; set; }
        public int IdPacijenta { get; set; }
        public TipUsluge TipUsluge { get; set; }
        public int IdProstorije { get; set; }

        public string GreskaLekar { get; set; }
        public string GreskaProstorija { get; set; }
        public string GreskaRadnoVreme { get; set; }
        public bool ZakazanTermin { get; set; }

        public ZakaziTetminDTO(Termin termin, int id, int idLekara, int idPacijenta, TipUsluge tipUsluge, int idProstorije)
        {
            Termin = termin;
            Id = id;
            IdLekara = idLekara;
            IdPacijenta = idPacijenta;
            TipUsluge = tipUsluge;
            IdProstorije = idProstorije;
        }
        public ZakaziTetminDTO()
        {

        }
    }
}
