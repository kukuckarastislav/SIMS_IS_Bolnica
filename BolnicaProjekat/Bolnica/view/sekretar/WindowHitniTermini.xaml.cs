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
using System.Windows.Shapes;
using Model;
using Kontroler;
using System.Collections.ObjectModel;
using Controller;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowHitniTermini.xaml
    /// </summary>
    public partial class WindowHitniTermini : Window
    {
        private Pacijent pacijent;
        private ObservableCollection<Model.Lekar> listaLekari;
        private ObservableCollection<ZdravstvenaUsluga> Pregledi { get; set; }
        public WindowHitniTermini(Pacijent pacijent)
        {
            InitializeComponent();
            this.pacijent = pacijent;
            rbPregled.IsChecked = true;
            LekarKontroler kontroler = new LekarKontroler();
            listaLekari = kontroler.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
        }

        private void UcitajTermine_Click(object sender, RoutedEventArgs e)
        {
            /*
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            Lekar odabraniLekar = this.ComboBoxLekari.SelectedItem as Lekar;
            if (odabraniLekar == null) return;

            if (datePicker.SelectedDate == null) return;
            DateTime temp = (DateTime)datePicker.SelectedDate;
            if (temp == null) return;

            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            PreglediList = kontroler.getAppointments(odabraniLekar, temp);
            foreach (var usluga in PreglediList)
            {
                Pregledi.Add(usluga);
            }
            this.listaPregleda.ItemsSource = Pregledi;
            */

        }


        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            if (Pregledi == null) return;
            Lekar odabraniLekar = this.ComboBoxLekari.SelectedItem as Lekar;
            if (odabraniLekar == null) return;

            ZdravstvenaUsluga usluga = listaPregleda.SelectedItem as ZdravstvenaUsluga;
            usluga.IdPacijenta = pacijent.Id;
            if (rbPregled.IsChecked == true)
                usluga.TipUsluge = TipUsluge.Pregled;
            else
                usluga.TipUsluge = TipUsluge.Operacija;

            ZdravstvenaUslugaKontroler zkontroler = new ZdravstvenaUslugaKontroler();
            ZdravstvenaUsluga novau = zkontroler.HitnoDodajUslugu(odabraniLekar, usluga);
            
            MessageBox.Show("Termin je uspesno zauzet.");
            this.Close();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ComboBoxLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            Lekar odabraniLekar = this.ComboBoxLekari.SelectedItem as Lekar;
            if (odabraniLekar == null) return;

            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            List<ZdravstvenaUsluga> list = kontroler.GetSviTerminiZaDatum(odabraniLekar, DateTime.Now);
            foreach (var usluga in list)
            {
                Pregledi.Add(usluga);
            }
            this.listaPregleda.ItemsSource = Pregledi;
        }
    }
}
