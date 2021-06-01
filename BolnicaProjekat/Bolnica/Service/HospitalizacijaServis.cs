using Model;
using System;
using Repozitorijum;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Bolnica.DTO;
using DTO;

namespace Servis
{
    public class HospitalizacijaServis
    {

        private ProstorijeServis prostorijeServisObjekat;

        public HospitalizacijaServis()
        {
            prostorijeServisObjekat = new ProstorijeServis();
        }

        public Hospitalizacija DodajHospitalizaciju(HospitalizacijaDTO hospitalizacijaDTO)
        {
            // TODO: dodati proveru tako sto cemo traziti objekte u servisimo, repozitorijuma
            // Prostorija prostorija = GetProstorijaById()
            int id = HospitalizacijaRepozitorijum.GetInstance.GetFirstFitID();
            Hospitalizacija hospitalizacija = new Hospitalizacija(id,
                                                                hospitalizacijaDTO.IdLekara,
                                                                hospitalizacijaDTO.IdPacijenta, 
                                                                hospitalizacijaDTO.IdProstorije, 
                                                                hospitalizacijaDTO.PocetakHospitalizacije, 
                                                                hospitalizacijaDTO.KrajHospitalizacije);


            HospitalizacijaRepozitorijum.GetInstance.DodajHospitalizaciju(hospitalizacija);
            return hospitalizacija;
        }

        public static Hospitalizacija ObrisiHospitalizacija(Hospitalizacija hospitalizacija)
        {
            return Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.ObrisiHospitalizaciju(hospitalizacija);
        }

        public static ObservableCollection<Hospitalizacija> GetPacijentovihHospitalizacija(int pacId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacije = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacije)
            {
                if (h.IdPacijenta == pacId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<HospitalizacijaDTO> GetPacijentovihHospitalizacijaDTO(int pacId)
        {
            ObservableCollection<HospitalizacijaDTO> ret = new ObservableCollection<HospitalizacijaDTO>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            Pacijent pac = Repozitorijum.PacijentRepozitorijum.GetInstance.GetById(pacId);

            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdPacijenta == pacId)
                {
                    Prostorija prostorija = Repozitorijum.ProstorijeRepozitorijum.GetInstance.GetProstorijaById(h.IdProstorije);
                    Lekar lekar = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(h.IdLekara);

                    //ret.Add(new HospitalizacijaDTO(h, pac, lekar, prostorija));
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetLekarovihHospitalizacije(int lekarId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdLekara == lekarId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetHospitalizacijeOdredjenogProstorija(int prostorijeId)
        {
            ObservableCollection<Hospitalizacija> ret = new ObservableCollection<Hospitalizacija>();
            ObservableCollection<Hospitalizacija> hospitalizacija = Repozitorijum.HospitalizacijaRepozitorijum.GetInstance.GetAll();
            foreach (Hospitalizacija h in hospitalizacija)
            {
                if (h.IdProstorije == prostorijeId)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public static ObservableCollection<Hospitalizacija> GetAll()
        {
            return HospitalizacijaRepozitorijum.GetInstance.GetAll();
        }


        public ObservableCollection<Prostorija> getBolesnickeSobeZaHospitalizacijuUIntevalu(DateTime pocetkaHospitalizacije, DateTime krajHospitalizacije)
        {
            ObservableCollection<Prostorija> BolesnickeSobeSaSlobodnimKrevetom = new ObservableCollection<Prostorija>();
            ObservableCollection<Prostorija> prostorije = prostorijeServisObjekat.getProstorijeTipObservable(TipProstorije.BolesnickaSoba);
            foreach (Prostorija p in prostorije)
            {
                if (dalJeProstorijaSlobodna(p, pocetkaHospitalizacije, krajHospitalizacije))
                {
                    BolesnickeSobeSaSlobodnimKrevetom.Add(p);
                }
            }
            return BolesnickeSobeSaSlobodnimKrevetom;
        }

        public bool dalJeProstorijaSlobodna(Prostorija prostorija, DateTime pocetkaHospitalizacije, DateTime krajHospitalizacije)
        {
            bool slobodna = false;
            ObservableCollection<Hospitalizacija> hospitalizacijeUProstoriji = HospitalizacijeUProstoriji(prostorija);
            sortirajHospitalizacije(hospitalizacijeUProstoriji);
            izbaciNepotrebneHospitalizacije(hospitalizacijeUProstoriji, pocetkaHospitalizacije, krajHospitalizacije);
            List<DateTime> vremenskiTermini = new List<DateTime>();
            foreach(Hospitalizacija hospitalizacija in hospitalizacijeUProstoriji)
            {
                vremenskiTermini.Add(hospitalizacija.PocetakHospitalizacije);
                vremenskiTermini.Add(hospitalizacija.KrajHospitalizacije);
            }
            sortirajDateTime(vremenskiTermini);
            int maksimumZauzetost = 0;
            for (int t = 0; t < vremenskiTermini.Count - 1; t++)
            {
                DateTime t1 = vremenskiTermini[t];
                DateTime t2 = vremenskiTermini[t + 1];
                int brojPreseka = 0;
                foreach (Hospitalizacija hosp in hospitalizacijeUProstoriji)
                {
                    if (t2 >= hosp.PocetakHospitalizacije && t1 <= hosp.KrajHospitalizacije)
                    {
                        brojPreseka++;
                    }
                }
                if (brojPreseka > maksimumZauzetost)
                {
                    maksimumZauzetost = brojPreseka;
                }

            }
            if (prostorija.BrojKreveta > maksimumZauzetost)
            {
                slobodna = true;
            }
            return slobodna;
        }

        public ObservableCollection<Hospitalizacija> HospitalizacijeUProstoriji(Prostorija prostorija)
        {
            ObservableCollection<Hospitalizacija> hospitalizacijeUProstoriji = new ObservableCollection<Hospitalizacija>();
            foreach (Hospitalizacija hospitalizacija in GetAll())
            {
                if(hospitalizacija.IdProstorije == prostorija.Id)
                {
                    hospitalizacijeUProstoriji.Add(hospitalizacija);
                }
            }
            return hospitalizacijeUProstoriji;
        }

        public void sortirajHospitalizacije(ObservableCollection<Hospitalizacija> hospitalizacije)
        {
            for (int i = 0; i < hospitalizacije.Count - 1; i++)
            {
                if (hospitalizacije[i].PocetakHospitalizacije > hospitalizacije[i + 1].PocetakHospitalizacije)
                {
                    Hospitalizacija hosp = hospitalizacije[i];
                    hospitalizacije[i] = hospitalizacije[i + 1];
                    hospitalizacije[i + 1] = hosp;
                    i = -1;
                }
            }
        }

        public void izbaciNepotrebneHospitalizacije(ObservableCollection<Hospitalizacija> hospitalizacije, DateTime pocetkaHospitalizacije, DateTime krajHospitalizacije)
        {
            for(int i = 0; i < hospitalizacije.Count; i++)
            {
                Hospitalizacija hospitalizacija = hospitalizacije[i];
                if(hospitalizacija.KrajHospitalizacije < pocetkaHospitalizacije ||
                   hospitalizacija.PocetakHospitalizacije > krajHospitalizacije)
                {
                    hospitalizacije.Remove(hospitalizacija);
                    i = -1;
                }
            }
        }
       
        public void sortirajDateTime(List<DateTime> vremena)
        {
            for (int i = 0; i < vremena.Count - 1; i++)
            {
                if (vremena[i] > vremena[i + 1])
                {
                    DateTime t = vremena[i];
                    vremena[i] = vremena[i + 1];
                    vremena[i + 1] = t;
                    i = -1;
                }
            }
        }

    }

}
