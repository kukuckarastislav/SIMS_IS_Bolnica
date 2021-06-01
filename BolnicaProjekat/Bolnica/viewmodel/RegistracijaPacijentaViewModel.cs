using Bolnica.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Windows;

namespace Bolnica.viewmodel
{
    class RegistracijaPacijentaViewModel : BindableBase
    {
        public MyICommand AddLekarCommand { get; set; }
        private RegistracijaLekaraDTO currentLekar = new RegistracijaLekaraDTO();

        public RegistracijaPacijentaViewModel()
        {
            AddLekarCommand = new MyICommand(OnAdd);
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

        public void OnAdd()
        {
            CurrentLekar.Validate();
            if (CurrentLekar.IsValid)
            {
                MessageBox.Show("validan je!");
            }

        }
    }
}
