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

namespace Bolnica.view.sekretar.wizard
{
    /// <summary>
    /// Interaction logic for PageZT3.xaml
    /// </summary>
    public partial class PageZT3 : Page
    {
        public PageZT3()
        {
            InitializeComponent();
            UcitajLekare();
            UcitajPacijente();
            UcitajProstorije();
            cmbLekari.SelectedIndex = 1;
            cmbPacijenti.SelectedIndex = 1;
            cmbProstorije.SelectedIndex = 2;
            cbPocetakSati.SelectedIndex = 10;
            cbKrajSati.SelectedIndex = 11;
            cbPocetaMinuti.SelectedIndex = 0;
            cbKrajMinuti.SelectedIndex = 0;
            rbPregled.IsChecked = true;
            datumTermina.SelectedDate = DateTime.Now;
            tbRadnoVreme.Text = "08:00 - 16:00";
            tbErrProstorije.Text = "Prostorija je zauzeta u izabranom vremenu.";
        }

        private void btnZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Termin je uspešno zakazan.");
            NavigationService.Navigate(new view.sekretar.wizard.WizardKraj());

        }
        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new view.sekretar.PocetnaStranica());
            App.jelPrvoPokretanjeAplikacije = false;
        }

        private void btnPrethodna_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new view.sekretar.wizard.PageZT2());
        }

        private void UcitajLekare()
        {
            LekarKontroler kontroler = new LekarKontroler();
            ObservableCollection<LekarDTO> lekari = kontroler.getAllNeobrisaniLekari();
            cmbLekari.ItemsSource = lekari;
        }
        private void UcitajPacijente()
        {
            PacijentKontroler kontroler = new PacijentKontroler();
            ObservableCollection<PacijentDTO> pacijeti = kontroler.GetPacijentiDto();
            cmbPacijenti.ItemsSource = pacijeti;
        }
        private void UcitajProstorije()
        {
            ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
            ProstorijeKontroler kontroler = new ProstorijeKontroler();
            foreach (ProstorijaDTO dto in kontroler.GetProstorijeDTO())
            {
                prostorije.Add(dto);
            }
            cmbProstorije.ItemsSource = prostorije;
        }
    }
}
