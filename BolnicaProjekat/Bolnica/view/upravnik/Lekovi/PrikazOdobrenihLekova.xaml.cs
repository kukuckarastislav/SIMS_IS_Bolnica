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

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for PrikazOdobrenihLekova.xaml
    /// </summary>
    /// 
    public partial class PrikazOdobrenihLekova : Page
    {
        public ObservableCollection<Lek> KolekcijaLekovi { get; set; }
        public Lek OdabraniLek { get; set; }
        public PrikazOdobrenihLekova()
        {
            InitializeComponent();
            Kontroler.LekoviKontroler Kontroler = new Kontroler.LekoviKontroler();
            KolekcijaLekovi = Kontroler.GetOdobreniLekovi();

            this.DataGridPrikazOdobrenihLekova.ItemsSource = KolekcijaLekovi;

        }

        private void DataGridPrikazOdobrenihLekova_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OdabraniLek = DataGridPrikazOdobrenihLekova.SelectedItem as Lek;
        }

    }
}
