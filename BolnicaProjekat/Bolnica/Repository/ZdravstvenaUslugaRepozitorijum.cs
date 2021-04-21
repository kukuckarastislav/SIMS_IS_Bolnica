using System;
using System.Collections.Generic;
using Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using System.Linq;

namespace Repozitorijum
{
    public class ZdravstvenaUslugaRepozitorijum
    {

        private const string imeFajla = "zdravstveneUsluge.json";
        private static ZdravstvenaUslugaRepozitorijum instance = null;
        public static ZdravstvenaUslugaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ZdravstvenaUslugaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public ObservableCollection<ZdravstvenaUsluga> Usluge { get; set; }

        public ZdravstvenaUslugaRepozitorijum()
        {
           
            if (Usluge == null)
            {

                loadData();
            }
        }

        private void loadData()
        {
            try
            {
                if (Usluge == null)
                {

                    ObservableCollection<Model.ZdravstvenaUsluga> u = JsonSerializer.Deserialize<ObservableCollection<Model.ZdravstvenaUsluga>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Usluge = u;
                }
            }
            catch (Exception e)
            {
                Usluge = new ObservableCollection<Model.ZdravstvenaUsluga>();
                Console.WriteLine(e.ToString());
            }
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            loadData();

            if (!this.Usluge.Contains(usluga))
                this.Usluge.Add(usluga);

            SaveData();
            return usluga;
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Usluge, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }


        public List<ZdravstvenaUsluga> getTerminiBylekarId(int id)
        {
            loadData();
            List<ZdravstvenaUsluga> usluge = new List<ZdravstvenaUsluga>();
           
            foreach (ZdravstvenaUsluga u in Usluge)
            {
                if(u.IdLekara == id)
                {
                    usluge.Add(u);
                }

            }
            
            return usluge;
        }

        public List<ZdravstvenaUsluga> GetUslugeByProstorijaId(int id)
        {
            // metodu dodao rastislav, 20/4/2021 7:30
            loadData();
            List<ZdravstvenaUsluga> usluge = new List<ZdravstvenaUsluga>();

            foreach (ZdravstvenaUsluga u in Usluge)
            {
                if (u.IdProstorije == id)
                {
                    usluge.Add(u);
                }

            }

            return usluge;
        }

        public List<ZdravstvenaUsluga> getTerminiByLekarAndDatum(int id, DateTime datum)
        {
            loadData();
            List<ZdravstvenaUsluga> usluge = new List<ZdravstvenaUsluga>();

            foreach (ZdravstvenaUsluga u in Usluge)
            {
                if (u.IdLekara == id && u.Termin.Pocetak.ToShortDateString().Equals(datum.ToShortDateString()))
                {
                    usluge.Add(u);
                }

            }

            return usluge;
        }

        public ObservableCollection<Model.ZdravstvenaUsluga> getAll()
        {
            return Usluge;
        }

       public ObservableCollection<ZdravstvenaUsluga> getTerminiByPacijentId(int id)
        {
            loadData();
            ObservableCollection<ZdravstvenaUsluga> ret = new ObservableCollection<ZdravstvenaUsluga>();
            foreach(ZdravstvenaUsluga z in Usluge)
            {
                if (z.IdPacijenta == id)
                { 
                    ret.Add(z);
                }
            }
            return ret;
        }

        public ObservableCollection<ZdravstvenaUsluga> GetTerminByLekarId(int id)
        {
            loadData();
            ObservableCollection<ZdravstvenaUsluga> ret = new ObservableCollection<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.IdLekara == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }


        public ZdravstvenaUsluga ObrisiUslugu(ZdravstvenaUsluga usluga)
        {
            int i = 0;
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.Id == usluga.Id)
                {
                    Usluge.RemoveAt(i);
                    break;
                }
                i++;
            }
            SaveData();
            return usluga;
        }


        public int getLastId()
        {
            int id = 1;
            loadData();
            int brUsluga = Usluge.Count;
            if (brUsluga == 0)
                return id;
            
            return Usluge.ElementAt(brUsluga-1).Id;
        }

    }
}
