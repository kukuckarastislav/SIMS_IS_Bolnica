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
        public DTORadniKalendar OdabranaUsluga { get; set; }
        public Lekar Lekar { get; set; }

        public RadniKalendar(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

            ListaRadniKalendar = ZdravstvenaUslugaServis.getUslugeLekara(Lekar);
            this.RadniKalendar_danasnji.ItemsSource = ListaRadniKalendar;

        }


        private void RadniKalendar_danasnji_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OdabranaUsluga = RadniKalendar_danasnji.SelectedItem as DTORadniKalendar;
        }

        private void BrisanjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }

            refBrisanjeUsluge = new view.lekar.pacijenti.BrisanjeUsluge(Lekar, OdabranaUsluga, ListaRadniKalendar);
            NavigationService.Navigate(refBrisanjeUsluge);
        }

        private void AzuriranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
            refAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(Lekar, OdabranaUsluga, ListaRadniKalendar);
            NavigationService.Navigate(refAzuriranjeUsluge);
        }

        private void EvidentiranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
            refEvidentiranjeUsluge = new view.lekar.pacijenti.EvidentiranjeUsluge(Lekar, OdabranaUsluga, ListaRadniKalendar);
            NavigationService.Navigate(refEvidentiranjeUsluge);

        }

    }
}
