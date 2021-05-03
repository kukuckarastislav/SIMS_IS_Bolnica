using Model;
using Servis;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for RadniKalendar.xaml
    /// </summary>
    public partial class RadniKalendar : Page
    {
        // BACK - PAGES
        private view.lekar.GlavniMeni refGlavniMeni;
        // NEXT - PAGES
        private view.lekar.pacijenti.BrisanjeUsluge refBrisanjeUsluge;
        private view.lekar.pacijenti.AzuriranjeUsluge refAzuriranjeUsluge;
        private view.lekar.pacijenti.EvidentiranjeUsluge refEvidentiranjeUsluge;
        // LISTE
        public ObservableCollection<DTORadniKalendar> ListaRadniKalendar;


        // OBJEKTI
        public DTORadniKalendar odabranaUsluga;
        public Lekar Lekar;

        public RadniKalendar(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

            ListaRadniKalendar = ZdravstvenaUslugaServis.getUslugeLekara(Lekar);
            this.RadniKalendar_danasnji.ItemsSource = ListaRadniKalendar;

        }

        private void UslugaSelektovana(object sender, MouseButtonEventArgs e)
        {
            odabranaUsluga = RadniKalendar_danasnji.SelectedItem as DTORadniKalendar;
        }

        private void BrisanjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (odabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
/*
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(odabranaUsluga);
            ListaZdrastvenaUsluga.Remove(odabranaUsluga);*/
        }

        private void AzuriranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (odabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
          /*  refAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(Lekar, odabranaUsluga);
            NavigationService.Navigate(refAzuriranjeUsluge);*/
        }

        private void EvidentiranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (odabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
       /*     refAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(Lekar, odabranaUsluga);
            NavigationService.Navigate(refAzuriranjeUsluge);*/

        }



    }
}
