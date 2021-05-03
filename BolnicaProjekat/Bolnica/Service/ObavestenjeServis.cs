using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;

namespace Service
{
    class ObavestenjeServis
    {

        private ObavestenjeRepozitorijum obavestenjeRepozitorijum;

        public ObservableCollection<Obavestenje> GetAllObavestenja()
        {
            return ObavestenjeRepozitorijum.GetInstance.GetAll();
        }

        public void ObrisiObavestenje(int id)
        {
            ObavestenjeRepozitorijum.GetInstance.ObrisiObavestenje(id);
        }

        public Obavestenje DodajObavestenje(Obavestenje obavestenje)
        {
            int id = ObavestenjeRepozitorijum.GetInstance.GetLastId() + 1;
            obavestenje.Id = id;
            return ObavestenjeRepozitorijum.GetInstance.DodajObavestenje(obavestenje);
        }

    }
}
