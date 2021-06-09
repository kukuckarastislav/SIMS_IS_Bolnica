using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using DTO;
using Model;

namespace Repozitorijum
{
    public class LekoviRepozitorijum
    {
        private const string imeFajla = "lekovi.json";
        private static LekoviRepozitorijum instance = null;
        public static LekoviRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LekoviRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public LekoviRepozitorijum()
        {
            loadData();
        }

        public List<Lek> lekovi;

        private void loadData()
        {
            try
            {
                if (lekovi == null)
                {

                    List<Lek> p = JsonSerializer.Deserialize<List<Lek>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lekovi = p;
                }
            }
            catch (Exception e)
            {
                lekovi = new List<Lek>();
                Console.WriteLine(e.ToString());
            }
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lekovi, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public Lek DodajLek(Lek lek)
        {
            loadData();
            lekovi.Add(lek);
            SaveData();
            return lek;
        }

        public Lek AzurirajLek(Lek lek)
        {
            SaveData();
            return lek;
        }

        public void AzurirajLek(LekDTO izmenjeniLek)
        {
            loadData();
            foreach (Lek lek in lekovi)
            {
                if (lek.Id == izmenjeniLek.Id)
                {
                    lek.Naziv = izmenjeniLek.Naziv;
                    lek.Sifra = izmenjeniLek.Sifra;
                    lek.Kolicina = izmenjeniLek.Kolicina;
                    lek.Cena = izmenjeniLek.Cena;
                    lek.Opis = izmenjeniLek.Opis;
                    lek.Revizije = izmenjeniLek.Revizije;
                    lek.Alergeni = izmenjeniLek.Alergeni;
                    break;
                }
            }
            SaveData();
        }

        public Lek ObrisiLek(Lek stariLek)
        {
            loadData();
            foreach (Lek lek in lekovi)
            {
                if (lek.Id == stariLek.Id)
                {
                    lekovi.Remove(lek);
                    break;
                }
            }
            SaveData();
            return stariLek;
        }

        public void ObrisiLek(LekDTO stariLek)
        {
            loadData();
            foreach (Lek lek in lekovi)
            {
                if (lek.Id == stariLek.Id)
                {
                    lekovi.Remove(lek);
                    break;
                }
            }
            SaveData();
        }


        public List<Lek> GetAll()
        {
            loadData();
            return lekovi;
        }

        public Lek GetLekById(int id)
        {
            loadData();
            foreach (Lek lek in lekovi)
            {
                if (lek.Id == id)
                {
                    return lek;
                }
            }
            return null;
        }

        public int GetFirstFitID()
        {
            loadData();
            int najveciID = 0;
            foreach (Lek lek in lekovi)
            {
                if (lek.Id > najveciID)
                {
                    najveciID = lek.Id;
                }
            }
            return najveciID + 1;
        }
    }

}

