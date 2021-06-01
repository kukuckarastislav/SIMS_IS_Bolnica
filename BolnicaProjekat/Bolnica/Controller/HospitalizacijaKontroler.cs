using Model;
using Servis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class HospitalizacijaKontroler
    {

        private HospitalizacijaServis servis;

        public HospitalizacijaKontroler()
        {
            servis = new HospitalizacijaServis();
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

        public void DodajHospitalizaciju(Hospitalizacija hospitalizacija)
        {
            HospitalizacijaServis.DodajHospitalizaciju(hospitalizacija);
        }

        public ObservableCollection<Hospitalizacija> GetAll()
        {
            return HospitalizacijaServis.GetAll();
        }
    }
}
