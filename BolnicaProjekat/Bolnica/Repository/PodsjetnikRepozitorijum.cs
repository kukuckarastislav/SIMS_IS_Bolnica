using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    public class PodsjetnikRepozitorijum
    {
        private const string imeFajla = "podsjetnik.json";
        private static PodsjetnikRepozitorijum instance = null;
        public static PodsjetnikRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PodsjetnikRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public PodsjetnikRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Podsjetnik> ocene;


        private void loadData()
        {
            try
            {
                if (ocene == null)
                {

                    ObservableCollection<Podsjetnik> p = JsonSerializer.Deserialize<ObservableCollection<Podsjetnik>>(File.ReadAllText("../../podaci/" + imeFajla));
                    ocene = p;
                }
            }
            catch (Exception e)
            {
                ocene = new ObservableCollection<Podsjetnik>();
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
        public Podsjetnik DodajPodsjetnik(Podsjetnik ocena)
        {
            loadData();

            if (!this.ocene.Contains(ocena))
                this.ocene.Add(ocena);

            SaveData();
            return ocena;
        }


        public ObservableCollection<Podsjetnik> GetAll()
        {
            loadData();
            return ocene;
        }

        public ObservableCollection<Podsjetnik> GetPodsjetnikByPatientId(int id)
        {
            loadData();
            ObservableCollection<Podsjetnik> ret = new ObservableCollection<Podsjetnik>();
            foreach (Podsjetnik z in ocene)
            {
                if (z.IdPacijenta == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }

        public Podsjetnik AzurirajPodsjetnik(Podsjetnik p)
        {
            loadData();
            SaveData();
            return p;
        }
    }

}