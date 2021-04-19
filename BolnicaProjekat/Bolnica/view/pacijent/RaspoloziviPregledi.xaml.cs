using Model;
using System;
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
using System.Windows.Shapes;
using Servis;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for pregledi.xaml
    /// </summary>
    public partial class RaspoloziviPregledi : Window
    {
        public ObservableCollection<ZdravstvenaUsluga> Pregledi;
        public List<ZdravstvenaUsluga> PreglediList { get; set; }
        public ZdravstvenaUsluga odabraniPregled;
        public DateTime date;
        public  Lekar OdabraniLekar;
        public ObservableCollection<Lekar> listaLekari { get; set; }

        public RaspoloziviPregledi()
        {
            InitializeComponent();

            //Pregledi = ZdravstvenaUslugaServis.getFirstAvailableAppointments();
             this.listaPregleda.ItemsSource = Pregledi;

            date = DateTime.Now;
            listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
        }

        private void odabran_je_pregled(object sender, MouseButtonEventArgs e)
        {
            odabraniPregled = listaPregleda.SelectedItem as ZdravstvenaUsluga;
            MessageBox.Show(odabraniPregled.Termin.Pocetak.ToString());
        }

        private void zakazi_pregled(object sender, RoutedEventArgs e)
        {
            if (odabraniPregled == null)
                MessageBox.Show("Niste odabrali pregled");

            odabraniPregled.IdPacijenta = 1;
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(odabraniPregled);
            Pregledi.Remove(odabraniPregled);
        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = datum.SelectedDate.Value;

            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                MessageBox.Show("Moguce je izabrati samo buduce datume");
                date = DateTime.Now;
            }


        }

        private void pretrazi_termine(object sender, RoutedEventArgs e)
        {          
            int pocetakSati = Convert.ToInt32(vrijeme_pocetak_sati.Text);
            int pocetakMinute = Convert.ToInt32(vrijeme_pocetak_minute.Text);
            string pocetakAP = vrijeme_pocetak_ap.Text;

            int krajSati = Convert.ToInt32(vrijeme_kraj_sati.Text);
            int krajkMinute = Convert.ToInt32(vrijeme_kraj_minute.Text);
            string krajAP = vrijeme_kraj_ap.Text;

            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;
            if (krajAP.Equals("PM"))
                krajSati += 12;

            DateTime pocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute,00);
            DateTime kraj = new DateTime(date.Year, date.Month, date.Day,krajSati,krajkMinute,00);

            OdabraniLekar = ComboBoxLekari.SelectedItem as Lekar;

            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            PreglediList = ZdravstvenaUslugaServis.getAvailableAppointments(OdabraniLekar, pocetak, kraj,0);
            foreach (var v in PreglediList)
                Pregledi.Add(v);

            this.listaPregleda.ItemsSource = Pregledi;
        }
    }
}
