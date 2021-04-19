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
using Model;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazProstorija.xaml
    /// </summary>
    public partial class PrikazProstorija : Page
    {

        private ProstorijeKontroler ProstorijeKontroler { get; set; }
        public ObservableCollection<Prostorija> KolekcijaProstorija { get; set; }
        public PrikazProstorija()
        {
            ProstorijeKontroler = new ProstorijeKontroler();
            KolekcijaProstorija = ProstorijeKontroler.getProstorijeTipObservable(TipProstorije.Bolnicka);
            InitializeComponent();
            this.DataGridPrikazProstorija.ItemsSource = KolekcijaProstorija;

        }

        public void azurirajPrikaz()
        {
            KolekcijaProstorija = ProstorijeKontroler.getProstorijeTipObservable(TipProstorije.Bolnicka);
            this.DataGridPrikazProstorija.ItemsSource = KolekcijaProstorija;
        }

        public Model.Prostorija GetSelectedProstorija()
        {
            
            return (DataGridPrikazProstorija.SelectedItem as Prostorija);
        }
    }
}
