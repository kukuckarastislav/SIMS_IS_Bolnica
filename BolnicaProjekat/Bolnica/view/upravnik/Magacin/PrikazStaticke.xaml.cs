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
using Model;
using Kontroler;
using System.Collections.ObjectModel;

namespace Bolnica.view.upravnik.Magacin
{
    /// <summary>
    /// Interaction logic for PrikazStaticke.xaml
    /// </summary>
    public partial class PrikazStaticke : Page
    {

        private InventariKontroler InventariKontrolerObjekat { get; set; }
        public ObservableCollection<Oprema> KolekcijaOpreme { get; set; }
        public PrikazStaticke()
        {
            InventariKontrolerObjekat = new InventariKontroler();
            InitializeComponent();                                                      //  0 to je magacin
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(0, TipOpreme.Staticka);
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }



        public void azurirajPrikaz()
        {
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(0, TipOpreme.Staticka);
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }

        public Oprema GetSelectedOprema()
        {
            return (DataGridPrikazStatickeOpreme.SelectedItem as Oprema);
        }
    }
}
