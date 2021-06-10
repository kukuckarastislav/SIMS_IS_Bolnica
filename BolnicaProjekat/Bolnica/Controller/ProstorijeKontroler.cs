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

        public Prostorija DodajProstoriju(ProstorijaDTO prostorijaDTO)
        {
            return ProstorijeServisObjekat.DodajProstoriju(prostorijaDTO);
        }

        public Prostorija ObrisiProstoriju(Prostorija delProstorija)
        {
            return ProstorijeServisObjekat.ObrisiProstoriju(delProstorija);
        }

        public Prostorija AzurirajProstoriju(ProstorijaDTO editProstorijaDTO)
        {
            return ProstorijeServisObjekat.AzurirajProstoriju(editProstorijaDTO);
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