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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PagePacijenti.xaml
    /// </summary>
    public partial class PagePacijenti : Page
    {
        public ObservableCollection<Model.Pacijent> KolekcijaPacijenata { get; set; }
        
        public PagePacijenti()
        {
            KolekcijaPacijenata = Model.Bolnica.GetInstance.GetPacijenti();
            
            InitializeComponent();
           
            this.DataGridPrikazPacijenata.ItemsSource = KolekcijaPacijenata;
        }

        private void IzmeniPacijenta_Click(object sender, RoutedEventArgs e)
        {

            Model.Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Model.Pacijent;
            if (pacijent == null) return;

            var izmeniPacijentaWindow = new Bolnica.view.sekretar.WindowIzmenaPodataka(pacijent, DataGridPrikazPacijenata);
            izmeniPacijentaWindow.Show();

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {

            
        }

    }
}
