using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DTO;
using Model;
using Repozitorijum;

namespace Servis
{
    class TerminProstorijeServis
    {
        
        public TerminProstorijeRepozitorijum TerminProstorijeRepozitorijumRef { get; set; }
        private InventariSerivs inventariServisObjekat;

        public TerminProstorijeServis()
        {
            TerminProstorijeRepozitorijumRef = TerminProstorijeRepozitorijum.GetInstance;
            inventariServisObjekat = new InventariSerivs();
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
                TerminProstorije tp = new TerminProstorije(id, pocetak, kraj, idProstorije1, idProstorije2, -1, tipTerminaProstorije, false, new List<TransferOpreme>(), null);
                TerminProstorijeRepozitorijumRef.DodajTerminProstorije(tp);
                return true;
            }

            return false;
        }

        public bool ZakaziTerminRenoviranjaProstorije(int idProstorije, DateTime pocetak, DateTime kraj)
        {
            ObservableCollection<Termin> termini = null;

            termini = GetTerminiByProstorijaIdObs(idProstorije);

            if (ProveraIspravnogNovogZakazivanja(pocetak, kraj, termini))
            {
                int id = TerminProstorijeRepozitorijumRef.GetFirstFitID();
                TerminProstorije tp = new TerminProstorije(id, pocetak, kraj, idProstorije, -1, -1, TipTerminaProstorije.Renoviranje, false, new List<TransferOpreme>(), null);
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


        public ObservableCollection<TerminProstorije> GetTerminiPreraspodeleByProstorijaIdObs(int idProstorije1, int idProstorije2 = -1)
        {
            ObservableCollection<TerminProstorije> obsTerminiProstorije = new ObservableCollection<TerminProstorije>();
            List<TerminProstorije> terminiProstorija = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();

            if (idProstorije2 == -1)    // ako je magacin
            {
                foreach (TerminProstorije tp in terminiProstorija)
                {
                    if (tp.IdProstorije1 == idProstorije1 || tp.IdProstorije2 == idProstorije1)
                    {
                        if (tp.isPreraspodela())
                        {
                            obsTerminiProstorije.Add(tp);
                        }
                            
                    }
                }
            }
            else
            {
                foreach (TerminProstorije tp in terminiProstorija)
                {
                    if (tp.IdProstorije1 == idProstorije1 && tp.IdProstorije2 == idProstorije2)
                    {
                        if (tp.isPreraspodela())
                        {
                            obsTerminiProstorije.Add(tp);
                        }
                    }
                    else if (tp.IdProstorije1 == idProstorije2 && tp.IdProstorije2 == idProstorije1)
                    {
                        if (tp.isPreraspodela())
                        {
                            obsTerminiProstorije.Add(tp);
                        }
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

        public TerminProstorije AzurirajTransferOpreme(TerminProstorije terminProstorije)
        {
            return TerminProstorijeRepozitorijumRef.AzurirajTransferOpreme(terminProstorije);
        }

        public ObservableCollection<TransferOpreme> GetTransferOpremeObservebleByTerminProstorije(TerminProstorije terminProstorije)
        {
            ObservableCollection<TransferOpreme> obsTransferOpreme = new ObservableCollection<TransferOpreme>();
            if(terminProstorije != null)
            {
                foreach(TransferOpreme top in terminProstorije.ListaTransferOpreme)
                {
                    obsTransferOpreme.Add(top);
                }
            }

            return obsTransferOpreme;
        }


        public TransferOpreme DodajTrensferZaTerminProstorije(TerminProstorije terminProstorije, TransferOpreme transferOpreme)
        {
            if(terminProstorije == null || transferOpreme == null)
            {
                return null;
            }

            Inventar inventar1 = inventariServisObjekat.GetInventarById(transferOpreme.IdInventar1);
            Inventar inventar2 = inventariServisObjekat.GetInventarById(transferOpreme.IdInventar2);

            // provera dal u inventaru ima toliko opreme koliko zelimo
            if(transferOpreme.IdInventar1 == inventar1.Id)
            {
                if (inventar1.RazlikaUKoliciniOpreme(transferOpreme) < 0)
                {
                    // nije u redu
                    return null;
                }
            }
            else if(transferOpreme.IdInventar1 == inventar2.Id)
            {
                if (inventar2.RazlikaUKoliciniOpreme(transferOpreme) < 0)
                {
                    // nije u redu
                    return null;
                }
            }
            

            foreach (TransferOpreme top in terminProstorije.ListaTransferOpreme)
            {
                if(top.SifraOpreme == transferOpreme.SifraOpreme && top.IdInventar1 == transferOpreme.IdInventar1 && top.IdInventar2 == transferOpreme.IdInventar2)
                {
                    top.KolicinaOpreme = transferOpreme.KolicinaOpreme;         // postoji takav objekat i editujemo
                    if(top.KolicinaOpreme == 0)
                    {
                        // prosledjivanje 0 je zapravo brisanje transfera te opreme 
                        terminProstorije.ListaTransferOpreme.Remove(top);
                        return null;
                    }
                    else
                    {
                        return top;
                    }
                }
            }

            // ako ga nema u toj listi onda treba dodati
            terminProstorije.ListaTransferOpreme.Add(transferOpreme);

            return null;
        }


        public ObservableCollection<TerminProstorijeDTO> GetTerminiProstorijeDTOobsByProstorija(Prostorija prostorija)
        {
            ObservableCollection<TerminProstorijeDTO> obsTerminProstorijeDTO = new ObservableCollection<TerminProstorijeDTO>();
            List<TerminProstorije> terminiProstorije = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();

            foreach(TerminProstorije tp in terminiProstorije)
            {
                if(tp.IdProstorije1 == prostorija.Id || tp.IdProstorije2 == prostorija.Id)
                {
                    obsTerminProstorijeDTO.Add(new TerminProstorijeDTO(tp));
                }
            }

            return obsTerminProstorijeDTO;
        }


        public bool ZakaziTerminRazdvajanjaProstorije(int idProstorije, DateTime pocetak, DateTime kraj, TransformacijaProstorijeParametri transformacijaProstorije)
        {
            ObservableCollection<Termin> termini = null;

            termini = GetTerminiByProstorijaIdObs(idProstorije);

            if (ProveraIspravnogNovogZakazivanja(pocetak, kraj, termini))
            {
                int id = TerminProstorijeRepozitorijumRef.GetFirstFitID();
                TerminProstorije tp = new TerminProstorije(id, pocetak, kraj, idProstorije, -1, -1, TipTerminaProstorije.TransformacijaRazdvajanje, false, new List<TransferOpreme>(), transformacijaProstorije);
                TerminProstorijeRepozitorijumRef.DodajTerminProstorije(tp);
                return true;
            }

            return false;
        }


        public void ThreadPreraspodelaInventara()
        {
            while (true)
            {

                List<TerminProstorije> listaTerminaProstorije = TerminProstorijeRepozitorijumRef.GetTerminiProstorijeAll();
                InventariSerivs inventarServiObjekat = new InventariSerivs();

                foreach (TerminProstorije tp in listaTerminaProstorije)
                {
                    if(tp.tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiM ||
                       tp.tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiP)
                    {
                        if(tp.Pocetak < DateTime.Now && !tp.PreraspodelaIzvrsena)
                        {
                            // izvrsi preraspodelu
                            string info = "Preraspodela Inventara\n";
                            foreach(TransferOpreme top in tp.ListaTransferOpreme)
                            {
                                if (inventarServiObjekat.preraspodelaOpreme(top))
                                {
                                    info += "[" + top.BrojSpratProstorije1 + "] [" + top.BrojSpratProstorije2 + "] - Oprema: " + top.SifraOpreme + "  Kolicina: " + top.KolicinaOpreme + "\n"; 
                                }
                            }
                            
                            tp.PreraspodelaIzvrsena = true;
                            TerminProstorijeRepozitorijumRef.AzurirajTransferOpreme(tp);
                            MessageBox.Show(info);
                        }
                    }else if (tp.tipTerminaProstorije == TipTerminaProstorije.TransformacijaRazdvajanje ||
                              tp.tipTerminaProstorije == TipTerminaProstorije.TransformacijaSpajanje)
                    {



                    }
                }

                for(int i = 0; i < listaTerminaProstorije.Count; i++)
                {
                    TerminProstorije tp = listaTerminaProstorije[i];
                    if (tp.tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiM ||
                       tp.tipTerminaProstorije == TipTerminaProstorije.PreraspodelaInventaraPiP ||
                       tp.tipTerminaProstorije == TipTerminaProstorije.Renoviranje)
                    {
                        if (tp.Kraj < DateTime.Now)
                        {
                            // prosao je termin i mozemo obrisati
                            TerminProstorijeRepozitorijumRef.OtkaziTerminProstorije(tp);  // oprezno
                            //MessageBox.Show("obrisan je termin ");
                            i = -1;
                        }
                    }
                }

                Thread.Sleep(60*1000);      // na svkaih 60 sekundi    

            }
        }

    }
}
