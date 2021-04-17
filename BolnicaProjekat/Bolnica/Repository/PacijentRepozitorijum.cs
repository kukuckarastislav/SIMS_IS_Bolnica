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
                Console.WriteLine(e.ToString());
            }
        }

        private void SaveData()
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
      
      public Model.Pacijent ObrisiPacijenta(Model.Pacijent pacijent)
      {
         // TODO: implement
         return null;
      }
      
      public ObservableCollection<Model.Pacijent> GetAll()
      {
         loadData();
         return pacijenti;
      }
      
      public Model.Pacijent GetById(long id)
      {
         // TODO: implement
         return null;
      }
  
   
   }
}