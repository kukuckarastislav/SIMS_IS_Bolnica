using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Servis;
using Model;
using DTO;

namespace Kontroler
{
    class PodsjetnikKontroler
    {
        private PodsjetnikServis servis;

        public PodsjetnikKontroler()
        {
            servis = new PodsjetnikServis();
        }

        internal ObservableCollection<Podsjetnik> GetPodsjetnikPacijenta(int id)
        {
            return servis.GetPodsjetnikPacijenta(id);
        }

        internal void AzurirajStanjePosleCitanja(int id)
        {
            servis.AzurirajStanjePosleCitanja(id);
        }

        public void DodajPodsjetnik(PodsjetnikParametriDTO parametri)
        {
            servis.DodajPodsjetnik(parametri);
        }

        internal string GetBrojNeprocitanihPodsjetnika(int id)
        {
            return servis.GetBrojNeprocitanihPodsjetnika(id).ToString();
        }

        internal void DodajPodsjetnikZaUzimanjeLijeka(ParametriUzimanjaTerapijeDTO dto, int idLeka,int idPacijenta)
        {
            servis.DodajPodsjetnikZaUzimanjeLijeka(dto,idLeka,idPacijenta);
        }

        public List<StavkaIzvjestajaDTO> GetStavkeIzvjestajaZaDan(int idPacijenta,String dan)
        {
            return servis.GetStavkaIzvjestajaZaDan(idPacijenta,dan);
        }
    }
}
