/***********************************************************************
 * Module:  SekretarRepozitorijum.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Repozitorijum.SekretarRepozitorijum
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
   public class SekretarRepozitorijum
   {
        private const string imeFajla = "sekretari.json";
        private static SekretarRepozitorijum instance = null;

        public static SekretarRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SekretarRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public SekretarRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Sekretar> Sekretari { get; set; }


        private void loadData()
        {
            try
            {
                if (Sekretari == null)
                {

                    ObservableCollection<Sekretar> s = JsonSerializer.Deserialize<ObservableCollection<Sekretar>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Sekretari = s;
                }
            }
            catch (Exception e)
            {
                Sekretari = new ObservableCollection<Sekretar>();
                Console.WriteLine(e.ToString());
            }
        }

        public bool ProveriPostojanjeSekretara(string korisnickoIme)
        {
            foreach(Sekretar sekretar in Sekretari)
            {
                if (sekretar.KorisnickoIme.Equals(korisnickoIme)) return true;
            }

            return false;
        }

        public Sekretar GetByImeLozinka(string korisnickoIme, string lozinka)
        {
            foreach (Sekretar sekretar in Sekretari)
            {
                if (sekretar.KorisnickoIme.Equals(korisnickoIme) && sekretar.Sifra.Equals(lozinka))
                    return sekretar;
            }
            return null;
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Sekretari, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Model.Sekretar DodajSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar AzurirajSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar ObrisiSekretara(Model.Sekretar sekretar)
      {
         // TODO: implement
         return null;
      }
      
      public List<Sekretar> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Model.Sekretar GetById(long id)
      {
         // TODO: implement
         return null;
      }
   
      private string PutanjaFajla;
   
   }
}