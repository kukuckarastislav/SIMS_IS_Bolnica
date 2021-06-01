using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HospitalizacijaDTO
    {
        public int IdPacijenta { get; set; }
        public int IdLekara { get; set; }
        public int IdProstorije { get; set; }
        public DateTime PocetakHospitalizacije { get; set; }
        public DateTime KrajHospitalizacije { get; set; }

        public HospitalizacijaDTO(int idPacijenta, int idLekara, int idProstorije, DateTime pocetakHospitalizacije, DateTime krajHospitalizacije)
        {
            IdPacijenta = idPacijenta;
            IdLekara = idLekara;
            IdProstorije = idProstorije;
            PocetakHospitalizacije = pocetakHospitalizacije;
            KrajHospitalizacije = krajHospitalizacije;
        }
    }
}
