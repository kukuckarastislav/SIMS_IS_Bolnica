using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    public class AnketaRepozitorijum
    {
        private const string imeFajla = "anketa.json";
        private static AnketaRepozitorijum instance = null;
        public static AnketaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AnketaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public AnketaRepozitorijum()
        {
            loadData();
        }

        public List<Ocena> ocene;


        private void loadData()
        {
            try
            {
                if (ocene == null)
                {

                    List<Ocena> p = JsonSerializer.Deserialize<List<Ocena>>(File.ReadAllText("../../podaci/" + imeFajla));
                    ocene = p;
                }
            }
            catch (Exception e)
            {
                ocene = new List<Ocena>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(ocene, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Ocena DodajOcenu(Model.Ocena ocena)
        {
            loadData();

            if (!this.ocene.Contains(ocena))
                this.ocene.Add(ocena);

            SaveData();
            return ocena;
        }


        public List<Ocena> GetAll()
        {
            loadData();
            return ocene;
        }

        public List<Ocena> GetOceneByPatientId(int id)
        {
            loadData();
            List<Ocena> ret = new List<Ocena>();
            foreach (Ocena z in ocene)
            {
                if (z.IdPacijenta == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }

        public List<Ocena> GetOceneByLekarId(int id)
        {
            loadData();
            List<Model.Ocena> ret = new List<Ocena>();
            foreach (Ocena z in ocene)
            {
                if (z.IdLekara == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }
    }

}