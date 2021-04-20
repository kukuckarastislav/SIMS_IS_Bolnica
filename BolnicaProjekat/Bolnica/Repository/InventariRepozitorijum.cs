/***********************************************************************
 * Module:  InventariRepozitorijum.cs
 * Author:  Rastislav
 * Purpose: Definition of the Class Repozitorijum.InventariRepozitorijum
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Model;

namespace Repozitorijum
{
    public class InventariRepozitorijum
    {


        private const string imeFajla = "inventari.json";

        public List<Inventar> lInventara;

        private static InventariRepozitorijum instance = null;
        public static InventariRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InventariRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private InventariRepozitorijum()
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                if (lInventara == null)    // dal je ovo potrebno ?
                {

                    List<Inventar> i = JsonSerializer.Deserialize<List<Inventar>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lInventara = i;

                }
            }
            catch (Exception e)
            {

                lInventara = new List<Inventar>();
                Console.WriteLine(e.ToString());
            }
        }
        private void SacuvajPodatke()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lInventara, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }

        public Inventar DodajInventar(Inventar inventar)
        {
            UcitajPodatke();
            lInventara.Add(inventar);
            SacuvajPodatke();
            return inventar;
        }

        public Inventar AzurirajInventar(Inventar inventar)
        {
            SacuvajPodatke();
            return inventar;
        }
        public void AzurirajInventar()
        {
            SacuvajPodatke();
        }

        public Inventar ObrisiInventar(Inventar inventar)
        {
            
            // TODO: implement
            return null;
        }

        public List<Inventar> GetAll()
        {
            UcitajPodatke();
            return lInventara;
        }

        public Inventar GetById(int id)
        {
            UcitajPodatke();
            foreach(Inventar inv in lInventara)
            {
                if( inv.Id == id)
                {
                    return inv;
                }
            }

            return null;
        }

        public int GetFirstFitID()
        {
            UcitajPodatke();
            int najveciID = 0;
            foreach (Inventar inv in lInventara)
            {
                if (inv.Id > najveciID)
                {
                    najveciID = inv.Id;
                }
            }
            return najveciID + 1;
        }


    }
}