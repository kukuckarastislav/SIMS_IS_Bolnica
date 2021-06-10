using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DTO;
using Model;
using Repozitorijum;

namespace Servis
{
    public class ProstorijeServis
    {
        private ProstorijeRepozitorijum ProstorijeRepozitorijumRef { get; set; }
        private InventariRepozitorijum InventariRepozitorijumRef { get; set; }

        private InventariSerivs InventariSerivsObjekat;

        public ProstorijeServis()
        {
            ProstorijeRepozitorijumRef = ProstorijeRepozitorijum.GetInstance;
            InventariRepozitorijumRef = InventariRepozitorijum.GetInstance;
        }

        public Prostorija DodajProstoriju(ProstorijaDTO prostorijaDTO)
        {
            int idNoveProstorije = ProstorijeRepozitorijumRef.GetFirstFitID();
            int idNovInventar = InventariRepozitorijumRef.GetFirstFitID();
            Inventar noviInventar = new Inventar(idNovInventar, idNoveProstorije, new List<Oprema>(), new List<Lek>());
            InventariRepozitorijumRef.DodajInventar(noviInventar);
            Prostorija novaProstorija = new Prostorija(null, idNoveProstorije, prostorijaDTO.TipProstorije, prostorijaDTO.Broj, prostorijaDTO.Sprat, prostorijaDTO.Povrsina, prostorijaDTO.BrojKreveta, prostorijaDTO.BrojSlobodnihKreveta, idNovInventar);
            return ProstorijeRepozitorijumRef.DodajProstoriju(novaProstorija);
        }

        public Prostorija ObrisiProstoriju(Prostorija delProstorija)
        {
            InventariSerivsObjekat = new InventariSerivs();
            InventariSerivsObjekat.PrebaciSvuOpremu(delProstorija.IdInventar, 0);   //0 inventar je magacin
            InventariSerivsObjekat.ObrisiInventarById(delProstorija.IdInventar);
            return ProstorijeRepozitorijumRef.ObrisiProstoriju(delProstorija);
        }

        public Prostorija AzurirajProstoriju(ProstorijaDTO editProstorijaDTO)
        {
            Prostorija editProstorija = GetProstorijaById(editProstorijaDTO.Id);
            editProstorija.Broj = editProstorijaDTO.Broj;
            editProstorija.Sprat = editProstorijaDTO.Sprat;
            editProstorija.Povrsina = editProstorijaDTO.Povrsina;
            editProstorija.BrojKreveta = editProstorijaDTO.BrojKreveta;
            editProstorija.BrojSlobodnihKreveta = editProstorijaDTO.BrojSlobodnihKreveta;
            return ProstorijeRepozitorijumRef.AzurirajProstoriju(editProstorija);
        }

        public Prostorija GetProstorijaById(int id)
        {
            return ProstorijeRepozitorijumRef.GetProstorijaById(id);
        }

        public List<Prostorija> GetProstorijeAll()
        {
            return ProstorijeRepozitorijumRef.GetProstorijeAll();
        }

        public ObservableCollection<Prostorija> getProstorijeTipObservable(TipProstorije tipProstorije)
        {
            ProstorijeRepozitorijumRef = Repozitorijum.ProstorijeRepozitorijum.GetInstance;
            List<Prostorija> lP = ProstorijeRepozitorijumRef.GetProstorijeAll();
            ObservableCollection<Prostorija> obsP = new ObservableCollection<Prostorija>();
            foreach (Prostorija p in lP)
            {
                if (p.TipProstorije == tipProstorije)
                {
                    obsP.Add(p);
                }
            }
            return obsP;
        }

        public List<Prostorija> getProstorijeTip(TipProstorije tipProstorije)
        {
            List<Prostorija> prostorijeTipa = new List<Prostorija>();
            foreach (Prostorija prostorija in GetProstorijeAll())
            {
                if (prostorija.TipProstorije == tipProstorije)
                {
                    prostorijeTipa.Add(prostorija);
                }
            }
            return prostorijeTipa;
        }

        public bool NapraviDveProstorijeRazdvajanjemJedne(TerminProstorije terminProstorije)
        {
            TransformacijaProstorijeParametri tpp = terminProstorije.TransformacijaProstorijeParam;
            ProstorijaDTO prostorijaDTOA = new ProstorijaDTO(-1, tpp.TipProstorijeA, tpp.BrojA, tpp.SpratA, tpp.PovrsinaA);
            DodajProstoriju(prostorijaDTOA);
            ProstorijaDTO prostorijaDTOB = new ProstorijaDTO(-1, tpp.TipProstorijeB, tpp.BrojB, tpp.SpratB, tpp.PovrsinaB);
            DodajProstoriju(prostorijaDTOB);
            return true;
        }

        public bool ObrisiProstorijuById(int idProstorije)
        {
            Prostorija delProstorija = GetProstorijaById(idProstorije);
            ObrisiProstoriju(delProstorija);
            return true;
        }

        public bool NapraviJednuProstorijuSpajanjemDve(TerminProstorije terminProstorije)
        {
            TransformacijaProstorijeParametri tpp = terminProstorije.TransformacijaProstorijeParam;
            ProstorijaDTO prostorijaDTOA = new ProstorijaDTO(-1, tpp.TipProstorijeA, tpp.BrojA, tpp.SpratA, tpp.PovrsinaA);
            DodajProstoriju(prostorijaDTOA);
            return true;
        }

        public List<ProstorijaDTO> GetProstorijeDTO()
        {
            List<ProstorijaDTO> prostorijeDto = new List<ProstorijaDTO>();
            foreach (Prostorija prostorija in GetProstorijeAll())
            {
                prostorijeDto.Add(KonvertujModelUDto(prostorija));
            }
            return prostorijeDto;
        }

        public ProstorijaDTO KonvertujModelUDto(Prostorija prostorija)
        {
            ProstorijaDTO dto = new ProstorijaDTO();
            dto.Id = prostorija.Id;
            dto.Povrsina = prostorija.Povrsina;
            dto.Sprat = prostorija.Sprat;
            dto.TipProstorije = prostorija.TipProstorije;
            dto.Broj = prostorija.Broj;
            return dto;
        }

    }
}