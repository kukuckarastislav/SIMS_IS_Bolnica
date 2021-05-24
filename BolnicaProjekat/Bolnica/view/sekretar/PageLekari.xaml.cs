using DTO;
using Kontroler;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageLekari.xaml
    /// </summary>
    public partial class PageLekari : Page
    {
        private ObservableCollection<LekarDTO> PrikazaniLekari;
        public PageLekari()
        {
            InitializeComponent();

            LekarKontroler kontroler = new LekarKontroler();
            PrikazaniLekari = kontroler.getAllNeobrisaniLekari();
            this.DataGridPrikazLekara.ItemsSource = PrikazaniLekari;
        }

        private void ObrisiLekara_Click(object sender, RoutedEventArgs e)
        {
            LekarDTO lekar = DataGridPrikazLekara.SelectedItem as LekarDTO;
            if (lekar == null) return;

            LekarKontroler kontroler = new LekarKontroler();
            kontroler.ObrisiLekara(lekar);
            PrikazaniLekari.Remove(lekar);
            MessageBox.Show("Lekar je uspesno obrisan.");
        }

        private void IzmeniLekara_Click(object sender, RoutedEventArgs e)
        {
            LekarDTO lekar = DataGridPrikazLekara.SelectedItem as LekarDTO;
            if (lekar == null) return;
            var page = new PageLekarIzmena(lekar);
            NavigationService.Navigate(page);
        }

        private void RadnoVreme_Click(object sender, RoutedEventArgs e)
        {
            LekarDTO lekar = DataGridPrikazLekara.SelectedItem as LekarDTO;
            if (lekar == null) return;
            var page = new PageRadnoVreme(lekar);
            NavigationService.Navigate(page);
        }
    }
}
