/***********************************************************************
 * Module:  ProstorijeServis.cs
 * Author:  lacik
 * Purpose: Definition of the Class Servis.ProstorijeServis
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Model;
using Repozitorijum;

namespace Servis
{
    public class ProstorijeServis
    {
        public ProstorijeRepozitorijum ProstorijeRepozitorijumRef { get; set; }
        private InventariRepozitorijum InventariRepozitorijumRef { get; set; }
        private InventariSerivs InventariSerivsObjekat { get; set; }
        public ProstorijeServis()
        {
            ProstorijeRepozitorijumRef = ProstorijeRepozitorijum.GetInstance;
            InventariRepozitorijumRef = InventariRepozitorijum.GetInstance;
            InventariSerivsObjekat = new InventariSerivs();
        }

        

        public Model.Prostorija DodajProstoriju(Model.Prostorija novaProstorija)
        {
            // TODO: implement
            return null;
        }

        public Model.Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina)
        {
            int idNoveProstorije = ProstorijeRepozitorijumRef.GetFirstFitID();
            int idNovInventar = InventariRepozitorijumRef.GetFirstFitID();
            Inventar noviInventar = new Inventar(idNovInventar, idNoveProstorije, new List<Oprema>(), new List<Lek>());
            InventariRepozitorijumRef.DodajInventar(noviInventar);

            Prostorija novaProstorija = new Prostorija(null, idNoveProstorije, tipProstorije, broj, sprat, povrsina, 0, 0, idNovInventar);
            return ProstorijeRepozitorijumRef.DodajProstoriju(novaProstorija);
            
        }

        public Model.Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina, int brojKreveta, int brojSlobodnihKreveta)
        {
            int idNoveProstorije = ProstorijeRepozitorijumRef.GetFirstFitID();
            int idNovInventar = InventariRepozitorijumRef.GetFirstFitID();
            Inventar noviInventar = new Inventar(idNovInventar, idNoveProstorije, new List<Oprema>(), new List<Lek>());
            InventariRepozitorijumRef.DodajInventar(noviInventar);
           
            Prostorija novaProstorija = new Prostorija(null, idNoveProstorije, tipProstorije, broj, sprat, povrsina, brojKreveta, brojSlobodnihKreveta, idNovInventar);
            return ProstorijeRepozitorijumRef.DodajProstoriju(novaProstorija);
        }



        public Prostorija ObrisiProstoriju(Prostorija delProstorija)
        {
            // mozda bi ovde trebalo pozvati i brisanje inventara sa brisanjem ove prostorije
            return ProstorijeRepozitorijumRef.ObrisiProstoriju(delProstorija);
        }


        public Prostorija AzurirajProstoriju(Model.Prostorija editProstorija)
        {
            // TODO: implement
            return null;
        }
        public Prostorija AzurirajProstoriju(Prostorija editProstorija,
                                             string broj,
                                             int sprat,
                                             double povrsina)
        {
            editProstorija.Broj = broj;
            editProstorija.Sprat = sprat;
            editProstorija.Povrsina = povrsina;

            return ProstorijeRepozitorijumRef.AzurirajProstoriju(editProstorija);
        }
        public Prostorija AzurirajProstoriju(Prostorija editProstorija,
                                             string broj,
                                             int sprat,
                                             double povrsina,
                                             int brKreveta,
                                             int brSlobodnihKreveta)
        {
            editProstorija.Broj = broj;
            editProstorija.Sprat = sprat;
            editProstorija.Povrsina = povrsina;
            editProstorija.BrojKreveta = brKreveta;
            editProstorija.BrojSlobodnihKreveta = brSlobodnihKreveta;

            return ProstorijeRepozitorijumRef.AzurirajProstoriju(editProstorija);
        }





        public Prostorija GetProstorijaById(int id)
        {
            // TODO: implement
            return null;
        }


        public List<Prostorija> GetProstorijeAll()
        {
            // TODO: implement
            return null;
        }


        public ObservableCollection<Prostorija> getProstorijeAllObservable()
        {
            ProstorijeRepozitorijumRef = Repozitorijum.ProstorijeRepozitorijum.GetInstance;
            List<Prostorija> lP = ProstorijeRepozitorijumRef.GetProstorijeAll();
            ObservableCollection<Prostorija> obsP = new ObservableCollection<Prostorija>();
            foreach(Prostorija p in lP)
            {
                obsP.Add(p);
            }
            return obsP;
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





    }
}