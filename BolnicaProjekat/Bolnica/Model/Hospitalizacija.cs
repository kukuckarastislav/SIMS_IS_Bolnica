using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hospitalizacija
    {
        public int Id { get; set; }
        public int IdLekara { get; set; }
        public int IdPacijenta { get; set; }
        public int IdProstorije { get; set; }
        public DateTime PocetakHospitalizacije { get; set; }
        public DateTime KrajHospitalizacije { get; set; }

        public Hospitalizacija(int id, int idLekara, int idPacijenta, int idProstorije, DateTime pocetakHospitalizacije, DateTime krajHospitalizacije)
        {
            Id = id;
            IdLekara = idLekara;
            IdPacijenta = idPacijenta;
            IdProstorije = idProstorije;
            PocetakHospitalizacije = pocetakHospitalizacije;
            KrajHospitalizacije = krajHospitalizacije;
        }

    }

}
