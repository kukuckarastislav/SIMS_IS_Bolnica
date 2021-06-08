using Bolnica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DodavanjeObavestenjaDTO : ValidationBase
    {
        public int id { get; set; }
        public string naslov { get; set; }
        public DateTime datumObjave { get; set; }
        public string poruka { get; set; }

        public DodavanjeObavestenjaDTO()
        {

        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Naslov
        {
            get { return naslov; }
            set
            {
                if (naslov != value)
                {
                    naslov = value;
                    OnPropertyChanged("Naslov");
                }
            }
        }

        public string Poruka
        {
            get { return poruka; }
            set
            {
                if (poruka != value)
                {
                    poruka = value;
                    OnPropertyChanged("Poruka");
                }
            }
        }

        protected override void ValidateSelf()
        {
            ValidirajNalsov();
            ValidirajPoruku();
        }

  

        private void ValidirajNalsov()
        {
            if (string.IsNullOrWhiteSpace(this.naslov))
            {
                this.ValidationErrors["Naslov"] = "Polje ne može biti prazno.";
            }
        }

        private void ValidirajPoruku()
        {
            if (string.IsNullOrWhiteSpace(this.poruka))
            {
                this.ValidationErrors["Poruka"] = "Polje ne može biti prazno.";
            }
        }
        
    }
}
