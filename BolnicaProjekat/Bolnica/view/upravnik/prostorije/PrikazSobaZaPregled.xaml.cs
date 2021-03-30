﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazSobaZaPregled.xaml
    /// </summary>
    public partial class PrikazSobaZaPregled : Page
    {
        public ObservableCollection<Model.SobaZaPreglede> KolekcijaSobeZaPregled { get; set; }
        public PrikazSobaZaPregled()
        {
            KolekcijaSobeZaPregled = Model.Bolnica.GetInstance.GetSobeZaPreglede();
            InitializeComponent();
            this.DataGridPrikazSobaZaPregled.ItemsSource = KolekcijaSobeZaPregled;
        }

        public Model.SobaZaPreglede GetSelectedSobaZaPregled()
        {

            return (DataGridPrikazSobaZaPregled.SelectedItem as Model.SobaZaPreglede);
        }
    }
}
