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

        public Prostorija AzurirajProstoriju()
        {
            // TODO: implement
            return null;
        }

        public Prostorija AzurirajProstoriju(Prostorija editProstorija,
                                             string broj,
                                             int sprat,
                                             double povrsina)
        {
            // TODO: implement
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


        public List<Prostorija> GetProstorijeAll()
        {
            // TODO: implement
            return null;
        }

        public List<ProstorijaDTO> GetProstorijeDTO()
        {
            return ProstorijeServisObjekat.GetProstorijeDTO();
        }

        public ObservableCollection<Prostorija> getProstorijeTipObservable(TipProstorije tipProstorije)
        {
            return ProstorijeServisObjekat.getProstorijeTipObservable(tipProstorije);
        }
        public ObservableCollection<Prostorija> getBolesnickeSobeZaHospitalizaciju()
        {
            //TODO: ovo resiti?
            return new ObservableCollection<Prostorija>();
            //return ProstorijeServisObjekat.getBolesnickeSobeZaHospitalizaciju();
        }

    }
}