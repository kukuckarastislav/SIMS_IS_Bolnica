using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Servis;

namespace Kontroler
{
    class LekoviKontroler
    {
        private LekoviServis servis;

        public LekoviKontroler()
        {
            servis = new LekoviServis();
        }

        public void PosaljiLekoveNaReviziju(ObservableCollection<Lekar> odabraniLekari, Lek lek)
        {
            servis.PosaljiLekoveNaReviziju(odabraniLekari, lek);
        }

        public ObservableCollection<Lek> GetOdobreniLekovi()
        {
            return servis.GetOdobreniLekovi();
        }

        public ObservableCollection<Lek> GetNeOdobreniLekovi()
        {
            return servis.GetNeodobreniLekovi();
        }

        public void ObrisiLek(Lek lek)
        {
            servis.ObrisiLek(lek);
        }

        internal void DodajLek(Lek lek)
        {
            servis.DodajLek(lek);
        }
    }
}
