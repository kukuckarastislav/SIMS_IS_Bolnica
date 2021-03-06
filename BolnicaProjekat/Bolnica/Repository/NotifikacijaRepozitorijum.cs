using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;
using Model;

namespace Repozitorijum
{
    class NotifikacijaRepozitorijum
    {

        private const string imeFajla = "notifikacije.json";
        private static NotifikacijaRepozitorijum instance = null;
        public static NotifikacijaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NotifikacijaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public NotifikacijaRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<Model.Notifikacija> Notifikacije { get; set; }


        private void loadData()
        {
            try
            {
                if (Notifikacije == null)
                {

                    ObservableCollection<Model.Notifikacija> n = JsonSerializer.Deserialize<ObservableCollection<Model.Notifikacija>>(File.ReadAllText("../../podaci/" + imeFajla));
                    Notifikacije = n;
                }
            }
            catch (Exception e)
            {
                Notifikacije = new ObservableCollection<Model.Notifikacija>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(Notifikacije, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }

        internal void ObrisiNotifikacijuPacijenta(int idPacijenta, int idNotifikacije)
        {
            int i = 0;
            foreach (Notifikacija n in Notifikacije)
            {
                if (n.Id == idNotifikacije && n.IdPacijenta==idPacijenta)
                {
                    Notifikacije.RemoveAt(i);
                    break;
                }
                i++;
            }
            SaveData();
        }

        public Model.Notifikacija DodajNotifikaciju(Model.Notifikacija notifikacija)
        {
            loadData();

            if (!this.Notifikacije.Contains(notifikacija))
                this.Notifikacije.Add(notifikacija);

            SaveData();
            return notifikacija;
        }

        //logicko brisanje
        public Notifikacija ObrisiNotifikaciju(Notifikacija notifikacija)
        {
            foreach (Notifikacija n in Notifikacije)
            {
                if (n.Id == notifikacija.Id)
                { 
                }
            }
            SaveData();
            return notifikacija;
        }

        public ObservableCollection<Notifikacija> GetAll()
        {
            loadData();
            return Notifikacije;
        }

        public Notifikacija GetById(int id)
        {
            foreach (Notifikacija n in Notifikacije)
            {
                if (n.Id == id)
                    return n;
            }
            return null;
        }

        public ObservableCollection<Notifikacija> GetByIdLekara(int id)
        {
            loadData();
            ObservableCollection<Notifikacija> ListaNot = new ObservableCollection<Notifikacija>();
            foreach (Notifikacija n in Notifikacije)
            {
                if (n.IdLekara == id)
                    ListaNot.Add(n);
            }
            return ListaNot;
        }

        internal ObservableCollection<Notifikacija> GetByPatientId(int v)
        {
            loadData();
            ObservableCollection<Notifikacija> ret = new ObservableCollection<Notifikacija>();
            foreach (Notifikacija n in Notifikacije)
            {
                if (n.IdPacijenta == v)
                    ret.Add(n);
            }
            return ret;
        }


    }
}
