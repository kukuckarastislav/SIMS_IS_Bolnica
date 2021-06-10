using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Interface;
using Model;

namespace Factory
{
    public class JSONBaza : IBaza
    {
        private const string imeFajla = "../../podaci/prostorije.json";

        public void SacuvajPodatke(List<Prostorija> prostorije)
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(prostorije, format);
            File.WriteAllText(imeFajla, json);
        }

        public List<Prostorija> UcitajPodatke()
        {
            List<Prostorija> prostorije = null;
            try
            {
                List<Prostorija> p = JsonSerializer.Deserialize<List<Prostorija>>(File.ReadAllText(imeFajla));
                prostorije = p;
            }
            catch (Exception e)
            {
                prostorije = new List<Prostorija>();
            }
            return prostorije;
        }
    }
}
