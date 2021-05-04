using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Model;
using System.Collections.ObjectModel;

namespace Repozitorijum
{
    public class ReceptRepozitorijum
    {
        private const string imeFajla = "recepti.json";
        private static ReceptRepozitorijum instance = null;

        public static ReceptRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReceptRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public ReceptRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Recept> recepti;

        private void loadData()
        {
            try
            {
                if (recepti == null)
                {

                    ObservableCollection<Recept> p = JsonSerializer.Deserialize<ObservableCollection<Recept>>(File.ReadAllText("../../podaci/" + imeFajla));
                    recepti = p;
                }
            }
            catch (Exception e)
            {
                recepti = new ObservableCollection<Recept>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(recepti, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }

        public Recept DodajRecept(Recept recept)
        {
            loadData();

            if (!this.recepti.Contains(recept))
                this.recepti.Add(recept);

            SaveData();
            return recept;
        }

        public Recept ObrisiRecept(Recept recept)
        {
            int i = 0;
            foreach (Recept r in recepti)
            {
                if (r.Id == recept.Id)
                {
                    recepti.RemoveAt(i);
                    break;
                }
                i++;
            }
            SaveData();
            return recept;
        }

        public ObservableCollection<Recept> GetAll()
        {
            loadData();
            return recepti;
        }

        public Recept GetReceptById(int id)
        {
            loadData();
            foreach (Recept r in recepti)
            {
                if (r.Id == id)
                {
                    return r;
                }
            }
            return null;
        }


    }
}
