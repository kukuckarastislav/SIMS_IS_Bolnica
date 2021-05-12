using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Model;
using Repozitorijum;

namespace Servis
{
    class AnketaServis
    {

        public Ocena DodajOcenuBolnice(int idPacijenta,string text,int ocjena)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            return AnketaRepozitorijum.GetInstance.DodajOcenu(new Ocena(0-id-1,text,ocjena,idPacijenta,-1,DateTime.Now)); //sve ocjene za bolnicu ce imati negativan id
        }

        public Ocena DodajOcenuLekara(ZdravstvenaUsluga pregled, int idPacijenta, string text,int ocjena)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            int idLekara = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Id;
            return AnketaRepozitorijum.GetInstance.DodajOcenu(new Ocena(id + 1, text, ocjena, idPacijenta,idLekara, DateTime.Now)); //sve ocjene za bolnicu ce imati negativan id
        }

        public ObservableCollection<OcenaDTO> GetSveOceneLekara()
        {
            ObservableCollection<Ocena> ocene = new ObservableCollection<Ocena>();

            foreach (Ocena o in AnketaRepozitorijum.GetInstance.GetAll())
            {
                if (o.Id > 0)
                    ocene.Add(o);
            }

            return KonvertujModelDTO(ocene);
        }

        internal ObservableCollection<OcenaDTO> GetOcenePacijenta(int id)
        {
            return KonvertujModelDTO(AnketaRepozitorijum.GetInstance.GetOceneByPatientId(id));
        }

        internal ObservableCollection<OcenaDTO> GetOceneOdabranogLekara(int id)
        {
            return KonvertujModelDTO(AnketaRepozitorijum.GetInstance.GetOceneByLekarId(id));
        }

        public ObservableCollection<OcenaDTO> GetSveOceneBolnice()
        {
            ObservableCollection<Ocena> ocene = new ObservableCollection<Ocena>();

            foreach(Ocena o in AnketaRepozitorijum.GetInstance.GetAll())
            {
                if (o.Id < 0)
                    ocene.Add(o);
            }

            return KonvertujModelDTO(ocene);
        }

        public ObservableCollection<OcenaDTO> KonvertujModelDTO(ObservableCollection<Ocena> ocene)
        {
            ObservableCollection<OcenaDTO> OceneDTO = new ObservableCollection<OcenaDTO>();
            foreach (Ocena o in ocene)
            {
                String NazivLekara;
                bool OcenaBolnice;
                if (o.IdLekara > 0)
                {
                    NazivLekara = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(o.IdLekara).Ime + " " + Repozitorijum.LekarRepozitorijum.GetInstance.GetById(o.IdLekara).Prezime;
                    OcenaBolnice = false;
                }
                else
                {
                    NazivLekara = "Zdravo bolnica";
                    OcenaBolnice = true;
                }
                String NazivAutora = Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(o.IdPacijenta).Ime + " " + Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(o.IdPacijenta).Prezime;
                OceneDTO.Add(new OcenaDTO(o.Id, o.Komentar, o.Vrednost, o.IdPacijenta, o.IdLekara, o.Datum, NazivLekara, NazivAutora, OcenaBolnice));
            }
            return OceneDTO;
        }

        public double GetProsecnaOcena(int idLekara)
        {
            int Suma = 0;
            ObservableCollection<Ocena> oceneLekara = AnketaRepozitorijum.GetInstance.GetOceneByLekarId(idLekara);
            foreach (Ocena o in oceneLekara)
                Suma += o.Vrednost;

            return Convert.ToDouble(Suma/oceneLekara.Count);
        }
    }
}
