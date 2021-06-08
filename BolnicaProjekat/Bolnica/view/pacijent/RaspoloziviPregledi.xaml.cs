using Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Kontroler;
using DTO;

namespace Bolnica.view.pacijent
{
    public partial class RaspoloziviPregledi : Window
    {
        private ObservableCollection<ZdravstvenaUslugaDTO> Pregledi;
        private ZdravstvenaUslugaDTO OdabraniPregled;
        private DateTime OdabraniDatum;
        private Lekar OdabraniLekar;

        private ObservableCollection<Lekar> listaLekari;
        ZdravstvenaUslugaKontroler KontrolerZU;
        KorisnickaAktivnostKontroler KontrolerKA;


        public RaspoloziviPregledi()
        {
            InitializeComponent();
            KontrolerZU = new ZdravstvenaUslugaKontroler();
            KontrolerKA = new KorisnickaAktivnostKontroler();

            this.listaPregleda.ItemsSource = Pregledi;

            OdabraniDatum = DateTime.Now;
            listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
        }

        private void odabran_je_pregled(object sender, MouseButtonEventArgs e)
        {
            OdabraniPregled = listaPregleda.SelectedItem as ZdravstvenaUslugaDTO;
        }

        private void zakazi_pregled(object sender, RoutedEventArgs e)
        {
            if (OdabraniPregled == null)
                MessageBox.Show("Niste odabrali pregled");

          
            if (!KontrolerKA.JeSpamUser(1))
            {
                OdabraniPregled.IdPacijenta = 1;
                KontrolerKA.DodajKorisnickuAktivnostZakazivanja(1);
                Pregledi.Remove(OdabraniPregled);
            }
            else
            {
                MessageBox.Show("Nije moguce, blokirani ste");
            }
        }

        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabraniDatum = datum.SelectedDate.Value;

            if (DateTime.Compare(OdabraniDatum, DateTime.Now) < 0)
            {
                MessageBox.Show("Moguce je izabrati samo buduce datume");
                OdabraniDatum = DateTime.Now;
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

            if (pocetakAP.Equals("PM")) pocetakSati += 12;
            if (krajAP.Equals("PM")) krajSati += 12;

            DateTime pocetak = new DateTime(OdabraniDatum.Year, OdabraniDatum.Month, OdabraniDatum.Day, pocetakSati, pocetakMinute, 00);
            DateTime kraj = new DateTime(OdabraniDatum.Year, OdabraniDatum.Month, OdabraniDatum.Day, krajSati, krajkMinute, 00);

            OdabraniLekar = ComboBoxLekari.SelectedItem as Lekar;

            int prioritet = 0;
            if (Lekar.IsChecked == true)
                prioritet = 1;

            Pregledi = KontrolerZU.GetSlobodniTermini(OdabraniLekar, pocetak, kraj, prioritet);
            this.listaPregleda.ItemsSource = Pregledi;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var varr = new PretragaTerminaHelp();
            varr.ShowDialog();
        }
    }
}
