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
        private int idInventara;
        private bool pokaziOpis;
        private TextBlock prikazSelekcije;
        public PrikazStaticke(int idInventara, TextBlock prikazSelekcije, bool pokaziOpis=true)
        {
            this.pokaziOpis = pokaziOpis;
            this.idInventara = idInventara;
            this.prikazSelekcije = prikazSelekcije;
            InventariKontrolerObjekat = new InventariKontroler();
            InitializeComponent();                                                      //  0 to je magacin
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(idInventara, TipOpreme.Staticka);
            if (!pokaziOpis)
            {
                polje_opis.Visibility = Visibility.Collapsed;
            }
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }



        public void azurirajPrikaz()
        {
            KolekcijaOpreme = InventariKontrolerObjekat.GetTipOpremeByIdInventaraObservable(idInventara, TipOpreme.Staticka);
            this.DataGridPrikazStatickeOpreme.ItemsSource = KolekcijaOpreme;
        }

        public void setEditable()
        {
            //DataGridPrikazStatickeOpreme.IsEnabled = 
        }

        public Oprema GetSelectedOprema()
        {
            return (DataGridPrikazStatickeOpreme.SelectedItem as Oprema);
        }

        public void unselektujSve()
        {
            // hmm doradicemo ovo :)
        }

        private void DataGridPrikazStatickeOpreme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (prikazSelekcije != null)
            {
                Oprema op = (DataGridPrikazStatickeOpreme.SelectedItem as Oprema);
                if(op != null)
                {
                    prikazSelekcije.Text = op.Naziv;
                }
            }
            
        }
    }
}
