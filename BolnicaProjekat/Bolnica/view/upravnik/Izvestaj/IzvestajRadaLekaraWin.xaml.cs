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
using System.Windows.Shapes;
using DTO;
using Kontroler;

namespace Bolnica.view.upravnik.Izvestaj
{
    /// <summary>
    /// Interaction logic for IzvestajRadaLekaraWin.xaml
    /// </summary>
    public partial class IzvestajRadaLekaraWin : Window
    {

        private ObservableCollection<LekarDTO> KolekcijaLekara;
        private ObservableCollection<RadLekaraDTO> KolekcijaTerminaRada;
        private LekarKontroler LekarKontrolerObjekat;
        private ZdravstvenaUslugaKontroler zdravstvenaUslugaKontrolerObjekat;

        private LekarDTO izabranLekar = null;
        private DateTime pocetak;
        private DateTime kraj;

        public IzvestajRadaLekaraWin()
        {
            InitializeComponent();
            LekarKontrolerObjekat = new LekarKontroler();
            zdravstvenaUslugaKontrolerObjekat = new ZdravstvenaUslugaKontroler();

            KolekcijaLekara = LekarKontrolerObjekat.getAllNeobrisaniLekari();
            comboLekari.ItemsSource = KolekcijaLekara;
        }

        private void Izvestaj_click(object sender, RoutedEventArgs e)
        {
            if (DatePickerPocetak.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Pocetak termina");
                return;
            }
            if (DatePickerKraj.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Kraj termina");
                return;
            }

            pocetak = (DateTime)DatePickerPocetak.SelectedDate;
            kraj = (DateTime)DatePickerKraj.SelectedDate;

            if (pocetak > kraj)
            {
                MessageBox.Show("Kraj ne moze biti pre Pocetka");
                return;
            }

            izabranLekar = (LekarDTO) comboLekari.SelectedItem;
            if(izabranLekar == null)
            {
                MessageBox.Show("Niste selektovali lekara");
                return;
            }

            ucitajPodatkeUIzvestaj();

        }

        private void ucitajPodatkeUIzvestaj()
        {
            txtPocetak.Text = pocetak.ToString();
            txtKraj.Text = kraj.ToString();
            txtLekar.Text = izabranLekar.Ime + " " + izabranLekar.Prezime;

            KolekcijaTerminaRada = new ObservableCollection<RadLekaraDTO>();
            List<RadLekaraDTO> radLekara = zdravstvenaUslugaKontrolerObjekat.GetKolekcijaTerminaRadaDTO(izabranLekar.Id, pocetak, kraj); 
            foreach (RadLekaraDTO rad in radLekara)
            {
                KolekcijaTerminaRada.Add(rad);
            }

            DataGridPrikazPlanaRada.ItemsSource = KolekcijaTerminaRada;
        }

        private void Gen_PDF_click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(Izvestaj_grid, "Invoice");
                }
            }
            finally
            {
            }
            
        }
    }
}
