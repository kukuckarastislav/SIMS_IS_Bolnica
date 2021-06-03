using DTO;
using Kontroler;
using Model;
using System;
using System.Collections;
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
    /// Interaction logic for ZakazivanjeTermina.xaml
    /// </summary>
    public partial class ZakazivanjeTermina : Page
    {

        private ObservableCollection<Lekar> listaLekari;
        public ZakazivanjeTermina()
        {
            InitializeComponent();

            UcitajLekare();
            UcitajPacijente();
            UcitajProstorije();
            datumTermina.SelectedDate = DateTime.Now;
            rbPregled.IsChecked = true;
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
            ProstorijeKontroler kontroler = new ProstorijeKontroler();
            //ObservableCollection<ProstorijaDTO> prostorije = kontroler.getAllProstorije();
            //cmbProstorije.ItemsSource = prostorije;
        }

        private void cbHitnoZakazivanje_Checked(object sender, RoutedEventArgs e)
        {
            datumTermina.IsEnabled = false;
            datumTermina.SelectedDate = DateTime.Now;
            cmbProstorije.IsEnabled = false;
        }

        private void cbHitnoZakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            datumTermina.IsEnabled = true;
            datumTermina.SelectedDate = DateTime.Now;
            cmbProstorije.IsEnabled = true;
        }

        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            ValidirajUnos();
        }

        private bool ValidirajUnos()
        {
            ResetujGreske();
            bool validanUnos = true;

            if (!ValidirajPacijenta()) validanUnos = false;
            if (!ValidirajLekara()) validanUnos = false;
            if (!ValidirajDatum()) validanUnos = false;
            if (!ValidirajVremeTermina()) validanUnos = false;

            if (!validanUnos)
            {
                
            }
            else
            {
                
            }

            return validanUnos;
        }

        
        private void ResetujGreske()
        {
            tbErrDatumTermina.Text = "";
            tbErrLekar.Text = "";
            tbErrPacijent.Text = "";
            tbErrTermin.Text = "";
        }
        private bool ValidirajPacijenta()
        {
            if (cmbPacijenti.SelectedIndex==-1)
            {
                tbErrPacijent.Text = "Pacijent nije odabran.";
                return false;
            }
            return true;
        }
        private bool ValidirajLekara()
        {
            if (cmbLekari.SelectedIndex == -1)
            {
                tbErrLekar.Text = "Lekar nije odabran.";
                return false;
            }
            return true;
        }

        private bool ValidirajDatum()
        {
            if(datumTermina.SelectedDate==null)
            {
                tbErrDatumTermina.Text = "Datum nije odabran";
                return false;
            }
            return true;
        }

        private bool ValidirajVremeTermina()
        {
            return true;
        }

    }
}
