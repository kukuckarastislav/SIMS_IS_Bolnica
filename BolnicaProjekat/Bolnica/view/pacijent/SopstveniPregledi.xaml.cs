using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Controller;
using DTO;
using Model;

namespace Bolnica.view.pacijent
{
    public partial class SopstveniPregledi : Window
    {
        private ObservableCollection<ZdravstvenaUslugaDTO> PreglediPacijenta;
        private ZdravstvenaUslugaDTO odabraniPregled;
        private Pacijent Pacijent;
        ZdravstvenaUslugaKontroler Kontroler;

        public SopstveniPregledi(Pacijent pacijent)
        {
           InitializeComponent();
           Pacijent = pacijent;
           Kontroler = new ZdravstvenaUslugaKontroler();
           PreglediPacijenta = Kontroler.GetTerminiPacijenta(Pacijent.Id);

            this.listaPregledaPacijenta.
            ItemsSource = PreglediPacijenta;
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

           // Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(odabraniPregled);
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
            var varr = new view.pacijent.RaspoloziviPregledi();
            varr.Show();
        }

        private void popuni_anketu(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.AnketaLekar(odabraniPregled);
            varr.Show();
        }
    }
}
