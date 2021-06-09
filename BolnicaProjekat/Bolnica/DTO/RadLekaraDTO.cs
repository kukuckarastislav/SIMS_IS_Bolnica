using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RadLekaraDTO
    {
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }

        public string TipUsluge { get; set; }

        public RadLekaraDTO(DateTime pocetak, DateTime kraj, string tipUsluge)
        {
            Pocetak = pocetak;
            Kraj = kraj;
            TipUsluge = tipUsluge;
        }
    }
}
