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

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for PrikazNeodobrenihLekova.xaml
    /// </summary>
    public partial class PrikazNeodobrenihLekova : Page
    {
        public ObservableCollection<Lek> KolekcijaLekovi { get; set; }
        public Lek OdabraniLek { get; set; }

        public LekoviKontroler lekoviKontrolerObjekat;
        public PrikazNeodobrenihLekova()
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            KolekcijaLekovi = lekoviKontrolerObjekat.GetNeOdobreniLekovi();
            this.DataGridPrikazNeodobrenihLekova.ItemsSource = KolekcijaLekovi;
        }

        public void AzurirajPrikaz()
        {
            KolekcijaLekovi = lekoviKontrolerObjekat.GetNeOdobreniLekovi();
            this.DataGridPrikazNeodobrenihLekova.ItemsSource = KolekcijaLekovi;
        }

        public Lek GetSelectedLek()
        {
            return (DataGridPrikazNeodobrenihLekova.SelectedItem as Lek);
        }

        private void DataGridPrikazNeodobrenihLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabraniLek = DataGridPrikazNeodobrenihLekova.SelectedItem as Lek;
        }
    }
}
