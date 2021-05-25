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
using System.Linq;
using DTO;

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

        public List<Model.Lekar> Lekari { get; set; }


        private void loadData()
        {
            try
            {
                if (Lekari == null)
                {

                    List<Model.Lekar> p = JsonSerializer.Deserialize<List<Model.Lekar>>(File.ReadAllText("../../podaci/" + imeFajla));
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
        public bool ProveriPostojanjeLekara(string korisnickoIme)
        {
            foreach (Lekar lekar in Lekari)
            {
                if (lekar.KorisnickoIme.Equals(korisnickoIme)) return true;
            }
            return false;
        }

        public Lekar GetByImeLozinka(string korisnickoIme, string lozinka)
        {
            foreach (Lekar lekar in Lekari)
            {
                if (lekar.KorisnickoIme.Equals(korisnickoIme) && lekar.Sifra.Equals(lozinka))
                    return lekar;
            }
            return null;
        }

        public void AzurirajLekara(LekarDTO dto)
        {
            foreach (Lekar lekar in Lekari)
            {
                if (lekar.Id == dto.Id)
                {
                    lekar.Ime = dto.Ime;
                    lekar.Prezime = dto.Prezime;
                    lekar.Telefon = dto.Telefon;
                    lekar.AdresaStanovanja = dto.AdresaStanovanja;
                    lekar.Email = dto.Email;
                    lekar.Drzavljanstvo = dto.Drzavljanstvo;
                    lekar.DatumRodjenja = dto.DatumRodjenja;
                    break;
                }
            }
            SaveData();
        }
      
        public void ObrisiLekara(LekarDTO dto)
        {
            foreach(Lekar lekar in Lekari)
            {
                if(lekar.Id == dto.Id)
                {
                    lekar.LogickiObrisan = true;
                    break;
                }
            }
            SaveData();
        }
      
      public List<Lekar> GetAll()
      {
         return Lekari;
      }

        public ObservableCollection<Model.Lekar> GetAllObs()
        {
            ObservableCollection<Lekar> obsLekari = new ObservableCollection<Lekar>();
            foreach(Lekar lekar in Lekari)
            {
                obsLekari.Add(lekar);
            }
            return obsLekari;
        }

        public Model.Lekar GetById(long id)
        {
            loadData();
            foreach (Lekar l in Lekari)
            {
                if (l.Id == id)
                    return l;
            }
            return null;
        }

        public int GetNewId()
        {
            int newId = 1;
            if (Lekari.Count == 0)
                return newId;
            return Lekari.ElementAt(Lekari.Count - 1).Id + 1;
        }

        public RadnoVreme getRadnoVremeLekara(int id)
        {
            foreach(Lekar lekar in Lekari)
            {
                if(lekar.Id == id)
                {
                    return lekar.radnoVreme;
                }
            }

            return null;
        }

        public void IzmeniRadnoVremeLekara(int id, RadnoVreme vreme)
        {
            foreach (Lekar lekar in Lekari)
            {
                if (lekar.Id == id)
                {
                    lekar.radnoVreme = vreme;
                    break;
                }
            }
        }
    }

}