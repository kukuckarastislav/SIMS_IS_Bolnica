using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class DTORecept
    {
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }
        public Lek Lek { get; set; }
        public Recept Recept { get; set; }
        public DTORecept(Recept recept, Pacijent pacijent, Lek lek, Lekar lekar)
        {
            Recept = recept;
            Pacijent = pacijent;
            Lek = lek;
            Lekar = lekar;
        }

        public string ImePacijenta
        {
            get
            {
                return Pacijent.Ime + " " + Pacijent.Prezime;
            }

        }

        public string ImeLekara
        {
            get
            {
                return Lekar.Ime + " " + Lekar.Prezime;
            }

        }

        public string NazivLeka
        {
            get
            {
                return Lek.Naziv;
            }

        }


    }
}
