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

namespace Repozitorijum
{
    public class ProstorijeRepozitorijum
    {
        private const string imeFajla = "prostorije.json";

        public List<Prostorija> lProstorije;

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
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                if (lProstorije == null)    // dal je ovo potrebno ?
                {

                    List<Prostorija> p = JsonSerializer.Deserialize<List<Prostorija>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lProstorije = p;

                }
            }
            catch (Exception e)
            {

                lProstorije = new List<Prostorija>();
                Console.WriteLine(e.ToString());
            }
        }

        private void SacuvajPodatke()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lProstorije, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
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
            //generisati novi id?
            int firstFitID = GetFirstFitID();
            novaProstorija.Id = firstFitID;
            lProstorije.Add(novaProstorija);
            SacuvajPodatke();
            return novaProstorija;
        }




        public Prostorija ObrisiProstoriju(Prostorija prostorija)
        {
            Prostorija retVal = null;
            foreach(Prostorija p in lProstorije)
            {
                if(p.Id == prostorija.Id)
                {
                    lProstorije.Remove(p);
                    retVal = p;
                    break;
                }
            }

            SacuvajPodatke();

            return retVal;
        }

        public Prostorija ObrisiProstorijuByID(int id)
        {
            Prostorija retVal = null;
            foreach (Prostorija p in lProstorije)
            {
                if (p.Id == id)
                {
                    lProstorije.Remove(p);
                    retVal = p;
                    break;
                }
            }

            SacuvajPodatke();

            return retVal;
        }


        public Prostorija AzurirajProstoriju(Prostorija editProstorija)
        {
            SacuvajPodatke();
            return editProstorija;
        }

      
        public Prostorija GetProstorijaById(int id)
        {
            foreach (Prostorija p in lProstorije)
            {
                if (p.Id == id)
                {
                    return p;
                }
            }

            return null;
        }

      

        public List<Prostorija> GetProstorijeAll()
        {
            UcitajPodatke();
            return lProstorije;
        }




    }
}