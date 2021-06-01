using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Kontroler
{
    public class HospitalizacijaKontroler
    {

        private HospitalizacijaServis hospitalizacijaServisObjekat;

        public HospitalizacijaKontroler()
        {
            hospitalizacijaServisObjekat = new HospitalizacijaServis();
        }

        public ObservableCollection<Hospitalizacija> GetPacijentovihHospitalizacija(int pacId)
        {
            return HospitalizacijaServis.GetPacijentovihHospitalizacija(pacId);
        }

        public ObservableCollection<Hospitalizacija> GetLekarovihHospitalizacija(int lekarId)
        {
            return HospitalizacijaServis.GetPacijentovihHospitalizacija(lekarId);
        }

        public ObservableCollection<Hospitalizacija> GetHospitalizacijaOdredjenogProstorije(int prostorijeId)
        {
            return HospitalizacijaServis.GetPacijentovihHospitalizacija(prostorijeId);
        }
        public void ObrisiHospitalizaciju(Hospitalizacija hospitalizacija)
        {
            HospitalizacijaServis.ObrisiHospitalizacija(hospitalizacija);
        }

        public Hospitalizacija DodajHospitalizaciju(HospitalizacijaDTO hospitalizacijaDTO)
        {
            return hospitalizacijaServisObjekat.DodajHospitalizaciju(hospitalizacijaDTO);
        }


        public ObservableCollection<Hospitalizacija> GetAll()
        {
            return HospitalizacijaServis.GetAll();
        }

        public ObservableCollection<Prostorija> getBolesnickeSobeZaHospitalizacijuUIntevalu(DateTime pocetkaHospitalizacije, DateTime krajHospitalizacije)
        {
            return hospitalizacijaServisObjekat.getBolesnickeSobeZaHospitalizacijuUIntevalu(pocetkaHospitalizacije, krajHospitalizacije);
        }
    }
}
