using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DTO;

namespace Bolnica.Repository
{
    public class PodesavanjaRepozitorijum
    {
        private const string imeFajla = "podesavanja.json";
        private static PodesavanjaRepozitorijum instance = null;
        public static PodesavanjaRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PodesavanjaRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }

        public List<PodesavanjaDTO> podesavanja { get; set; }

        public PodesavanjaRepozitorijum()
        {

            if (podesavanja == null)
            {

                loadData();
            }
        }

        private void loadData()
        {
            try
            {
                if (podesavanja == null)
                {

                    List<PodesavanjaDTO> p = JsonSerializer.Deserialize<List<PodesavanjaDTO>>(File.ReadAllText("../../podaci/" + imeFajla));
                    podesavanja = p;
                }
            }
            catch (Exception e)
            {
                podesavanja = new List<PodesavanjaDTO>();
                Console.WriteLine(e.ToString());
            }
        }

        public PodesavanjaDTO DodajPodesavanje(PodesavanjaDTO p)
        {
            loadData();

            
            this.podesavanja.Add(p);

            SaveData();
            return p;
        }
        public void ukljuciUlogovanje(int id)
        {
            loadData();


            foreach (PodesavanjaDTO p in podesavanja)
            {
                if (p.Id == id)
                {
                    p.JelBioUlogovan = true;
                    break;
                }
            }

            SaveData();
        }

        public bool jelBioUlogovan(int id)
        {
            loadData();
            foreach (PodesavanjaDTO p in podesavanja)
            {
                if (p.Id == id)
                {
                    if (p.JelBioUlogovan) return true;
                }
            }

            return false;
        }

        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(podesavanja, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
    }
}
