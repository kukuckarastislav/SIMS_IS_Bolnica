using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DTO
{
    class GodisnjiOdmorDTO
    {
        public int Id { set; get; }
        public int LekarId { set; get; }
        public Termin Period { set; get; }
    }
}
