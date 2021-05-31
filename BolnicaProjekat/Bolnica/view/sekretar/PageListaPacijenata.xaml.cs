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
using DTO;
using Model;
using Kontroler;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageListaPacijenata.xaml
    /// </summary>
    public partial class PageListaPacijenata : Page
    {
        private ObservableCollection<PacijentDTO> KolekcijaPacijenata { get; set; }
        public PageListaPacijenata()
        {
            InitializeComponent();
            UcitajPodatkePacijenata();
        }

        private void IzmeniPacijenta_Click(object sender, RoutedEventArgs e)
        {

            PacijentDTO pacijent = DataGridPrikazPacijenata.SelectedItem as PacijentDTO;
            if (pacijent == null) return;

            var pageIzmenaPacijenta = new Bolnica.view.sekretar.PageIzmenaPacijenta(pacijent);
            NavigationService.Navigate(pageIzmenaPacijenta);
            //izmeniPacijentaWindow.Show();

        }

        private void ObrisiPacijenta_Click(object sender, RoutedEventArgs e)
        {
            PacijentDTO pacijent = DataGridPrikazPacijenata.SelectedItem as PacijentDTO;
            if (pacijent == null) return;

            PacijentKontroler kontroler = new PacijentKontroler();
            kontroler.ObrisiPacijenta(pacijent);
            KolekcijaPacijenata.Remove(pacijent);
            MessageBox.Show("Pacijent je uspesno obrisan.");
        }

        private void OtvoriMedicinskiKarton_Click(object sender, RoutedEventArgs e)
        {
            PacijentDTO pacijent = DataGridPrikazPacijenata.SelectedItem as PacijentDTO;
            if (pacijent == null) return;

            var medicinskiKarton = new PageMedicinskiKarton(pacijent);
            NavigationService.Navigate(medicinskiKarton);
        }

        private void UcitajPodatkePacijenata()
        {
            PacijentKontroler kontorler = new PacijentKontroler();
            this.DataGridPrikazPacijenata.ItemsSource = kontorler.GetPacijentiDto();
        }
    }
}
