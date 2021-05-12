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
using System.Windows.Shapes;
using Model;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PodsjetnikPacijenta.xaml
    /// </summary>
    public partial class PodsjetnikPacijenta : Window
    {
        public Pacijent Pacijent;
        public ObservableCollection<Podsjetnik> Lista { get; set; }
        private Controller.PodsjetnikKontroler Kontroler;
        public PodsjetnikPacijenta(Pacijent Pacijent)
        {
            Kontroler = new Controller.PodsjetnikKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            Lista = Kontroler.GetPodsjetnikPacijenta(Pacijent.Id);
            this.listaPodsjetnik.ItemsSource = Lista; //zasad null
        }

        private void dodaj_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.NoviPodsjetnik(Pacijent,"");
            varr.Show();
        }
    }
}
