using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Kontroler;
using DTO;


namespace Bolnica.view.pacijent
{
    public partial class SopstveniPregledi : Window
    {
        private ObservableCollection<ZdravstvenaUslugaDTO> PreglediPacijenta;
        private ZdravstvenaUslugaDTO odabraniPregled;
        private PacijentDTO Pacijent;
        ZdravstvenaUslugaKontroler Kontroler;

        public SopstveniPregledi(PacijentDTO pacijent)
        {
           InitializeComponent();
           Pacijent = pacijent;
           Kontroler = new ZdravstvenaUslugaKontroler();
           PreglediPacijenta = Kontroler.GetTerminiPacijenta(Pacijent.Id);

            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }


        private void pregled_odabran(object sender, MouseButtonEventArgs e)
        {
            odabraniPregled = listaPregledaPacijenta.SelectedItem as ZdravstvenaUslugaDTO;

            TimeSpan period = new TimeSpan(1, 0, 0, 0, 0);
            if (odabraniPregled.Termin.Pocetak.Subtract(DateTime.Now) < period)
            {
                dugme_otkazi.IsEnabled = false;
            }
            else
            {
                dugme_otkazi.IsEnabled = true;
            }

            if (DateTime.Compare(odabraniPregled.Termin.Kraj, DateTime.Now) < 0)
            {
                dugme_anketa.Visibility = Visibility.Visible;
            }else
            {
                dugme_anketa.Visibility = Visibility.Hidden;
            }

        }


        private void otkazi_pregled(object sender, RoutedEventArgs e)
        {
            if (odabraniPregled == null)
            {
                MessageBox.Show("Odaberite pregled");
                return;
            }

            Kontroler.OtkaziZdravstvenuUslugu(odabraniPregled);
            PreglediPacijenta.Remove(odabraniPregled);
        }

        private void modifikuj_pregled(object sender, RoutedEventArgs e)
        {
            if (odabraniPregled == null)
            {
                MessageBox.Show("Odaberite pregled");
                return;
           }

            var varr = new view.pacijent.PrikazPregleda(odabraniPregled);
            varr.Show();

            listaPregledaPacijenta.Items.Refresh();

        }
        private void zakazi_novi_pregled(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.RaspoloziviPregledi(Pacijent);
            varr.Show();
        }

        private void popuni_anketu(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.AnketaLekar(odabraniPregled);
            varr.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var varr = new TerminiPacijentaHelp();
            varr.ShowDialog();
        }

        private void prosli_termini_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetProsliTerminiPacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }

        private void aktuelni_termini_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetAktuelniTerminiPacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }

        private void aktuelni_pregledi_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetAktuelniPreglediPacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }

        private void prosli_pregledi_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetProsliPreglediPacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }

        private void aktuelne_operacije_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetAktuelneOperacijePacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }

        private void prosle_operacije_Click(object sender, RoutedEventArgs e)
        {
            PreglediPacijenta = Kontroler.GetProsleOperacijePacijenta(Pacijent.Id);
            this.listaPregledaPacijenta.ItemsSource = PreglediPacijenta;
        }
    }
}
