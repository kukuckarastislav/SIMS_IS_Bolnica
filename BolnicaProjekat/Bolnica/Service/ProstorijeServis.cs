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

namespace Servis
{
    public class ProstorijeServis
    {
        public Repozitorijum.ProstorijeRepozitorijum ProstorijeRepozitorijumRef { get; set; }
        public ProstorijeServis()
        {
            ProstorijeRepozitorijumRef = Repozitorijum.ProstorijeRepozitorijum.GetInstance;
        }

        

        public Model.Prostorija DodajProstoriju(Model.Prostorija novaProstorija)
        {
            // TODO: implement
            return null;
        }

        public Model.Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina)
        {
            Prostorija novaProstorija = new Prostorija(null, -2, tipProstorije, broj, sprat, povrsina, 0, 0, new Inventar());
            return ProstorijeRepozitorijumRef.DodajProstoriju(novaProstorija);
            
        }

        public Model.Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina, int brojKreveta, int brojSlobodnihKreveta)
        {
            // ovde bi bilo dobro napraviti poziv nekog servisa za pravljenje inventara da nam lepo dobavi ID inventara a ne da saljem praznu listu
            Prostorija novaProstorija = new Prostorija(null, -2, tipProstorije, broj, sprat, povrsina, brojKreveta, brojSlobodnihKreveta, new Inventar());
            return Repozitorijum.ProstorijeRepozitorijum.GetInstance.DodajProstoriju(novaProstorija);
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