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
    /// Interaction logic for PrikazBolesnickihProstorija.xaml
    /// </summary>
    public partial class PrikazBolesnickihProstorija : Page
    { 
    
        public ObservableCollection<Prostorija> KolekcijaBolesnickeSobe { get; set; }
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public PrikazBolesnickihProstorija()
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            KolekcijaBolesnickeSobe = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.BolesnickaSoba);
            InitializeComponent();
            this.DataGridPrikazBolesnickihProstorija.ItemsSource = KolekcijaBolesnickeSobe;
        }

        public void azurirajPrikaz()
        {
            KolekcijaBolesnickeSobe = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.BolesnickaSoba);
            this.DataGridPrikazBolesnickihProstorija.ItemsSource = KolekcijaBolesnickeSobe;
        }
        public Prostorija GetSelectedBolesnickaSoba()
        {

            return (DataGridPrikazBolesnickihProstorija.SelectedItem as Prostorija);
        }
    }
}
