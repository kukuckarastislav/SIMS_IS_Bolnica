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
        }

        public ObservableCollection<Model.Lekar> lekari;


        private void loadData()
        {
            try
            {
                if (lekari == null)
                {

                    ObservableCollection<Model.Lekar> p = JsonSerializer.Deserialize<ObservableCollection<Model.Lekar>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lekari = p;
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
            string json = JsonSerializer.Serialize(lekari, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }





        public Lekar DodajLekara(Model.Lekar lekar)
      {
         // TODO: implement
         return null;
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
         // TODO: implement
         return null;
      }
      
      public Model.Lekar GetById(long id)
      {
         // TODO: implement
         return null;
      }
   
      private string PutanjaFajla;
   
   }
}