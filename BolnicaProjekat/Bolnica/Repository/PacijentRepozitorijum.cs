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
using System.Linq;
using Model;
using DTO;

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

        public bool ProveriPostojanjePacijenta(string korisnickoIme)
        {
            foreach (Pacijent pacijent in pacijenti)
            {
                if (pacijent.KorisnickoIme.Equals(korisnickoIme)) return true;
            }

            return false;
        }

        public Pacijent GetByImeLozinka(string korisnickoIme, string lozinka)
        {
            foreach (Pacijent pacijent in pacijenti)
            {
                if (pacijent.KorisnickoIme.Equals(korisnickoIme) && pacijent.Sifra.Equals(lozinka))
                    return pacijent;
            }
            return null;
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
        public int GetNewId()
        {
            int newId = 1;
            if (pacijenti.Count == 0)
                return newId;
            return pacijenti.ElementAt(pacijenti.Count - 1).Id + 1;
        }

        public Model.Pacijent AzurirajPacijenta(Model.Pacijent pacijent)
        {
            SaveData();
            return pacijent;
        }
      
        //logicko brisanje
        public void ObrisiPacijenta(PacijentDTO pacijentZaBrisanje)
        {
            foreach (Pacijent pacijent in pacijenti)
            {
                if (pacijent.Jmbg.Equals(pacijentZaBrisanje.Jmbg))
                {
                    pacijent.LogickiObrisan = true;
                }
            }
            SaveData();
        }
      
      public ObservableCollection<Model.Pacijent> GetAll()
      {
         loadData();
         return pacijenti;
      }
        public ObservableCollection<Pacijent> GetNeobrisaniPacijenti()
        {
            ObservableCollection<Pacijent> neobrisaniPacijenti = new ObservableCollection<Pacijent>();
            foreach (Pacijent pacijent in pacijenti)
            {
                if (!pacijent.LogickiObrisan) neobrisaniPacijenti.Add(pacijent);
            }

            return neobrisaniPacijenti;
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

        public List<string> GetAlergeniPacijenta(int id)
        {
            foreach (Pacijent p in pacijenti)
            {
                if (p.Id == id)
                    return p.MedicinskiKarton.Alergeni;
            }

            return null;
        }

        public void DodajAlergen(int idPacijenta, string alergen)
        {
            foreach (Pacijent p in pacijenti)
            {
                if (p.Id == idPacijenta)
                {
                    if (DaLiImaAlergen(p.MedicinskiKarton.Alergeni, alergen) == false)
                    {
                        p.MedicinskiKarton.Alergeni.Add(alergen);
                        SaveData();
                        return;
                    }
                }
            }
        }

        public void ObrisiAlergen(int idPacijenta, string alergen)
        {
            foreach (Pacijent p in pacijenti)
            {
                if (p.Id == idPacijenta)
                {
                    if (DaLiImaAlergen(p.MedicinskiKarton.Alergeni, alergen) == true)
                    {
                        p.MedicinskiKarton.Alergeni.Remove(alergen);
                        SaveData();
                        return;
                    }
                }
            }
        }

        public bool DaLiImaAlergen(List<string> alergeni, string alergen)
        {
            foreach(string a in alergeni)
            {
                if (a.Equals(alergen)) return true;
            }

            return false;
        }

        public bool JelPostojiKorisnickoIme(string korisnickoIme)
        {
            foreach (Pacijent p in pacijenti)
            {
                if (p.KorisnickoIme.Equals(korisnickoIme))
                {
                    return true;
                }
            }
            return false;
        }


    }
}