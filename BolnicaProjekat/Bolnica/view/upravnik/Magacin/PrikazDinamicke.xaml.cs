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

namespace Bolnica.view.upravnik.Magacin
{
    /// <summary>
    /// Interaction logic for PrikazDinamicke.xaml
    /// </summary>
    public partial class PrikazDinamicke : Page
    {
        private InventariKontroler InventariKontrolerObjekat { get; set; }
        public ObservableCollection<Oprema> KolekcijaOpreme { get; set; }

        private int idInventara;
        private TextBlock prikazSelekcije;
        public PrikazDinamicke(int idInventara, TextBlock prikazSelekcije, bool prikaziOpis=true)
        {
            this.prikazSelekcije = prikazSelekcije;
            this.idInventara = idInventara; 
            InventariKontrolerObjekat = new InventariKontroler();
            InitializeComponent();
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(idInventara, TipOpreme.Dinamicka);
            if (!prikaziOpis)
            {
                polje_opis.Visibility = Visibility.Collapsed;
            }
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }

        public void azurirajPrikaz()
        {
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(idInventara, TipOpreme.Dinamicka);
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }

        public Oprema GetSelectedOprema()
        {
            return (DataGridPrikazStatickeOpreme.SelectedItem as Oprema);
        }


        private void DataGridPrikazStatickeOpreme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (prikazSelekcije != null)
            {
                Oprema op = (DataGridPrikazStatickeOpreme.SelectedItem as Oprema);
                if(op != null)
                    prikazSelekcije.Text = op.Naziv;
            }
        }
    }
}
