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
    /// Interaction logic for PrikazOperacionihSala.xaml
    /// </summary>
    public partial class PrikazOperacionihSala : Page
    {

        public ObservableCollection<Prostorija> KolekcijaOperacionihSala { get; set; }
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }

        public PrikazOperacionihSala()
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            KolekcijaOperacionihSala = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.OpracionaSala);
            InitializeComponent();
            this.DataGridPrikazOperacionihSala.ItemsSource = KolekcijaOperacionihSala;
        }

        public void azurirajPrikaz()
        {
            KolekcijaOperacionihSala = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.OpracionaSala);
            this.DataGridPrikazOperacionihSala.ItemsSource = KolekcijaOperacionihSala;
        }

        public Prostorija GetSelectedOperacionaSala()
        {

            return (DataGridPrikazOperacionihSala.SelectedItem as Prostorija);
        }

    }
}
