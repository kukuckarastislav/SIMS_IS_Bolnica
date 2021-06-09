using Bolnica.Interface;
using DTO;
using Model;
using Repozitorijum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Service
{
    public class LekoviCRUDServis : ILekoviCRUD
    {
        public void AzurirajLek(LekDTO lek)
        {
            LekoviRepozitorijum.GetInstance.AzurirajLek(lek);
        }

        public void DodajLek(LekDTO lek)
        {
            int idLeka = LekoviRepozitorijum.GetInstance.GetFirstFitID();
            Lek noviLek = new Lek(idLeka, lek.Sifra, lek.Naziv, false, lek.Opis, lek.Kolicina, lek.Cena, lek.Alergeni, lek.Revizije);
            LekoviRepozitorijum.GetInstance.DodajLek(noviLek);
        }
        public void ObrisiLek(LekDTO lek)
        {
            LekoviRepozitorijum.GetInstance.ObrisiLek(lek);
        }

        public List<LekDTO> GetNeodobreniLekovi()
        {
            List<LekDTO> neodobreniLekovi = new List<LekDTO>();
            List<Lek> sviLekovi = LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek lek in sviLekovi)
            {
                if (lek.Odobren == false)
                    neodobreniLekovi.Add(KonvertujModelUDto(lek));
            }
            return neodobreniLekovi;
        }

        public List<LekDTO> GetOdobreniLekovi()
        {
            List<LekDTO> odobreniLekovi = new List<LekDTO>();
            List<Lek> sviLekovi = LekoviRepozitorijum.GetInstance.GetAll();
            foreach (Lek lek in sviLekovi)
            {
                if (lek.Odobren)
                    odobreniLekovi.Add(KonvertujModelUDto(lek));
            }
            return odobreniLekovi;
        }

        public LekDTO KonvertujModelUDto(Lek lek)
        {
            return new LekDTO(lek.Id, lek.Sifra, lek.Naziv, lek.Odobren, lek.Opis, lek.Kolicina, lek.Cena, lek.Alergeni, lek.Revizije);
        }

    }
}
