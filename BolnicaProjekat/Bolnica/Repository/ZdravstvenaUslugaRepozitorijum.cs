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

        public List<ZdravstvenaUsluga> Usluge { get; set; }

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

                    List<ZdravstvenaUsluga> u = JsonSerializer.Deserialize<List<ZdravstvenaUsluga>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Usluge = u;
                }
            }
            catch (Exception e)
            {
                Usluge = new List<ZdravstvenaUsluga>();
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

        public List<ZdravstvenaUsluga> getAll()
        {
            return Usluge;
        }

        public List<ZdravstvenaUsluga> getTerminiByPacijentId(int id)
        {
            loadData();
            List<ZdravstvenaUsluga> ret = new List<ZdravstvenaUsluga>();
            foreach(ZdravstvenaUsluga z in Usluge)
            {
                if (z.IdPacijenta == id)
                { 
                    ret.Add(z);
                }
            }
            return ret;
        }

        public ZdravstvenaUsluga getTerminById(int id)
        {
            loadData();
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.Id == id)
                {
                    return z;
                }
            }
            return null;
        }

        public List<ZdravstvenaUsluga> GetTerminByLekarId(int id)
        {
            loadData();
            List<ZdravstvenaUsluga> ret = new List<ZdravstvenaUsluga>();
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

        public ZdravstvenaUsluga EvidentirajUslugu(ZdravstvenaUsluga usluga, string anamneza)
        {
            int i = 0;
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.Id == usluga.Id)
                {
                    z.RezultatUsluge = anamneza;
                    break;
                }
                i++;
            }
            SaveData();
            return usluga;
        }

        public ZdravstvenaUsluga AzurirajVremeUsluga(ZdravstvenaUsluga usluga, DateTime pocetak, DateTime kraj)
        {
            int i = 0;
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.Id == usluga.Id)
                {
                    z.Termin.Pocetak = pocetak;
                    z.Termin.Kraj = kraj;
                    break;
                }
                i++;
            }
            SaveData();
            return usluga;

        }
        public ZdravstvenaUsluga AzurirajUslugu(ZdravstvenaUsluga usluga)
        {
            SaveData();
            return usluga;
        }

        public ZdravstvenaUsluga GetUslugaZaTermin(Lekar lekar, DateTime termin)
        {
            foreach (ZdravstvenaUsluga usluga in Usluge)
            {
                if (usluga.IdLekara == lekar.Id
                    && usluga.Termin.Pocetak.Date.Equals(termin.Date))
                {
                    return usluga;
                }
            }

            return null;
        }


        public int getNewId()
        {
            int id = 1;
            if (Usluge.Count == 0)
                return id;
            
            return Usluge.ElementAt(Usluge.Count - 1).Id + 1;
        }

    }
}
