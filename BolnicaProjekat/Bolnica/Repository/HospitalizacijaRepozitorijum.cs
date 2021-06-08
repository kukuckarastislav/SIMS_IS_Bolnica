using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repozitorijum
{
    class HospitalizacijaRepozitorijum
    {



        private const string imeFajla = "hospitalizacija.json";
        private static HospitalizacijaRepozitorijum instance = null;
        public ObservableCollection<Hospitalizacija> hospitalizacije;

        public static HospitalizacijaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HospitalizacijaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public HospitalizacijaRepozitorijum()
        {
            LoadData();
        }



        private void LoadData()
        {
            try
            {
                if (hospitalizacije == null)
                {

                    ObservableCollection<Hospitalizacija> h = JsonSerializer.Deserialize<ObservableCollection<Hospitalizacija>>(File.ReadAllText("../../podaci/" + imeFajla));
                    hospitalizacije = h;
                }
            }
            catch (Exception e)
            {
                hospitalizacije = new ObservableCollection<Hospitalizacija>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(hospitalizacije, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }

        public Hospitalizacija DodajHospitalizaciju(Hospitalizacija hospitalizacija)
        {
            LoadData();

            if (!this.hospitalizacije.Contains(hospitalizacija))
                this.hospitalizacije.Add(hospitalizacija);

            SaveData();
            return hospitalizacija;
        }

        public Hospitalizacija ObrisiHospitalizaciju(Hospitalizacija hospitalizacija)
        {
            int i = 0;
            foreach (Hospitalizacija h in hospitalizacije)
            {
                if (h.Id == hospitalizacija.Id)
                {
                    hospitalizacije.RemoveAt(i);
                    break;
                }
                i++;
            }
            SaveData();
            return hospitalizacija;
        }

        public ObservableCollection<Hospitalizacija> GetAll()
        {
            LoadData();
            return hospitalizacije;
        }

        public Hospitalizacija GetHospitalizacijaById(int id)
        {
            LoadData();
            foreach (Hospitalizacija h in hospitalizacije)
            {
                if (h.Id == id)
                {
                    return h;
                }
            }
            return null;
        }

        public List<Hospitalizacija> GetHospitalizacijeByPatientId(int id)
        {
            LoadData();
            List<Hospitalizacija> ret = new List<Hospitalizacija>();
            foreach (Hospitalizacija h in hospitalizacije)
            {
                if (h.IdPacijenta == id)
                {
                    ret.Add(h);
                }
            }
            return ret;
        }

        public int GetFirstFitID()
        {
            LoadData();
            int najveciID = 0;
            foreach (Hospitalizacija hospitalizacija in hospitalizacije)
            {
                if (hospitalizacija.Id > najveciID)
                {
                    najveciID = hospitalizacija.Id;
                }
            }
            return najveciID + 1;
        }


    }



}

