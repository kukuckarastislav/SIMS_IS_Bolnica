using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    public class LekoviRepozitorijum
    {
        private const string imeFajla = "lekovi.json";
        private static LekoviRepozitorijum instance = null;
        public static LekoviRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LekoviRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public LekoviRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Lek> lekovi;


        private void loadData()
        {
            try
            {
                if (lekovi == null)
                {

                    ObservableCollection<Lek> p = JsonSerializer.Deserialize<ObservableCollection<Lek>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lekovi = p;
                }
            }
            catch (Exception e)
            {
                lekovi = new ObservableCollection<Lek>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lekovi, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Lek DodajLek(Lek lek)
        {
            loadData();

            if (!this.lekovi.Contains(lek))
                this.lekovi.Add(lek);

            SaveData();
            return lek;
        }

        public Lek AzurirajLek(Lek lek)
        {
            SaveData();
            return lek;
        }

        public Lek ObrisiLek(Lek lek)
        {
            int i = 0;
            foreach (Lek z in lekovi)
            {
                if (z.Id == lek.Id)
                {
                    lekovi.RemoveAt(i);
                    break;
                }
                i++;
            }
            SaveData();
            return lek;
        }


        public ObservableCollection<Lek> GetAll()
        {
            loadData();
            return lekovi;
        }

        public Lek GetLekById(int id)
        {
            loadData();
            foreach (Lek z in lekovi)
            {
                if (z.Id == id)
                {
                    return z;
                }
            }
            return null;
        }
    }

}

