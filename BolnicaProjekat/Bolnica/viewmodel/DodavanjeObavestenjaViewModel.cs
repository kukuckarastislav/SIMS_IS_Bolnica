using Bolnica.Controller;
using Bolnica.utils;
using DTO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica.viewmodel
{
    public class DodavanjeObavestenjaViewModel : BindableBase
    {
        public MyICommand AddObavestenjeCommand { get; set; }
        private DodavanjeObavestenjaDTO currentObavestenje = new DodavanjeObavestenjaDTO();

        public DodavanjeObavestenjaViewModel()
        {
            AddObavestenjeCommand = new MyICommand(DodajObavestenje);
        }

        public DodavanjeObavestenjaDTO CurrentObavestenje
        {
            get { return currentObavestenje; }
            set
            {
                currentObavestenje = value;
                OnPropertyChanged("CurrentObavestenje");
            }
        }

        public void DodajObavestenje()
        {
            CurrentObavestenje.Validate();
            if (CurrentObavestenje.IsValid)
            {
                ObavestenjeKontroler kontroler = new ObavestenjeKontroler();
                Obavestenje ret = kontroler.DodajObavestenje(CurrentObavestenje.Naslov, CurrentObavestenje.Poruka);
             
                MessageBox.Show("Obavestenje je uspesno dodato.");
                CurrentObavestenje.Naslov = "";
                CurrentObavestenje.Poruka = "";
            }
            else
            {

            }

        }
    }
}
