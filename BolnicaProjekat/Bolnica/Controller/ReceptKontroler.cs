using Servis;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontroler
{
    public class ReceptKontroler
    {
        private ReceptServis servis;

        public ReceptKontroler()
        {
            servis = new ReceptServis();
        }
        public ObservableCollection<Recept> GetPacijentovihRecepta(int pacId)
        {
            return ReceptServis.GetPacijentovihRecepta(pacId);
        }

        public ObservableCollection<Recept> GetLekarovihRecepta(int lekarId)
        {
            return ReceptServis.GetPacijentovihRecepta(lekarId);
        }

        public ObservableCollection<Recept> GetRecepataOdredjenogLeka(int lekId)
        {
            return ReceptServis.GetPacijentovihRecepta(lekId);
        }
        public void ObrisiRecept(Recept recept)
        {
            ReceptServis.ObrisiRecept(recept);
        }

        public void DodajRecept(Recept recept)
        {
            ReceptServis.DodajRecept(recept);
        }

        public ObservableCollection<Recept> GetAll()
        {
            return ReceptServis.GetAll();
        }

        /*
        public ObservableCollection<Recept> GetPacijentovihRecepta(int pacId)
        public ObservableCollection<Recept> GetLekarovihRecepta(int lekarId)
        public ObservableCollection<Recept> GetRecepataOdredjenogLeka(int lekId)
        public Recept DodajRecept(Recept recept)
        public Recept ObrisiRecept(Recept recept)
        */
    }
}
