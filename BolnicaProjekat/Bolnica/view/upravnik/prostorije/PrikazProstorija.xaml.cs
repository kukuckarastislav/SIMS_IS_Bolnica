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

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazProstorija.xaml
    /// </summary>
    public partial class PrikazProstorija : Page
    {

        public ObservableCollection<Model.Prostorija> KolekcijaProstorija { get; set; }
        public PrikazProstorija()
        {
            KolekcijaProstorija = Model.Bolnica.GetInstance.GetProstorije();
            InitializeComponent();
            this.DataGridPrikazProstorija.ItemsSource = KolekcijaProstorija;

        }

        public Model.Prostorija GetSelectedProstorija()
        {
            
            return (DataGridPrikazProstorija.SelectedItem as Model.Prostorija);
        }
    }
}
