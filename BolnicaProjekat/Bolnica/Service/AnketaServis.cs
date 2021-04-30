using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repozitorijum;

namespace Servis
{
    class AnketaServis
    {

        public Ocena DodajOcenuBolnice(int idPacijenta,string text)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            return AnketaRepozitorijum.GetInstance.DodajOcenu(new Ocena(0-id-1,text,0,idPacijenta,-1,DateTime.Now)); //sve ocjene za bolnicu ce imati negativan id
        }

        internal Ocena DodajOcenuLekara(ZdravstvenaUsluga pregled, int idPacijenta, string text)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            int idLekara = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Id;
            return AnketaRepozitorijum.GetInstance.DodajOcenu(new Ocena(id + 1, text, 0, idPacijenta,idLekara, DateTime.Now)); //sve ocjene za bolnicu ce imati negativan id
        }
    }
}
