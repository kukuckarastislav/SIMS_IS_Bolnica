/***********************************************************************
 * Module:  ProstorijeRepozitorijum.cs
 * Author:  lacik
 * Purpose: Definition of the Class Repozitorijum.ProstorijeRepozitorijum
 ***********************************************************************/

using System;
using System.IO;
using System.Collections.Generic;
using Model;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Windows;
using Interface;
using Factory;

namespace Repozitorijum
{
    public class ProstorijeRepozitorijum
    {
        public IBaza Baza { get; set; }
        private List<Prostorija> lProstorije;
        private static ProstorijeRepozitorijum instance = null;
        public static ProstorijeRepozitorijum GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ProstorijeRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private ProstorijeRepozitorijum()
        {
            Baza = BazaFactory.GetBaza("Default");
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            if(lProstorije == null)
            {
                lProstorije = Baza.UcitajPodatke();
            }
        }

        private void SacuvajPodatke()
        {
            Baza.SacuvajPodatke(lProstorije);
        }
        
        public int GetFirstFitID()
        {
            UcitajPodatke();
            int najveciID = 0;
            foreach (Prostorija p in lProstorije)
            {
                if (p.Id > najveciID)
                {
                    najveciID = p.Id;
                }
            }
            return najveciID + 1;
        }

        public Prostorija DodajProstoriju(Prostorija novaProstorija)
        {
            UcitajPodatke();
            novaProstorija.Id = GetFirstFitID();
            lProstorije.Add(novaProstorija);
            SacuvajPodatke();
            return novaProstorija;
        }

        public Prostorija ObrisiProstoriju(Prostorija prostorija)
        {
            Prostorija staraProstorija = null;
            foreach(Prostorija p in lProstorije)
            {
                if(p.Id == prostorija.Id)
                {
                    lProstorije.Remove(p);
                    staraProstorija = p;
                    break;
                }
            }
            SacuvajPodatke();
            return staraProstorija;
        }

        public Prostorija ObrisiProstorijuByID(int idProstorije)
        {
            Prostorija staraProstorija = null;
            foreach (Prostorija p in lProstorije)
            {
                if (p.Id == idProstorije)
                {
                    lProstorije.Remove(p);
                    staraProstorija = p;
                    break;
                }
            }
            SacuvajPodatke();
            return staraProstorija;
        }

        public Prostorija AzurirajProstoriju(Prostorija editProstorija)
        {
            SacuvajPodatke();
            return editProstorija;
        }
      
        public Prostorija GetProstorijaById(int id)
        {
            Prostorija prostorija = null;
            foreach (Prostorija p in lProstorije)
            {
                if (p.Id == id)
                {
                    prostorija = p;
                    break;
                }
            }
            return prostorija;
        }

        public List<Prostorija> GetProstorijeAll()
        {
            UcitajPodatke();
            return lProstorije;
        }
    }
}