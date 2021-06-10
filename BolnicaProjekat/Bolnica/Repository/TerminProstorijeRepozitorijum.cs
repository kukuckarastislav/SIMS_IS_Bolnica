using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model;

namespace Repozitorijum
{
    public class TerminProstorijeRepozitorijum
    {
        private const string imeFajla = "terminProstorije.json";

        public List<TerminProstorije> lTerminProstorije;

        private static TerminProstorijeRepozitorijum instance = null;
        public static TerminProstorijeRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TerminProstorijeRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        private TerminProstorijeRepozitorijum()
        {
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            try
            {
                if (lTerminProstorije == null)    // dal je ovo potrebno ?
                {
                    List<TerminProstorije> p = JsonSerializer.Deserialize<List<TerminProstorije>>(File.ReadAllText("../../podaci/" + imeFajla));
                    lTerminProstorije = p;
                }
            }
            catch (Exception e)
            {
                lTerminProstorije = new List<TerminProstorije>();
                Console.WriteLine(e.ToString());
            }
        }

        private void SacuvajPodatke()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(lTerminProstorije, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }

        public int GetFirstFitID()
        {
            UcitajPodatke();
            int najveciID = 0;
            foreach (TerminProstorije tp in lTerminProstorije)
            {
                if (tp.Id > najveciID)
                {
                    najveciID = tp.Id;
                }
            }
            return najveciID + 1;
        }

        // getListTerminProstorijeByIdProstorije(int idProstorije);

        public List<TerminProstorije> GetTerminiProstorijeAll()
        {
            UcitajPodatke();
            return lTerminProstorije;
        }

        public TerminProstorije DodajTerminProstorije(TerminProstorije terminProstorije)
        {
            UcitajPodatke();
            lTerminProstorije.Add(terminProstorije);
            SacuvajPodatke();
            return terminProstorije;
        }

        public bool OtkaziTerminProstorije(TerminProstorije terminProstorije)
        {
            UcitajPodatke();
            bool flag = lTerminProstorije.Remove(terminProstorije);
            SacuvajPodatke();
            return flag;
        }

        public TerminProstorije AzurirajTransferOpreme(TerminProstorije terminProstorije)
        {
            UcitajPodatke();
            SacuvajPodatke();
            return terminProstorije;
        }

        public List<TerminProstorije> GetByIdProstorije(int idProstorije)
        {
            List<TerminProstorije> ret = new List<TerminProstorije>();
            foreach (TerminProstorije tp in lTerminProstorije)
            {
                if (tp.IdProstorije1 == idProstorije || tp.IdProstorije2 == idProstorije)
                {
                    ret.Add(tp);
                }
            }
            return ret;
        }
    }
}
