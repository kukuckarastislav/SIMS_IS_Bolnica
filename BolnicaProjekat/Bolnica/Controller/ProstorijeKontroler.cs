/***********************************************************************
 * Module:  ProstorijeKontroler.cs
 * Author:  lacik
 * Purpose: Definition of the Class Kontroler.ProstorijeKontroler
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Model;
using Servis;
using DTO;

namespace Kontroler
{
    public class ProstorijeKontroler
    {

        private Servis.ProstorijeServis ProstorijeServisObjekat { get; set; }

        public ProstorijeKontroler()
        {
            ProstorijeServisObjekat = new ProstorijeServis();
        }

        public Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina)
        {
            return ProstorijeServisObjekat.DodajProstoriju(tipProstorije, broj, sprat, povrsina);
        }
        public Prostorija DodajProstoriju(TipProstorije tipProstorije, string broj, int sprat, double povrsina, int brKreveta, int brSlobKreveta)
        {
            return ProstorijeServisObjekat.DodajProstoriju(tipProstorije, broj, sprat, povrsina, brKreveta, brSlobKreveta);
        }

        public Prostorija ObrisiProstoriju(Prostorija delProstorija)
        {
            return ProstorijeServisObjekat.ObrisiProstoriju(delProstorija);
        }

        public Prostorija AzurirajProstoriju(Prostorija editProstorija,
                                             string broj,
                                             int sprat,
                                             double povrsina)
        {
            return ProstorijeServisObjekat.AzurirajProstoriju(editProstorija,
                                                              broj,
                                                              sprat,
                                                              povrsina);
        }

        public Prostorija AzurirajProstoriju(Prostorija editProstorija,
                                             string broj,
                                             int sprat,
                                             double povrsina,
                                             int brKreveta,
                                             int brSlobodnihKreveta)
        {
            return ProstorijeServisObjekat.AzurirajProstoriju(editProstorija,
                                                  broj,
                                                  sprat,
                                                  povrsina,
                                                  brKreveta,
                                                  brSlobodnihKreveta);
        }



        public Prostorija GetProstorijaById(int id)
        {
            return ProstorijeServisObjekat.GetProstorijaById(id);
        }

        public List<ProstorijaDTO> GetProstorijeDTO()
        {
            return ProstorijeServisObjekat.GetProstorijeDTO();
        }

        public ObservableCollection<Prostorija> getProstorijeTipObservable(TipProstorije tipProstorije)
        {
            ObservableCollection<Prostorija> prostorijeTipa = new ObservableCollection<Prostorija>();
            foreach(Prostorija prostorija in ProstorijeServisObjekat.getProstorijeTip(tipProstorije))
            {
                prostorijeTipa.Add(prostorija);
            }
            return prostorijeTipa;
        }
    }
}