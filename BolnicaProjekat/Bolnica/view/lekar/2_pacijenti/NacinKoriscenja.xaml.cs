﻿using Model;
using System;
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
using DTO;
using Kontroler;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for NacinKoriscenja.xaml
    /// </summary>
    public partial class NacinKoriscenja : Page
    {
        public Pacijent IzabraniPacijent { get; set; }
        public Lekar Lekar;
        private view.lekar.pacijenti.IzdavanjeRecepta refIzdavanjeRecepta;

        private DateTime PocetakTerapije;
        private DateTime KrajTerapije;
        private int VremenskiRazmak;
        private int PocetakTerapijeUSatima;
        private int DnevniBrojUzimanja;

        private int idLeka;

        public static ParametriUzimanjaTerapijeDTO dto { get; set; }


        public NacinKoriscenja(Lekar Lekar, Pacijent IzabraniPacijent, int idLeka)
        {
            this.Lekar = Lekar;
            this.IzabraniPacijent = IzabraniPacijent;
            this.idLeka = idLeka;
            InitializeComponent();
            KreirajIspravanKalendar();
        }



        private void KreirajIspravanKalendar()
        {
            CalendarDateRange proslost = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            kalPocetakTerapije.BlackoutDates.Add(proslost);
            kalKrajTerapije.BlackoutDates.Add(proslost);
        }

        private void PotvrdiButton(object sender, RoutedEventArgs e)
        {


        }
        private void OdustaniButton(object sender, RoutedEventArgs e)
        {

        }

        private void rdbJednoDnevno_Checked(object sender, RoutedEventArgs e)
        {
            DnevniBrojUzimanja = 1;
        }

        private void rdbDvaPutaDnevno_Checked(object sender, RoutedEventArgs e)
        {
            DnevniBrojUzimanja = 2;
        }

        private void rdTriPutaDnevno_Checked(object sender, RoutedEventArgs e)
        {
            DnevniBrojUzimanja = 3;
        }

        private void kalPocetakTerapije_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime pocetakSelektovanDate = kalPocetakTerapije.SelectedDate.Value;
            PocetakTerapije = new DateTime(pocetakSelektovanDate.Year,
                                                    pocetakSelektovanDate.Month,
                                                    pocetakSelektovanDate.Day,
                                                    PocetakTerapijeUSatima,
                                                    0, 0);
        }

        private void kalKrajTerapije_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime krajSelektovanDate = kalKrajTerapije.SelectedDate.Value;
            KrajTerapije = new DateTime(krajSelektovanDate.Year,
                                                krajSelektovanDate.Month,
                                                krajSelektovanDate.Day, //+1
                                                0, 0, 0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            VremenskiRazmak = Convert.ToInt32(cmbSaRazmakomOd.Text);
            MessageBox.Show(VremenskiRazmak.ToString());
            PocetakTerapijeUSatima = Convert.ToInt32(cmbPocetakTerapije_Sat.Text);
            MessageBox.Show(PocetakTerapijeUSatima.ToString());

            dto = new ParametriUzimanjaTerapijeDTO(PocetakTerapije, KrajTerapije, VremenskiRazmak, PocetakTerapijeUSatima, DnevniBrojUzimanja);
            PodsjetnikKontroler kontroler = new PodsjetnikKontroler();
            kontroler.DodajPodsjetnikZaUzimanjeLijeka(dto, idLeka, IzabraniPacijent.Id);

            refIzdavanjeRecepta = new view.lekar.pacijenti.IzdavanjeRecepta(Lekar, IzabraniPacijent);
            NavigationService.Navigate(refIzdavanjeRecepta);

        }
    }
}
