using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    class LekoviServis
    {
        public void PosaljiLekoveNaReviziju(ObservableCollection<Lekar> odabraniLekari, Lek lek)
        {
            throw new NotImplementedException();

            //ovdje prolazi kroz sve lekare itd..
        }

        public ObservableCollection<Lek> GetOdobreniLekovi()
        {
            ObservableCollection<Lek> ret = new ObservableCollection<Lek>();
            ObservableCollection<Lek> lekovi = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek l in lekovi)
            {
                if (l.Odobren == true)
                    ret.Add(l);
            }
            return ret;
        }

        public ObservableCollection<Lek> GetNeodobreniLekovi()
        {
            ObservableCollection<Lek> ret = new ObservableCollection<Lek>();
            ObservableCollection<Lek> lekovi = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek l in lekovi)
            {
                if (l.Odobren == false)
                    ret.Add(l);
            }
            return ret;
        }

        public Lek ObrisiLek(Lek lek)
        {
            return Repozitorijum.LekoviRepozitorijum.GetInstance.ObrisiLek(lek);
        }

        
        public Lek DodajLek(Lek lek)
        {
            return Repozitorijum.LekoviRepozitorijum.GetInstance.DodajLek(lek);
        }
        
    }
}
