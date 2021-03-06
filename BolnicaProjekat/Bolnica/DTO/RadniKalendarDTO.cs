using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RadniKalendarDTO
    {
        public Pacijent Pacijent { get; set; }
        public Prostorija Prostorija { get; set; }
        public ZdravstvenaUsluga Usluga { get; set; }
        public RadniKalendarDTO(ZdravstvenaUsluga usluga, Pacijent pacijent, Prostorija prostorija)
        {
            Usluga = usluga;
            Pacijent = pacijent;
            Prostorija = prostorija;
        }

        public string ImePacijenta
        {
            get
            {
                if (Pacijent != null ) {
                    return Pacijent.Ime + " " + Pacijent.Prezime;
                }
                else
                {
                    return "";
                }

            }

        }

    public string NazivProstorije
        {
            get
            {
                if (Prostorija != null)
                {
                    return Prostorija.BrojSprat;
                }
                else
                {
                    return "(nije odredjena)";
                } 
            }

        }

    }
}
