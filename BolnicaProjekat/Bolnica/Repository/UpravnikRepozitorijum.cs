/***********************************************************************
 * Module:  UpravnikRepozitorijum.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Repozitorijum.UpravnikRepozitorijum
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
   public class UpravnikRepozitorijum
   {
        private const string imeFajla = "upravnici.json";
        private static UpravnikRepozitorijum instance = null;

        public static UpravnikRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UpravnikRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public UpravnikRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Upravnik> Upravnici { get; set; }


        private void loadData()
        {
            try
            {
                if (Upravnici == null)
                {

                    ObservableCollection<Upravnik> u = JsonSerializer.Deserialize<ObservableCollection<Upravnik>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Upravnici = u;
                }
            }
            catch (Exception e)
            {
                Upravnici = new ObservableCollection<Upravnik>();
                Console.WriteLine(e.ToString());
            }
        }

        public bool ProveriPostojanjeUpravnika(string korisnickoIme)
        {
            foreach (Upravnik upravnik in Upravnici)
            {
                if (upravnik.KorisnickoIme.Equals(korisnickoIme)) return true;
            }

            return false;
        }

        public Upravnik GetByImeLozinka(string korisnickoIme, string lozinka)
        {
            foreach (Upravnik upravnik in Upravnici)
            {
                if (upravnik.KorisnickoIme.Equals(korisnickoIme) && upravnik.Sifra.Equals(lozinka))
                    return upravnik;
            }
            return null;
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Upravnici, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Upravnik DodajPacijenta(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik AzurirajUpravnika(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik ObrisiUpravnika(Upravnik upravnik)
      {
         // TODO: implement
         return null;
      }
      
      public List<Upravnik> GetAll()
      {
         // TODO: implement
         return null;
      }
      
      public Upravnik GetById(long id)
      {
         // TODO: implement
         return null;
      }
   
      private string PutanjaFajla;
   
   }
}