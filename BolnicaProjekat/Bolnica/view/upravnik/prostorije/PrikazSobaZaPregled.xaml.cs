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
using Model;
using Kontroler;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazSobaZaPregled.xaml
    /// </summary>
    public partial class PrikazSobaZaPregled : Page
    {
        public ObservableCollection<Prostorija> KolekcijaSobeZaPregled { get; set; }
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public PrikazSobaZaPregled()
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            KolekcijaSobeZaPregled = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            InitializeComponent();
            this.DataGridPrikazSobaZaPregled.ItemsSource = KolekcijaSobeZaPregled;
        }

        public void azurirajPrikaz()
        {
            KolekcijaSobeZaPregled = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            this.DataGridPrikazSobaZaPregled.ItemsSource = KolekcijaSobeZaPregled;
        }
        public Prostorija GetSelectedSobaZaPregled()
        {

            return (DataGridPrikazSobaZaPregled.SelectedItem as Prostorija);
        }
    }
}
