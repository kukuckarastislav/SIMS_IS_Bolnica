/***********************************************************************
 * Module:  PacijentRepozitorijum.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Repozitorijum.PacijentRepozitorijum
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
   public class PacijentRepozitorijum
   {
        private const string imeFajla = "pacijenti.json";
        private static PacijentRepozitorijum instance = null;
        public static PacijentRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PacijentRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public PacijentRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Model.Pacijent> pacijenti;


        private void loadData()
        {
            try
            {
                if (pacijenti == null)
                {
                    
                    ObservableCollection<Model.Pacijent> p = JsonSerializer.Deserialize<ObservableCollection<Model.Pacijent>>(File.ReadAllText("../../podaci/"+imeFajla));
                    pacijenti = p;
                }
            }
            catch (Exception e)
            {
                pacijenti = new ObservableCollection<Model.Pacijent>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(pacijenti, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Model.Pacijent DodajPacijenta(Model.Pacijent pacijent)
       {
            loadData();
            
            if (!this.pacijenti.Contains(pacijent))
                this.pacijenti.Add(pacijent);

            SaveData();
            return pacijent;
        }


      
      public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
        //logicko brisanje
        public Model.Pacijent ObrisiPacijenta(Model.Pacijent pacijent)
        {
            foreach (Pacijent p in pacijenti)
            {
                if (p.Jmbg.Equals(pacijent.Jmbg))
                {
                    p.LogickiObrisan = true;
                }
            }
            SaveData();
            return pacijent;
        }
      
      public ObservableCollection<Model.Pacijent> GetAll()
      {
         loadData();
         return pacijenti;
      }
      
      public Model.Pacijent GetById(int id)
      {
         foreach(Pacijent p in pacijenti)
            {
                if (p.Id == id)
                    return p;
            }        
         return null;
      }
  
   
   }
}