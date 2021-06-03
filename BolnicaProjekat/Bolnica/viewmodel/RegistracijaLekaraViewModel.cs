using Bolnica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Collections.ObjectModel;
using System.Windows;
using Kontroler;

namespace Bolnica.viewmodel
{
    public class RegistracijaLekaraViewModel : BindableBase
    {
        public MyICommand AddLekarCommand { get; set; }
        private RegistracijaLekaraDTO currentLekar = new RegistracijaLekaraDTO();

        public RegistracijaLekaraViewModel()
        {
            AddLekarCommand = new MyICommand(RegistrujLekara);
        }

        public RegistracijaLekaraDTO CurrentLekar
        {
            get { return currentLekar; }
            set
            {
                currentLekar = value;
                OnPropertyChanged("CurrentNote");
            }
        }

        public void RegistrujLekara()
        {
            CurrentLekar.Validate();
            if (CurrentLekar.IsValid)
            {
                LekarKontroler kontroler = new LekarKontroler();
                kontroler.DodajLekara(CurrentLekar);
                MessageBox.Show("Lekar je uspešno dodat.");
            }
            else
            {

            }

        }
    }
}
