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
using Model;
using Kontroler;
using Bolnica.Controller;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageObavestenja.xaml
    /// </summary>
    public partial class PageObavestenja : Page
    {
        private ObservableCollection<Obavestenje> Obavestenja { get; set; }
        public PageObavestenja()
        {
            InitializeComponent();
            Obavestenja = new ObservableCollection<Obavestenje>();
            ObavestenjeKontroler kontorler = new ObavestenjeKontroler();
            Obavestenja = kontorler.GetAllObavestenja();
            this.listObavestenja.ItemsSource = Obavestenja;
        }

        private void ObrisiObavestenje_Click(object sender, RoutedEventArgs e)
        {
            Obavestenje obavestenje = this.listObavestenja.SelectedItem as Model.Obavestenje;
            if (obavestenje == null) return;

            ObavestenjeKontroler kontroler = new ObavestenjeKontroler();
            kontroler.ObrisiObavestenje(obavestenje.Id);
            MessageBox.Show("Obavestenje je uspesno obrisano.");

        }

        private void DodajObavestenje_Click(object sender, RoutedEventArgs e)
        {
            var winObavestenja = new WindowObavestenja();
            winObavestenja.Show();
        }
    }
}