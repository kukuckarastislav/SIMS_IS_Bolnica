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


        #region - Polja - ZdrastvenaUslugaRepozitorijum
        private const string imeFajla = "zdravstveneUsluge.json";
        private static ZdravstvenaUslugaRepozitorijum instance = null;
        public List<ZdravstvenaUsluga> Usluge { get; set; }
        #endregion

        #region - Singleton - ZdrastvenaUslugaRepozitorijum
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
        #endregion

        #region - Konstruktor - ZdrastvenaUslugaRepozitorijum
        public ZdravstvenaUslugaRepozitorijum()
        {
            if (Usluge == null)
            {
                LoadData();
            }
        }
        #endregion

        #region - Metode - LoadData, SaveData - ZdrastvenaUslugaRepozitorijum
        private void LoadData()
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
        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Usluge, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        #endregion

        #region - Metode - Zdrastvena usluga(model) - Dodaj, AzurirajVreme, Obrisi, Evidentiraj
        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            LoadData();

            if (!this.Usluge.Contains(usluga))
                this.Usluge.Add(usluga);

            SaveData();
            return usluga;
        }

        public ZdravstvenaUsluga AzurirajVremeUsluga(ZdravstvenaUsluga usluga, DateTime pocetak, DateTime kraj)
        {
            LoadData();

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
        public ZdravstvenaUsluga ObrisiUslugu(ZdravstvenaUsluga usluga)
        {
            foreach (ZdravstvenaUsluga z in Usluge)
            {
                if (z.Id == usluga.Id)
                {
                    Usluge.Remove(z);
                    break;
                }
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
                    z.Obavljena = true;
                    z.RezultatUsluge = anamneza;
                    break;
                }
                i++;
            }
            SaveData();
            return usluga;
        }

        #endregion

        public List<ZdravstvenaUsluga> getTerminiBylekarId(int id)
        {
            LoadData();
            List<ZdravstvenaUsluga> usluge = new List<ZdravstvenaUsluga>();

            foreach (ZdravstvenaUsluga u in Usluge)
            {
                if (u.IdLekara == id)
                {
                    usluge.Add(u);
                }

            }

            return usluge;
        }

        public List<ZdravstvenaUsluga> GetUslugeByProstorijaId(int id)
        {
            LoadData();
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
            LoadData();
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
            LoadData();
            List<ZdravstvenaUsluga> ret = new List<ZdravstvenaUsluga>();
            foreach (ZdravstvenaUsluga z in Usluge)
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
            LoadData();
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
            LoadData();
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
