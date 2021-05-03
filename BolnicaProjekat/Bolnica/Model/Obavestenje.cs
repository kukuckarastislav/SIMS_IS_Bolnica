using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Obavestenje
    {
        public int Id { get; set; }
        public string Naslov { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Poruka { get; set; }

        public Obavestenje(int id,string naslov, DateTime datumObjave, string poruka)
        {
            Id = id;
            Naslov = naslov;
            DatumObjave = datumObjave;
            Poruka = poruka;
        }

    }
}
