using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace Repozitorijum
{
    public class FeedbackRepozitorijum
    {
        private const string imeFajla = "feedback.json";
        private static FeedbackRepozitorijum instance = null;
        public static FeedbackRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FeedbackRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public FeedbackRepozitorijum()
        {
            loadData();
        }

        public List<Feedback> lista;


        private void loadData()
        {
            try
            {
                if (lista == null)
                {

                    List<Feedback> p = JsonSerializer.Deserialize<List<Feedback>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lista = p;
                }
            }
            catch (Exception e)
            {
                lista = new List<Feedback>();
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
        public Feedback DodajFeedback(Feedback feedback)
        {
            loadData();

            if (!this.lista.Contains(feedback))
                this.lista.Add(feedback);

            SaveData();
            return feedback;
        }


        public List<Feedback> GetAll()
        {
            loadData();
            return lista;
        }

        public List<Feedback> GetFeedbackByPatientId(int id)
        {
            loadData();
            List<Feedback> ret = new List<Feedback>();
            foreach (Feedback z in lista)
            {
                if (z.IdKorisnika == id)
                {
                    ret.Add(z);
                }
            }
            return ret;
        }


        public Feedback GetFeedBackBySekretarId(int id)
        {
            foreach (Feedback z in lista)
            {
                if (z.IdKorisnika == id && z.VrstaKorisnika.Equals("SEKRETAR"))
                {
                    return z;
                }
            }
            return null;
        }

        public int getNewId()
        {
            int id = 1;
            if (lista.Count == 0)
                return id;

            return lista.ElementAt(lista.Count - 1).Id + 1;
        }
    }
}
