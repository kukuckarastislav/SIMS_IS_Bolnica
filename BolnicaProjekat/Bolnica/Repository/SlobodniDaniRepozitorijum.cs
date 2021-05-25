using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Repository
{
    class SlobodniDaniRepozitorijum
    {
        private const string imeFajla = "slobodnidani.json";
        private static SlobodniDaniRepozitorijum instance = null;
        public static SlobodniDaniRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SlobodniDaniRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public void DodajDanLekaru(int idLekara, DateTime dan)
        {
            foreach(SlobodniDani dani in slobodniDani)
            {
                if(dani.LekarId == idLekara)
                {
                    if (!DaLiVecImaSlobodanDan(dani.Dani, dan))
                        dani.Dani.Add(dan);
                    break;
                }
            }
            SaveData();
        }

        private bool DaLiVecImaSlobodanDan(List<DateTime> slobodniDani, DateTime danProvere)
        {
            foreach(DateTime dan in slobodniDani)
            {
                if (dan.Date.Equals(danProvere.Date))
                    return true;
            }

            return false;
        }

        public SlobodniDaniRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<SlobodniDani> slobodniDani;


        private void loadData()
        {
            try
            {
                if (slobodniDani == null)
                {

                    ObservableCollection<SlobodniDani> d = JsonSerializer.Deserialize<ObservableCollection<SlobodniDani>>(File.ReadAllText("../../podaci/" + imeFajla));
                    slobodniDani = d;
                }
            }
            catch (Exception e)
            {
                slobodniDani = new ObservableCollection<SlobodniDani>();
                Console.WriteLine(e.ToString());
            }
        }


        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(slobodniDani, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public SlobodniDani DodajOdmor(SlobodniDani dani)
        {

            if (!this.slobodniDani.Contains(dani))
                this.slobodniDani.Add(dani);

            SaveData();
            return dani;
        }
        public int GetNewId()
        {
            int newId = 1;
            if (slobodniDani.Count == 0)
                return newId;
            return slobodniDani.ElementAt(slobodniDani.Count - 1).Id + 1;
        }


        public ObservableCollection<SlobodniDani> GetAll()
        {
            loadData();
            return slobodniDani;
        }

        public void ObrisiSlobodanDan(int idLekara, DateTime dan)
        {
            foreach (SlobodniDani dani in slobodniDani)
            {
                if (dani.LekarId == idLekara)
                {
                    ObrisiSlobodanDan(dani.Dani, dan);
                }
            }
        }

        private void ObrisiSlobodanDan(List<DateTime> slobodniDani, DateTime danProvere)
        {
            foreach (DateTime dan in slobodniDani)
            {
                if (dan.Date.Equals(danProvere.Date))
                {
                    slobodniDani.Remove(danProvere);
                    SaveData();
                    break;
                }
            }

        }
    }
}
