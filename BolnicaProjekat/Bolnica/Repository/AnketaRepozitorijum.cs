using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ObservableCollection<Model.Ocena> ocene;


        private void loadData()
        {
            try
            {
                if (ocene == null)
                {

                    ObservableCollection<Model.Ocena> p = JsonSerializer.Deserialize<ObservableCollection<Model.Ocena>>(File.ReadAllText("../../podaci/" + imeFajla));
                    ocene = p;
                }
            }
            catch (Exception e)
            {
                ocene = new ObservableCollection<Model.Ocena>();
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
        public Model.Ocena DodajOcenu(Model.Ocena ocena)
        {
            loadData();

            if (!this.ocene.Contains(ocena))
                this.ocene.Add(ocena);

            SaveData();
            return ocena;
        }


        public ObservableCollection<Model.Ocena> GetAll()
        {
            loadData();
            return ocene;
        }

        public ObservableCollection<Model.Ocena> GetOceneByPatientId(int id)
        {
            loadData();
            ObservableCollection<Model.Ocena> ret = new ObservableCollection<Model.Ocena>();
            foreach (Ocena z in ocene)
            {
                if (z.IdPacijenta == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }

        public ObservableCollection<Model.Ocena> GetOceneByLekarId(int id)
        {
            loadData();
            ObservableCollection<Model.Ocena> ret = new ObservableCollection<Model.Ocena>();
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