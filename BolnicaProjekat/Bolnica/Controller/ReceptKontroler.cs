using Servis;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Kontroler
{
    public class ReceptKontroler
    {
        private ReceptServis ReceptServisObjekat;

        public ReceptKontroler()
        {
            ReceptServisObjekat = new ReceptServis();
        }

        public List<Recept> GetLekarovihRecepta(int lekarId)
        {
            return ReceptServisObjekat.GetPacijentovihRecepta(lekarId);
        }

        public List<ReceptDTO> getReceptiPacijentaDTO(int id)
        {
            return ReceptServisObjekat.GetReceptiPacijentaDTO(id);
        }

        public List<Recept> GetRecepataOdredjenogLeka(int lekId)
        {
            return ReceptServisObjekat.GetPacijentovihRecepta(lekId);
        }
        public void ObrisiRecept(Recept recept)
        {
            ReceptServisObjekat.ObrisiRecept(recept);
        }

        public void DodajRecept(ReceptDTO recept)
        {
            ReceptServisObjekat.DodajRecept(recept);
        }

        public List<Recept> GetAll()
        {
            return ReceptServisObjekat.GetAll();
        }

    }
}
