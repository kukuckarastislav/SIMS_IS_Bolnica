/***********************************************************************PacijentRepozitorijum
 * Module:  LekarRepozitorijum.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Repozitorijum.LekarRepozitorijum
 ***********************************************************************/

using System;
using System.Collections.Generic;
using Model;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System.IO;

namespace Repozitorijum
{
   public class LekarRepozitorijum
   {
        private const string imeFajla = "lekari.json";
        private static LekarRepozitorijum instance = null;
        public static LekarRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LekarRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public LekarRepozitorijum()
        {
            loadData();
            //Lekari = new ObservableCollection<Model.Lekar>();
        }

        public ObservableCollection<Model.Lekar> Lekari { get; set; }


        private void loadData()
        {
            try
            {
                if (Lekari == null)
                {

                    ObservableCollection<Model.Lekar> p = JsonSerializer.Deserialize<ObservableCollection<Model.Lekar>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Lekari = p;
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
            string json = JsonSerializer.Serialize(Lekari, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }


        public Model.Lekar DodajLekara(Lekar lekar)
        {
            //loadData();

            if (!this.Lekari.Contains(lekar))
                this.Lekari.Add(lekar);

            SaveData();
            return lekar;
        }

        public Model.Lekar AzurirajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Lekar ObrisiLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
      }
      
      public List<Lekar> GetAll()
      {
         return null;
      }

        public ObservableCollection<Model.Lekar> GetAllObs()
        {
            return Lekari;
        }

        public Model.Lekar GetById(long id)
      {
         foreach(Lekar l in Lekari)
            {
                if (l.Id == id)
                    return l;
            }
         return null;
      }
   
      private string PutanjaFajla;
   
   }
}