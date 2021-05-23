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
        public int Id { get; set; }
        
        public int IdLekara { get; set; }
        
        public int IdPacijenta { get; set; }
        public Termin Termin { get; set; }
        public TipUsluge TipUsluge { get; set; }
        public int IdProstorije { get; set; }
    }
}
