using Bolnica.Model;
using DTO;
using Model;
using Repozitorijum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servis
{
    public class ReceptServis
    {
        private PacijentRepozitorijum refPacijentRepozitorijum;
        private LekarRepozitorijum refLekarRepozitorijum;
        private LekoviRepozitorijum refLekoviRepozitorijum;


        public static Recept DodajRecept(Recept recept)
        {
            return Repozitorijum.ReceptRepozitorijum.GetInstance.DodajRecept(recept);

        }

        public static Recept ObrisiRecept(Recept recept)
        {
            return Repozitorijum.ReceptRepozitorijum.GetInstance.ObrisiRecept(recept);

        }

        public static ObservableCollection<Recept> GetPacijentovihRecepta(int pacId)
        {
            ObservableCollection<Recept> ret = new ObservableCollection<Recept>();
            ObservableCollection<Recept> recepti = Repozitorijum.ReceptRepozitorijum.GetInstance.GetAll();
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
                Lek lek = LekoviRepozitorijum.GetInstance.GetLekById(r.IdLeka);
                ret.Add(new ReceptDTO(1, r.IdLekara, LekarRepozitorijum.GetInstance.GetById(r.IdLekara).Ime + " " + LekarRepozitorijum.GetInstance.GetById(r.IdLekara).Ime,
                    r.IdPacijenta, r.IdLeka, lek.Naziv, r.DatumPropisivanja, r.DatumIsteka, r.OpisKoriscenja, lek.Cena, lek.Kolicina));//ovo nema smisla stv ali ajde za ispis
            }
            return ret;
        }

        public static ObservableCollection<DTORecept> GetPacijentovihReceptaDTO(int pacId)
        {
            ObservableCollection<DTORecept> ret = new ObservableCollection<DTORecept>();
            ObservableCollection<Recept> recepti = Repozitorijum.ReceptRepozitorijum.GetInstance.GetAll();
            Pacijent pac = Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(pacId);
            
            foreach (Recept r in recepti)
            {
                if (r.IdPacijenta == pacId)
                {
                    Lek lek = Repozitorijum.LekoviRepozitorijum.GetInstance.GetLekById(r.IdLeka);
                    Lekar lekar = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(r.IdLekara);

                    ret.Add(new DTORecept(r,pac,lek,lekar));
                }
            }
            return ret;
        }

        public static ObservableCollection<Recept> GetLekarovihRecepta(int lekarId)
        {
            ObservableCollection<Recept> ret = new ObservableCollection<Recept>();
            ObservableCollection<Recept> recepti = Repozitorijum.ReceptRepozitorijum.GetInstance.GetAll();
            foreach (Recept r in recepti)
            {
                if (r.IdLekara == lekarId)
                {
                    ret.Add(r);
                }
            }
            return ret;
        }

        public static ObservableCollection<Recept> GetRecepataOdredjenogLeka(int lekId)
        {
            ObservableCollection<Recept> ret = new ObservableCollection<Recept>();
            ObservableCollection<Recept> recepti = Repozitorijum.ReceptRepozitorijum.GetInstance.GetAll();
            foreach (Recept r in recepti)
            {
                if (r.IdLeka == lekId)
                {
                    ret.Add(r);
                }
            }
            return ret;
        }

        public static ObservableCollection<Recept> GetAll()
        {
            return ReceptRepozitorijum.GetInstance.GetAll();
        }




    }
}
