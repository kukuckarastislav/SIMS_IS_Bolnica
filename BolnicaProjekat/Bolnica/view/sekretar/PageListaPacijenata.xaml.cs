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
using Bolnica.utils;

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
            btnPomoc.Visibility = App.vidljivostPomoci;
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
            KolekcijaPacijenata = kontorler.GetPacijentiDto();
            this.DataGridPrikazPacijenata.ItemsSource = KolekcijaPacijenata;
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("ListaPacijenata");

            }
        }

        private void btnTrazi_Click(object sender, RoutedEventArgs e)
        {
            UcitajPodatkePacijenata();
            if (String.IsNullOrWhiteSpace(tbPretraga.Text)) return;

            KolekcijaPacijenata = new ObservableCollection<PacijentDTO>(KolekcijaPacijenata.Where((dto) =>dto.Jmbg.ToLower().Equals(tbPretraga.Text.ToLower())));
            this.DataGridPrikazPacijenata.ItemsSource = KolekcijaPacijenata;
        }
    }
}
