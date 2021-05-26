using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ReceptDTO
    {
        public int Id { get; set; }
        public int IdLekara { get; set; }
        public String ImePrezimeLekara { get; set; }
        public int IdPacijenta { get; set; }
        public int IdLeka { get; set; }
        public String NazivLeka { get; set; }
        public DateTime DatumPropisivanja { get; set; }
        public DateTime DatumIsteka { get; set; }
        public string OpisKoriscenja { get; set; }

        public ReceptDTO(int id, int idLekara, string imePrezimeLekara, int idPacijenta, int idLeka, string nazivLeka, DateTime datumPropisivanja, DateTime datumIsteka, string opisKoriscenja)
        {
            Id = id;
            IdLekara = idLekara;
            ImePrezimeLekara = imePrezimeLekara;
            IdPacijenta = idPacijenta;
            IdLeka = idLeka;
            NazivLeka = nazivLeka;
            DatumPropisivanja = datumPropisivanja;
            DatumIsteka = datumIsteka;
            OpisKoriscenja = opisKoriscenja;
        }
    }
}
