using Bolnica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows;
using Bolnica.DTO;
using Kontroler;

namespace Bolnica.viewmodel
{
    class RegistracijaPacijentaViewModel : BindableBase
    {
        public MyICommand AddPacijentCommand { get; set; }
        private RegistracijaPacijentaDTO currentPacijent = new RegistracijaPacijentaDTO();

        public RegistracijaPacijentaViewModel()
        {
            AddPacijentCommand = new MyICommand(RegistrujPacijenta);
        }

        public RegistracijaPacijentaDTO CurrentPacijent
        {
            get { return currentPacijent; }
            set
            {
                currentPacijent = value;
                OnPropertyChanged("CurrentNote");
            }
        }

        public void RegistrujPacijenta()
        {
            CurrentPacijent.Validate();
            if (CurrentPacijent.IsValid)
            {
                PacijentKontroler kontroler = new PacijentKontroler();
                kontroler.DodajPacijenta(CurrentPacijent);
                MessageBox.Show("Pacijent je uspešno dodat.");
            }
            else
            {
            }

        }
    }
}
