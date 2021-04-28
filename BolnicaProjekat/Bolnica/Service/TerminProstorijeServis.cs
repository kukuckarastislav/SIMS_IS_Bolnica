using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using Repozitorijum;

namespace Servis
{
    class TerminProstorijeServis
    {
        
        public TerminProstorijeRepozitorijum TerminProstorijeRepozitorijumRef { get; set; }

        public TerminProstorijeServis()
        {
            TerminProstorijeRepozitorijumRef = TerminProstorijeRepozitorijum.GetInstance;
        }

        public void sortirajTermine(ObservableCollection<TerminProstorije> obsTerminiZauzetosti)
        {
            for (int i = 0; i < obsTerminiZauzetosti.Count - 1; i++)
            {
                if (obsTerminiZauzetosti[i].Pocetak > obsTerminiZauzetosti[i + 1].Pocetak)
                {
                    TerminProstorije tp = obsTerminiZauzetosti[i];
                    obsTerminiZauzetosti[i] = obsTerminiZauzetosti[i + 1];
                    obsTerminiZauzetosti[i + 1] = tp;
                    i = -1;
                }
            }      
        }

        public void sortirajTermine(ObservableCollection<Termin> obsTerminiZauzetosti)
        {
            for (int i = 0; i < obsTerminiZauzetosti.Count - 1; i++)
            {
                if (obsTerminiZauzetosti[i].Pocetak > obsTerminiZauzetosti[i + 1].Pocetak)
                {
                    Termin tp = obsTerminiZauzetosti[i];
                    obsTerminiZauzetosti[i] = obsTerminiZauzetosti[i + 1];
                    obsTerminiZauzetosti[i + 1] = tp;
                    i = -1;
                }
            }
        }

        public ObservableCollection<Termin> GetTerminiByProstorijaIdObs(int idProstorije)
        {
            ObservableCollection<Termin> obsTerminiZauzetosti = new ObservableCollection<Termin>();
            List<TerminProstorije> terminiProstorija = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();

            foreach (TerminProstorije tp in terminiProstorija)
            {
                if (tp.IdProstorije1 == idProstorije || tp.IdProstorije2 == idProstorije)
                {
                    obsTerminiZauzetosti.Add(new Termin(tp.Pocetak, tp.Kraj));
                }
            }

            sortirajTermine(obsTerminiZauzetosti);
            // obsTerminiZauzetosti.Add(new Termin(new DateTime(2021, 4, 28), new DateTime(2021, 4, 29)));
            return obsTerminiZauzetosti;
        }

        public ObservableCollection<Termin> GetUnijaTerminaByProstorijaIdObs(int idProstorije1, int idProstorije2)
        {
            /*
            ObservableCollection<TerminProstorije> obsTerminiZauzetosti = new ObservableCollection<TerminProstorije>();
            List<TerminProstorije> terminiProstorija = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();
            //List<TerminProstorije> terminiProstorija = new List<TerminProstorije>();
            //terminiProstorija.Add(new TerminProstorije(77, new DateTime(2021, 4, 28), new DateTime(2021, 4, 29), 1, 2, -1, TipTerminaProstorije.Renoviranje, false, null));

            foreach (TerminProstorije terminProstorije in terminiProstorija)
            {
                if(terminProstorije.IdProstorije1 == idProstorije1 || terminProstorije.IdProstorije2 == idProstorije1)
                {
                    obsTerminiZauzetosti.Add(terminProstorije);
                }
                else if(terminProstorije.IdProstorije1 == idProstorije2 || terminProstorije.IdProstorije2 == idProstorije2)
                {
                    obsTerminiZauzetosti.Add(terminProstorije);
                }
            }
            */
            ObservableCollection<Termin> obsTZPro1= GetTerminiByProstorijaIdObs(idProstorije1);
            ObservableCollection<Termin> obsTZPro2 = GetTerminiByProstorijaIdObs(idProstorije2);
            ObservableCollection<Termin> obsTZPro = new ObservableCollection<Termin>();
            foreach (Termin t in obsTZPro1) obsTZPro.Add(t);
            foreach (Termin t in obsTZPro2) obsTZPro.Add(t);
            sortirajTermine(obsTZPro);

            ObservableCollection<Termin> obsUnijaTerminiZauzetosti = new ObservableCollection<Termin>();

            /*  REFERENCA: https://www.geeksforgeeks.org/merging-intervals/
             *  ALGORITAM ZA SPAJANJE VREMENSKIH INTEVALA (UNIJA)
             * */
            int itStek = 0;
            if (obsTZPro.Count == 0) return obsUnijaTerminiZauzetosti;
            obsUnijaTerminiZauzetosti.Add(obsTZPro[0]);
            for(int i = 1; i < obsTZPro.Count; i++)
            {
                if (obsUnijaTerminiZauzetosti[itStek].Kraj < obsTZPro[i].Pocetak) 
                {
                    obsUnijaTerminiZauzetosti.Add(obsTZPro[i]);
                    itStek++;
                }
                else if(obsUnijaTerminiZauzetosti[itStek].Kraj < obsTZPro[i].Kraj)
                {
                    obsUnijaTerminiZauzetosti[itStek].Kraj = obsTZPro[i].Kraj;
                }
            }

            return obsUnijaTerminiZauzetosti;
        }


        public bool ZakaziTerminPremestanjaProstorije(int idProstorije1, int idProstorije2, TipTerminaProstorije tipTerminaProstorije, DateTime pocetak, DateTime kraj)
        {
            ObservableCollection<Termin> termini = null;
            
            if (tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiM)
            {
                idProstorije2 = -1;
                termini = GetTerminiByProstorijaIdObs(idProstorije1);
            }
            else if(tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiP)
            {
                termini = GetUnijaTerminaByProstorijaIdObs(idProstorije1, idProstorije2);
            }

            if (ProveraIspravnogNovogZakazivanja(pocetak, kraj, termini))
            {
                int id = TerminProstorijeRepozitorijumRef.GetFirstFitID();
                TerminProstorije tp = new TerminProstorije(id, pocetak, kraj, idProstorije1, idProstorije2, -1, tipTerminaProstorije, false, new List<TransferOpreme>());
                TerminProstorijeRepozitorijumRef.DodajTerminProstorije(tp);
                return true;
            }

            return false;
        }

        public bool ProveraIspravnogNovogZakazivanja(DateTime pocetak, DateTime kraj, ObservableCollection<Termin> termini)
        {
            foreach(Termin t in termini)
            {
                if( !((pocetak > t.Pocetak && pocetak > t.Kraj) || (pocetak < t.Pocetak && kraj < t.Pocetak)) )
                {
                    return false;
                }
            }
            return true;
        }

        public ObservableCollection<TerminProstorije> GetTerminiZauzetostiByProstorijaIdObs(int idProstorije1, int idProstorije2=-1)
        {
            ObservableCollection<TerminProstorije> obsTerminiProstorije = new ObservableCollection<TerminProstorije>();
            List<TerminProstorije> terminiProstorija = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();

            

            if (idProstorije2 == -1)    // ako je magacin
            {
                foreach (TerminProstorije tp in terminiProstorija)
                {
                    if (tp.IdProstorije1 == idProstorije1 || tp.IdProstorije2 == idProstorije1)
                    {
                        obsTerminiProstorije.Add(tp);
                    }
                }
            }
            else
            {
                foreach (TerminProstorije tp in terminiProstorija)
                {
                    if(tp.IdProstorije1 == idProstorije1 && tp.IdProstorije2 == idProstorije2)
                    {
                        obsTerminiProstorije.Add(tp);
                    }
                    else if(tp.IdProstorije1 == idProstorije2 && tp.IdProstorije2 == idProstorije1)
                    {
                        obsTerminiProstorije.Add(tp);
                    }
                }
            }

            return obsTerminiProstorije;
        }

        public TerminProstorije OtkaziTerminProstorije(TerminProstorije terminProstorije)
        {
            // dodati logiku za zdravstvenu uslugu mozda??? ili notifikacije ?? nem pojma videcemo :D

            TerminProstorijeRepozitorijumRef.OtkaziTerminProstorije(terminProstorije);
            return terminProstorije;
        }

    }
}
