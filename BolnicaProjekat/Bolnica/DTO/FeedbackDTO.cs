using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    class FeedbackDTO
    {
        public int Id { get; set; }
        public String Tekst { get; set; }
        public int IdKorisnika { get; set; }

        public FeedbackDTO(int id, string tekst, int idKorisnika)
        {
            Id = id;
            Tekst = tekst;
            IdKorisnika = idKorisnika;
        }
    }
}
