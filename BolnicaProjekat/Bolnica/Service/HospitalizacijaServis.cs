using Model;
using System;
using Repozitorijum;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bolnica.DTO;

namespace Servis
{
    public class HospitalizacijaServis
    {
        public static Hospitalizacija DodajHospitalizaciju(Hospitalizacija hospitalizacija)
        {
            return Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.DodajHospitalizaciju(hospitalizacija);

        }

        public static Hospitalizacija ObrisiHospitalizacija(Hospitalizacija hospitalizacija)
        {
            return Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.ObrisiHospitalizaciju(hospitalizacija);
        }

        public static ObservableCollection<Hospitalizacija> GetPacijentovihHospitalizacija(int pacId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacije = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacije)
            {
                if (h.IdPacijenta == pacId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<HospitalizacijaDTO> GetPacijentovihHospitalizacijaDTO(int pacId)
        {
            ObservableCollection<HospitalizacijaDTO> ret = new ObservableCollection<HospitalizacijaDTO>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            Pacijent pac = Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(pacId);

            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdPacijenta == pacId)
                {
                    Prostorija prostorija = Repozitorijum.ProstorijeRepozitorijum.GetInstance.GetProstorijaById(h.IdProstorije);
                    Lekar lekar = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(h.IdLekara);

                    ret.Add(new HospitalizacijaDTO(h, pac, lekar, prostorija));
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetLekarovihHospitalizacije(int lekarId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdLekara == lekarId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetHospitalizacijeOdredjenogProstorija(int prostorijeId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdProstorije == prostorijeId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetAll()
        {
            return HospitalizacijaRepozitorijum.GetInstance.GetAll();
        }
    }

}
