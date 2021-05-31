using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StavkaIzvjestajaDTO
    {   
        public String DanUSedmici { get; set; }
        public String NazivLijeka { get; set; }
        public DateTime VrijemeUzimanja { get; set; }

        public StavkaIzvjestajaDTO(string danUSedmici, string nazivLijeka, DateTime vrijemeUzimanja)
        {
            DanUSedmici = danUSedmici;
            NazivLijeka = nazivLijeka;
            VrijemeUzimanja = vrijemeUzimanja;
        }
    }
}
