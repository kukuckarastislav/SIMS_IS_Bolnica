using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Repository;
using DTO;

namespace Service
{
    class ObavestenjeServis
    {

        private ObavestenjeRepozitorijum obavestenjeRepozitorijum;

        public ObservableCollection<ObavestenjeDTO> GetAllObavestenja()
        {
            ObservableCollection <Obavestenje>obavestenja = ObavestenjeRepozitorijum.GetInstance.GetAll();
            ObservableCollection<ObavestenjeDTO> obavestenjaDTO = new ObservableCollection<ObavestenjeDTO>();

            foreach (Obavestenje obavestenje in obavestenja)
            {
                ObavestenjeDTO dto = new ObavestenjeDTO();
                dto.Id = obavestenje.Id;
                dto.Naslov = obavestenje.Naslov;
                dto.Poruka = obavestenje.Poruka;
                dto.DatumObjave = obavestenje.DatumObjave;
                obavestenjaDTO.Add(dto);
            }

            return obavestenjaDTO;
        }

        public void ObrisiObavestenje(int id)
        {
            ObavestenjeRepozitorijum.GetInstance.ObrisiObavestenje(id);
        }

        public Obavestenje DodajObavestenje(Obavestenje obavestenje)
        {
            obavestenje.Id = ObavestenjeRepozitorijum.GetInstance.GetNewId(); ;
            return ObavestenjeRepozitorijum.GetInstance.DodajObavestenje(obavestenje);
        }

    }
}
