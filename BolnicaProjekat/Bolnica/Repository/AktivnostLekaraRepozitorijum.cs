using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    class AktivnostLekaraRepozitorijum
    {
        private const string imeFajla = "aktivnostLekara.json";
        private static AktivnostLekaraRepozitorijum instance = null;
        public static AktivnostLekaraRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AktivnostLekaraRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public AktivnostLekaraRepozitorijum()
        {
            loadData();
        }

        public List<Model.Aktivnost> aktivnosti;


        private void loadData()
        {
            try
            {
                if (aktivnosti == null)
                {

                    List<Model.Aktivnost> p = JsonSerializer.Deserialize<List<Model.Aktivnost>>(File.ReadAllText("../../podaci/" + imeFajla));
                    aktivnosti = p;
                }
            }
            catch (Exception e)
            {
                aktivnosti = new List<Model.Aktivnost>();
                Console.WriteLine(e.ToString());
            }
        }


        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(aktivnosti, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Model.Aktivnost DodajAktivnost(Model.Aktivnost aktivnost)
        {
            loadData();

            if (!this.aktivnosti.Contains(aktivnost))
                this.aktivnosti.Add(aktivnost);

            SaveData();
            return aktivnost;
        }


        public List<Model.Aktivnost> GetAll()
        {
            loadData();
            return aktivnosti;
        }

        public List<Model.Aktivnost> GetDoctorActivityById(int id)
        {
            loadData();
            List<Model.Aktivnost> ret = new List<Model.Aktivnost>();
            foreach (Aktivnost z in aktivnosti)
            {
                if (z.IdPacijenta == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }
    }
}
