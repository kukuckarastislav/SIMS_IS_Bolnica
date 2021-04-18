﻿using System;
using System.Collections.Generic;
using Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;

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
            //loadData();
            if (Usluge == null)
            {

                Usluge = new ObservableCollection<Model.ZdravstvenaUsluga>();
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
                Console.WriteLine(e.ToString());
            }
        }

        public ZdravstvenaUsluga DodajUslugu(ZdravstvenaUsluga usluga)
        {
            //loadData();

            if (!this.Usluge.Contains(usluga))
                this.Usluge.Add(usluga);

            SaveData();
            return usluga;
        }

        private void SaveData()
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
            return null;
        }


    }
}