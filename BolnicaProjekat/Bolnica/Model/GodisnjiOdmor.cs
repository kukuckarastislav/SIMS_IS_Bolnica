using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class GodisnjiOdmor
    {
        public int Id{set;get;}
        public int LekarId { set; get; }
        public Termin Period { set; get; }

        public GodisnjiOdmor(int id,int lekarId, Termin period)
        {
            Id = id;
            LekarId = lekarId;
            Period = period;
        }
    }
}
