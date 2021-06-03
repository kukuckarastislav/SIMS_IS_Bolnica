using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public List<Podsjetnik> lista;


        private void loadData()
        {
            try
            {
                if (lista == null)
                {

                    List<Podsjetnik> p = JsonSerializer.Deserialize<List<Podsjetnik>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lista = p;
                }
            }
            catch (Exception e)
            {
                lista = new List<Podsjetnik>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lista, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Podsjetnik DodajPodsjetnik(Podsjetnik ocena)
        {
            loadData();

            if (!this.lista.Contains(ocena))
                this.lista.Add(ocena);

            SaveData();
            return ocena;
        }


        public List<Podsjetnik> GetAll()
        {
            loadData();
            return lista;
        }

        public List<Podsjetnik> GetPodsjetnikByPatientId(int id)
        {
            loadData();
            List<Podsjetnik> ret = new List<Podsjetnik>();
            foreach (Podsjetnik z in lista)
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

        public int getNewId()
        {
            int id = 1;
            if (lista.Count == 0)
                return id;

            return lista.ElementAt(lista.Count - 1).Id + 1;
        }

        internal Podsjetnik GetPodsjetnikById(int reminderid)
        {
            loadData();
            foreach (Podsjetnik z in lista)
            {
                if (z.Id == reminderid)
                    return z;              
            }
            return null;
        }
    }

}