﻿using System;
using System.Collections.Generic;
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

using Model;
using Kontroler;
using Controller;
using System.Collections.ObjectModel;

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for TerminiZauzetosti.xaml
    /// </summary>
    public partial class TerminiZauzetosti : Page
    {


        private ZdravstvenaUslugaKontroler zdravstvenaUslugaKontroler;
        private ObservableCollection<ZdravstvenaUsluga> zdravstvenaUsluga;

        public TerminiZauzetosti()
        {
            zdravstvenaUslugaKontroler = new ZdravstvenaUslugaKontroler();
            //zdravstvenaUsluga = zdravstvenaUslugaKontroler.
            InitializeComponent();
        }

        private void DataGridPrikazStatickeOpreme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
