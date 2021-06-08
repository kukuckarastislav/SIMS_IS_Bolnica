using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Model;

namespace Bolnica.Repository
{
    class GodisnjiOdmorRepozitorijum
    {
        private const string imeFajla = "godisnjiodmor.json";
        private static GodisnjiOdmorRepozitorijum instance = null;
        public static GodisnjiOdmorRepozitorijum GetInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GodisnjiOdmorRepozitorijum();
                }
                return instance;
            }
            set
            {
                instance = value;
            }

        }
        public GodisnjiOdmorRepozitorijum()
        {
            loadData();
        }

        public ObservableCollection<GodisnjiOdmor> godisnjiOdmori;


        private void loadData()
        {
            try
            {
                if (godisnjiOdmori == null)
                {

                    ObservableCollection<GodisnjiOdmor> o = JsonSerializer.Deserialize<ObservableCollection<GodisnjiOdmor>>(File.ReadAllText("../../podaci/" + imeFajla));
                    godisnjiOdmori = o;
                }
            }
            catch (Exception e)
            {
                godisnjiOdmori = new ObservableCollection<GodisnjiOdmor>();
                Console.WriteLine(e.ToString());
            }
        }


        public void SaveData()
        {
            var format = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            string json = JsonSerializer.Serialize(godisnjiOdmori, format);
            File.WriteAllText("../../podaci/" + imeFajla, json);
        }
        public GodisnjiOdmor DodajOdmor(GodisnjiOdmor odmor)
        {

            if (!this.godisnjiOdmori.Contains(odmor))
                this.godisnjiOdmori.Add(odmor);

            SaveData();
            return odmor;
        }
        public int GetNewId()
        {
            int newId = 1;
            if (godisnjiOdmori.Count == 0)
                return newId;
            return godisnjiOdmori.ElementAt(godisnjiOdmori.Count - 1).Id + 1;
        }


        public ObservableCollection<GodisnjiOdmor> GetAll()
        {
            loadData();
            return godisnjiOdmori;
        }

        public List<GodisnjiOdmor> GetOdmoriLekara(int idLekara)
        {
            List<GodisnjiOdmor> lista = new List<GodisnjiOdmor>();
            foreach(GodisnjiOdmor odmor in godisnjiOdmori)
            {
                if(odmor.LekarId == idLekara)
                {
                    lista.Add(odmor);
                }
            }
            return lista;
        }

        public void obrisiGodisnjiOdmor(int id)
        {
            foreach(GodisnjiOdmor odmor in godisnjiOdmori)
            {
                if(odmor.Id == id)
                {
                    godisnjiOdmori.Remove(odmor);
                    SaveData();
                    break;
                }
            }
        }

        public bool DalJeLekarNaOdmoru(int idLekara, DateTime dan)
        {
            List<GodisnjiOdmor> lista = GetOdmoriLekara(idLekara);
            foreach(GodisnjiOdmor odmor in lista)
            {
                if(odmor.Period.Pocetak.Date<= dan.Date && odmor.Period.Kraj.Date>=dan.Date)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
