using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class HospitalizacijaDTO
    {
        public Hospitalizacija Hospitalizacija { get; set; }
        public Pacijent Pacijent { get; set; }
        public Lekar Lekar { get; set; }
        public Prostorija Prostorija { get; set; }

        public HospitalizacijaDTO(Hospitalizacija hospitalizacija, Pacijent pacijent, Lekar lekar, Prostorija prostorija)
        {
            Hospitalizacija = hospitalizacija;
            Pacijent = pacijent;
            Lekar = lekar;
            Prostorija = prostorija;
        }

        public string ImePrezimePacijenta
        {
            get
            {
                return Pacijent.Ime + " " + Pacijent.Prezime;
            }
        }

        public string ImePrezimeLekara
        {
            get
            {
                return Lekar.Ime + " " + Lekar.Prezime;
            }
        }

        public string NazivProstorije
        {
            get
            {
                return Prostorija.BrojSprat;
            }

        }

        public string PocetakHospitalizacije
        {
            get
            {
                return Hospitalizacija.PocetakHospitalizacije.ToString("dd.MM.yyyy HH:mm");
            }
        }

        public string KrajHospitalizacije
        {
            get
            {
                return Hospitalizacija.KrajHospitalizacije.ToString("dd.MM.yyyy HH:mm");
            }
        }

    }
}
