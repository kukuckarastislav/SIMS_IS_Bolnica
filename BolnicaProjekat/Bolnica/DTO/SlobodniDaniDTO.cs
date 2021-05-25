using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    class SlobodniDaniDTO
    {
        public int Id { get; set; }
        public int LekarId { get; set; }
        public List<DateTime> Dani { get; set; }

    }
}
