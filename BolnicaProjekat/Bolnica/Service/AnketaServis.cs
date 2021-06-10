using System;
using System.Collections.Generic;
using DTO;
using Model;
using Repozitorijum;

namespace Servis
{
    class AnketaServis
    {
        AnketaRepozitorijum _AnketaRepozitorijum;
        PacijentRepozitorijum _PacijentRepozitorijum;
        LekarRepozitorijum _LekarRepozitorijim;

        public AnketaServis()
        {
            _AnketaRepozitorijum = AnketaRepozitorijum.GetInstance;
            _PacijentRepozitorijum = PacijentRepozitorijum.GetInstance;
            _LekarRepozitorijim = LekarRepozitorijum.GetInstance;
        }

        public Ocena DodajOcenuBolnice(int idPacijenta,string text,int ocjena)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            return AnketaRepozitorijum.GetInstance.DodajOcenu(new Ocena(0-id-1,text,ocjena,idPacijenta,-1,DateTime.Now));
        }

        public Ocena DodajOcenuLekara(ZdravstvenaUslugaDTO pregled, int idPacijenta, string text,int ocjena)
        {
            int id = AnketaRepozitorijum.GetInstance.GetAll().Count;
            int idLekara = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(pregled.IdLekara).Id;
            return _AnketaRepozitorijum.DodajOcenu(new Ocena(id + 1, text, ocjena, idPacijenta,idLekara, DateTime.Now));
        }

        public List<OcenaDTO> GetSveOceneLekara()
        {
            List<Ocena> ocene = new List<Ocena>();

            foreach (Ocena o in AnketaRepozitorijum.GetInstance.GetAll())
            {
                if (o.Id > 0)
                    ocene.Add(o);
            }

            return KonvertujModelDTO(ocene);
        }

        public List<OcenaDTO> GetOcenePacijenta(int id)
        {
            return KonvertujModelDTO(_AnketaRepozitorijum.GetOceneByPatientId(id));
        }

        public List<OcenaDTO> GetOceneOdabranogLekara(int id)
        {
            return KonvertujModelDTO(_AnketaRepozitorijum.GetOceneByLekarId(id));
        }

        public List<OcenaDTO> GetSveOceneBolnice()
        {
            List<Ocena> ocene = new List<Ocena>();

            foreach(Ocena o in _AnketaRepozitorijum.GetAll())
            {
                if (o.Id < 0)
                    ocene.Add(o);
            }
            return KonvertujModelDTO(ocene);
        }

        public List<OcenaDTO> KonvertujModelDTO(List<Ocena> ocene)
        {
            List<OcenaDTO> OceneDTO = new List<OcenaDTO>();
            foreach (Ocena o in ocene)
            {
                String NazivLekara;
                bool OcenaBolnice;
                if (o.IdLekara > 0)
                {
                    NazivLekara = _LekarRepozitorijim.GetById(o.IdLekara).Ime + " " + _LekarRepozitorijim.GetById(o.IdLekara).Prezime;
                    OcenaBolnice = false;
                }
                else
                {
                    NazivLekara = "Zdravo bolnica";
                    OcenaBolnice = true;
                }
                String NazivAutora = _PacijentRepozitorijum.GetById(o.IdPacijenta).Ime + " " + _PacijentRepozitorijum.GetById(o.IdPacijenta).Prezime;
                OceneDTO.Add(new OcenaDTO(o.Id, o.Komentar, o.Vrednost, o.IdPacijenta, o.IdLekara, o.Datum, NazivLekara, NazivAutora, OcenaBolnice));
            }
            return OceneDTO;
        }

        public double GetProsecnaOcena(int idLekara)
        {
            int Suma = 0;
            List<Ocena> oceneLekara = _AnketaRepozitorijum.GetOceneByLekarId(idLekara);
            foreach (Ocena o in oceneLekara)
                Suma += o.Vrednost;
            return Convert.ToDouble(Suma/oceneLekara.Count);
        }
    }
}
