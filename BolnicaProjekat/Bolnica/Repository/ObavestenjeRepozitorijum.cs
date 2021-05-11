using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository
{
    class ObavestenjeRepozitorijum
    {

        private const string imeFajla = "obavestenja.json";
        private static ObavestenjeRepozitorijum instance = null;
        public static ObavestenjeRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ObavestenjeRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public ObavestenjeRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Obavestenje> Obavestenja { get; set; }


        private void loadData()
        {
            try
            {
                if (Obavestenja == null)
                {

                    ObservableCollection<Obavestenje> o = JsonSerializer.Deserialize<ObservableCollection<Obavestenje>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Obavestenja = o;
                }
            }
            catch (Exception e)
            {
                Obavestenja = new ObservableCollection<Obavestenje>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Obavestenja, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Obavestenje DodajObavestenje(Obavestenje obavestenje)
        {
            loadData();

            if (!this.Obavestenja.Contains(obavestenje))
                this.Obavestenja.Add(obavestenje);

            SaveData();
            return obavestenje;
        }

        public void ObrisiObavestenje(int id)
        {
            loadData();

            foreach(Obavestenje obavestenje in Obavestenja)
            {
                if(obavestenje.Id == id)
                {
                    Obavestenja.Remove(obavestenje);
                    break;
                }
            }

            SaveData();

        }

        public ObservableCollection<Obavestenje> GetAll()
        {
            loadData();
            return Obavestenja;
        }

        public int GetNewId()
        {
            int id = 1;
            loadData();
            int brUsluga = Obavestenja.Count;
            if (brUsluga == 0)
                return id;

            return Obavestenja.ElementAt(brUsluga - 1).Id + 1;
        }

    }
}
