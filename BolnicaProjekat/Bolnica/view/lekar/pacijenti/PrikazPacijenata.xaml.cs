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

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for PrikazPacijenata.xaml
    /// </summary>
    public partial class PrikazPacijenata : Page
    {
        public PrikazPacijenata()
        {
            InitializeComponent();
        }

        private void OtvoriMedicinskiKarton(object sender, RoutedEventArgs e)
        {
           // RadnaPovrsinaLekar.Content = new view.lekar.pacijenti.PrikazMedicinskiKarton();
        }

  
    }
}