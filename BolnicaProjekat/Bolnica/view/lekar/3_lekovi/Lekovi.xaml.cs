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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Kontroler;

namespace Bolnica.view.lekar.lekovi
{
    /// <summary>
    /// Interaction logic for Lekovi.xaml
    /// </summary>
    public partial class Lekovi : Page
    {

        private view.lekar.GlavniMeni refGlavniMeni;

        public Lekar Lekar;
        public ObservableCollection<Lek> odobreniLekoviKolekcija;
        public ObservableCollection<Lek> lekoviZaReviziju;
        public LekoviKontroler lekoviKontrolerObjekat;
        public Lekovi(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();

            this.odobreniLekoviKolekcija = lekoviKontrolerObjekat.GetOdobreniLekovi();
            this.lekoviZaReviziju = lekoviKontrolerObjekat.GetLekoviZaRevizijuByIdLekara(Lekar.Id);
            this.Odobreni_lekovi.ItemsSource = odobreniLekoviKolekcija;
            this.Lekovi_za_reviziju.ItemsSource = lekoviZaReviziju;
        }

        private void LekoviTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LekoviZaRevizijuTab.IsSelected)
            {
                OdobravanjeLeka.Visibility = Visibility.Visible;
                OdbijanjeLeka.Visibility = Visibility.Visible;
                IzmenaLeka.Visibility = Visibility.Visible;
            }
            if (OdobreniLekoviTab.IsSelected)
            {
                OdobravanjeLeka.Visibility = Visibility.Collapsed;
                OdbijanjeLeka.Visibility = Visibility.Collapsed;
                IzmenaLeka.Visibility = Visibility.Collapsed;
            }
        }

        private void GlavniMeniButton(object sender, RoutedEventArgs e)
        {
            if (this.Lekar != null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(Lekar);
                NavigationService.Navigate(refGlavniMeni);
            }
        }



        private void IzmenaLeka_Click(object sender, RoutedEventArgs e)
        {
            Lek lek = (Lek)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var izmeniLek = new IzmenaLeka(lek, this.Lekar);
                NavigationService.Navigate(izmeniLek);
            }

        }

        private void OdobravanjeLeka_Click(object sender, RoutedEventArgs e)
        {
            Lek lek = (Lek)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var odobriLek = new OdobravanjeLeka(lek, this.Lekar);
                NavigationService.Navigate(odobriLek);
            }
        }

        private void OdbijanjeLeka_Click(object sender, RoutedEventArgs e)
        {
            Lek lek = (Lek)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var odbijLek = new OdbijanjeLeka(lek, this.Lekar);
                NavigationService.Navigate(odbijLek);
            }

        }
    }
}
