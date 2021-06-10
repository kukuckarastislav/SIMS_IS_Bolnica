using Bolnica.Model;
using DTO;
using Model;
using Repozitorijum;
using System.Collections.Generic;


namespace Servis
{
    public class ReceptServis
    {
        private PacijentRepozitorijum PacijentRepozitorijumRef;
        private LekarRepozitorijum LekarRepozitorijumRef;
        private LekoviRepozitorijum LekoviRepozitorijumRef;
        private ReceptRepozitorijum ReceptRepozitorijumRef;


        public ReceptServis()
        {
            ReceptRepozitorijumRef = ReceptRepozitorijum.GetInstance;
            LekoviRepozitorijumRef = LekoviRepozitorijum.GetInstance;
            LekarRepozitorijumRef = LekarRepozitorijum.GetInstance;
            PacijentRepozitorijumRef = PacijentRepozitorijum.GetInstance;
        }

        public Recept DodajRecept(ReceptDTO recept)
        {
            return ReceptRepozitorijumRef.DodajRecept(KonvertujDTOModel(recept));
        }

        private Recept KonvertujDTOModel(ReceptDTO recept)
        {
            int id= ReceptRepozitorijumRef.getNewId();
            return new Recept(id,recept.Id, recept.IdPacijenta,recept.IdLeka,recept.DatumPropisivanja,recept.DatumIsteka,false,recept.OpisKoriscenja);
        }

        public Recept ObrisiRecept(Recept recept)
        {
            return ReceptRepozitorijumRef.ObrisiRecept(recept);

        }

        public List<Recept> GetPacijentovihRecepta(int pacId)
        {
            List<Recept> ret = new List<Recept>();
            List<Recept> recepti = ReceptRepozitorijumRef.GetAll();
            foreach(Recept r in recepti)
            {
                if (r.IdPacijenta == pacId)
                {
                    ret.Add(r);
                }
            }
            return ret;
        }

        internal List<ReceptDTO> GetReceptiPacijentaDTO(int id)
        {
            List<ReceptDTO> ret = new List<ReceptDTO>();

            foreach (var r in GetPacijentovihRecepta(id))
            {
                Lek lek = LekoviRepozitorijumRef.GetLekById(r.IdLeka);
                ret.Add(new ReceptDTO(1, r.IdLekara, LekarRepozitorijumRef.GetById(r.IdLekara).Ime + " " + LekarRepozitorijumRef.GetById(r.IdLekara).Prezime,
                    r.IdPacijenta, r.IdLeka, lek.Naziv, r.DatumPropisivanja, r.DatumIsteka, r.OpisKoriscenja, lek.Cena, lek.Kolicina));
            }
            return ret;
        }

        public List<DTORecept> GetPacijentovihReceptaDTO(int pacId)
        {
            List<DTORecept> ret = new List<DTORecept>();
            List<Recept> recepti = ReceptRepozitorijumRef.GetAll();
            Pacijent pac = PacijentRepozitorijumRef.GetById(pacId);
            
            foreach (Recept r in recepti)
            {
                if (r.IdPacijenta == pacId)
                {
                    Lek lek = LekoviRepozitorijumRef.GetLekById(r.IdLeka);
                    Lekar lekar = LekarRepozitorijumRef.GetById(r.IdLekara);
                    ret.Add(new DTORecept(r, pac, lek, lekar));
                }
            }
            return ret;
        }

        public List<Recept> GetAll()
        {
            return ReceptRepozitorijumRef.GetAll();
        }




    }
}
