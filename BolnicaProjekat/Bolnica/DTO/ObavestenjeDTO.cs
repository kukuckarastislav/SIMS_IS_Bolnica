using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ObavestenjeDTO
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Poruka { get; set; }
    }
}
