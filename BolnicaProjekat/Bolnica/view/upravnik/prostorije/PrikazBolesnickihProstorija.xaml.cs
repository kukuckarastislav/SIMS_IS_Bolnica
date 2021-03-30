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
    /// Interaction logic for PrikazBolesnickihProstorija.xaml
    /// </summary>
    public partial class PrikazBolesnickihProstorija : Page
    { 
    
        public ObservableCollection<Model.BolesnickaSoba> KolekcijaBolesnickeSobe { get; set; }
        public PrikazBolesnickihProstorija()
        {
            KolekcijaBolesnickeSobe = Model.Bolnica.GetInstance.GetBolesnickeSobe();
            InitializeComponent();
            this.DataGridPrikazBolesnickihProstorija.ItemsSource = KolekcijaBolesnickeSobe;
        }

        public Model.BolesnickaSoba GetSelectedBolesnickaSoba()
        {

            return (DataGridPrikazBolesnickihProstorija.SelectedItem as Model.BolesnickaSoba);
        }
    }
}
