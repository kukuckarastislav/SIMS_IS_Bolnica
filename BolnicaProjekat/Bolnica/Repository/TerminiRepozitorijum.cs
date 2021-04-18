using System;
using System.Collections.Generic;
using Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;

namespace Repozitorijum
{
    public class TerminiRepozitorijum
    {

        private const string imeFajla = "termini.json";
        private static TerminiRepozitorijum instance = null;
        public static TerminiRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TerminiRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public ObservableCollection<ZdravstvenaUsluga> Pacijenti { get => pacijenti; set => pacijenti = value; }

        public TerminiRepozitorijum()
        {
            loadData();
        }

        private ObservableCollection<Model.ZdravstvenaUsluga> pacijenti;


        private void loadData()
        {
            try
            {
                if (pacijenti == null)
                {

                    ObservableCollection<Model.ZdravstvenaUsluga> p = JsonSerializer.Deserialize<ObservableCollection<Model.ZdravstvenaUsluga>>(File.ReadAllText("../../podaci/" + imeFajla));
                    pacijenti = p;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(pacijenti, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }


        public List<ZdravstvenaUsluga> getTerminiBylekarId(int id)
        {
            return null;
        }


    }
}
