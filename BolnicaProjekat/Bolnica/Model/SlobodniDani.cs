using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class SlobodniDani
    {
        public int Id { get; set; }
        public int LekarId { get; set; }
        public List<DateTime> Dani { get; set; }

        public SlobodniDani(int id, int lekarId, List<DateTime> dani)
        {
            Id = id;
            LekarId = lekarId;
            Dani = dani;
        }

    }
}
