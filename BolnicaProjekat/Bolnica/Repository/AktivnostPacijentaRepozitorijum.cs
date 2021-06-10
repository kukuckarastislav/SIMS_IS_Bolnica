using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    public class AktivnostPacijentaRepozitorijum
    {
        private const string imeFajla = "korisnickaAktivnost.json";
        private static AktivnostPacijentaRepozitorijum instance = null;
        public static AktivnostPacijentaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AktivnostPacijentaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public AktivnostPacijentaRepozitorijum()
        {
            loadData();
        }

        public List<Aktivnost> aktivnosti;


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
                aktivnosti = new List<Aktivnost>();
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
        public Aktivnost DodajAktivnost(Model.Aktivnost aktivnost)
        {
            loadData();

            if (!this.aktivnosti.Contains(aktivnost))
                this.aktivnosti.Add(aktivnost);

            SaveData();
            return aktivnost;
        }


        public List<Aktivnost> GetAll()
        {
            loadData();
            return aktivnosti;
        }

        public List<Aktivnost> GetPatientActivityById(int id)
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

        public DateTime GetDatumSuspenzije(int idPacijenta)
        {
            loadData();
            foreach (Aktivnost z in aktivnosti)
            {
                if (z.IdPacijenta == idPacijenta && z.Vrsta.Equals("TRENUTNA SUSPENZIJA"))
                {
                    return z.Datum;
                }
            }
            return new DateTime(0, 0, 0, 0, 0, 0, 0);
        }

        public void AzurirajStareSuspenzije(int idPacijenta)
        {
            loadData();
            foreach (Aktivnost a in aktivnosti)
            {
                if (a.IdPacijenta == idPacijenta && a.Vrsta.Equals("TRENUTNA SUSPENZIJA"))
                {
                    a.Vrsta = "SUSPENZIJA";
                }
            }
            SaveData();
        }

        internal List<Aktivnost> GetAllSuspenzije()
        {
            loadData();
            List<Aktivnost> ret = new List<Aktivnost>();
            foreach (Aktivnost z in aktivnosti)
            {
                if (z.Vrsta.Equals("TRENUTNA SUSPENZIJA"))
                {
                    ret.Add(z);
                }
            }
            return ret;
        }


    }
}


