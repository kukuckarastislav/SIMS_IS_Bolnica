using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DTOUslugaLekar
    {
        public Lekar Lekar { get; set; }
        public ZdravstvenaUsluga Usluga { get; set; }
        public DTOUslugaLekar(ZdravstvenaUsluga usluga, Lekar lekar)
        {
            Usluga = usluga;
             Lekar = lekar;
        }

        public string PodaciLekara
        {
            get
            {
                return Lekar.Ime + " " + Lekar.Prezime;
            }
            
        }
    }
}
