using Bolnica.utils;
using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using DTO;
using Kontroler;
using Servis;
using Model;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for ZauzetostProstorija.xaml
    /// </summary>
    public partial class ZauzetostProstorija : Page
    {
        private PieChart chartPolje;
        public ZauzetostProstorija()
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;

            chartPolje = this.pieChart;
            UcitajProstorije();
            inputDatumKraja.SelectedDate = DateTime.Now;
            inputDatumPocetka.SelectedDate = DateTime.Now;
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

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("Ime");

            }
        }

        private void btnKreirajIzvestaj_Click(object sender, RoutedEventArgs e)
        {
            resetujGreske();
            if (ValidirajProstoriju() && ValidirajDatume())
            {
                this.pieChart.Visibility = Visibility.Visible;
                pozadina.Visibility = Visibility.Visible;

                ZdravstvenaUslugaServis servis = new ZdravstvenaUslugaServis();
                Termin t = new Termin((DateTime)inputDatumPocetka.SelectedDate, (DateTime)inputDatumKraja.SelectedDate);
                ProstorijaDTO prostorija = cmbProstorije.SelectedItem as ProstorijaDTO;
                IzvestajDto dto  = servis.procenatZauzetosti(prostorija.Id, t);
               
                SeriesCollection kolekcija = new SeriesCollection
                {
                    new PieSeries
                    {
                        Title = "Slobodno",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(100-dto.Procenat) },
                        DataLabels = true
                    },
                    new PieSeries
                    {
                        Title = "Zauzeto",
                        Values = new ChartValues<ObservableValue> { new ObservableValue(dto.Procenat) },
                        DataLabels = true
                    }
                };
                
                this.pieChart.Series = kolekcija;
                tbDatum.Text = dto.datum.ToShortDateString();
                tbNaslov.Visibility = Visibility.Visible;

            }
        }

        private void resetujGreske()
        {
            tbErrDatum.Text = "";
            tbErrProstorije.Text = "";
        }

        private bool ValidirajProstoriju()
        {
            if (cmbProstorije.SelectedIndex == -1)
            {
                tbErrProstorije.Text = "Niste odabrali prostoriju";
                return false;
            }
            return true;
        }
        private bool ValidirajDatume()
        {
            if(inputDatumPocetka.SelectedDate == null || inputDatumKraja.SelectedDate == null)
            {
                tbErrDatum.Text = "Morate odabrati datume za izveštaj.";
                return false;
            }
            if(inputDatumPocetka.SelectedDate >= inputDatumKraja.SelectedDate)
            {
                tbErrDatum.Text = "Datum kraja mora biti pre datuma početka.";
                return false;
            }

            return true;
        }
    }
}
