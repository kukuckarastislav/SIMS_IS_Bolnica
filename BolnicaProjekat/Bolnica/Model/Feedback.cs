using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Feedback
    {
        public int Id { get; set; }
        public String Tekst { get; set; }
        public int IdKorisnika { get; set; }
        public String VrstaKorisnika { get; set; }

        public Feedback(int id, string tekst, int idKorisnika, string vrstaKorisnika)
        {
            Id = id;
            Tekst = tekst;
            IdKorisnika = idKorisnika;
            VrstaKorisnika = vrstaKorisnika;
        }
    }
}
