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

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for PrikazPacijenata.xaml
    /// </summary>
    public partial class PrikazPacijenata : Page
    {
        public ObservableCollection<Model.Pacijent> KolekcijaPacijenata { get; set; }
        public PrikazPacijenata()
        {
            KolekcijaPacijenata = Model.Bolnica.GetInstance.GetPacijenti();
            InitializeComponent();
            this.DataGridPrikazPacijenataZaLekar.ItemsSource = KolekcijaPacijenata;
  
        }

        private void OtvoriMedicinskiKarton(object sender, RoutedEventArgs e)
        {
          //  RadnaPovrsinaLekar.Content = new view.lekar.pacijenti.PrikazMedicinskiKarton();
        }

        public Model.Pacijent GetSelectedPacijentZaLekar() {
            Model.Pacijent pacijent = DataGridPrikazPacijenataZaLekar.SelectedItem as Model.Pacijent;
            return pacijent;
        }

  
    }
}
