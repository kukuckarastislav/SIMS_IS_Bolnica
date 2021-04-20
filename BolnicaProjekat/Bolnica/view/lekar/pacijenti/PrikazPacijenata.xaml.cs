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

using Repozitorijum;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for PrikazPacijenata.xaml
    /// </summary>
    public partial class PrikazPacijenata : Page
    {
        public ObservableCollection<Model.Pacijent> KolekcijaPacijenata { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;
        public PrikazPacijenata()
        {
            KolekcijaPacijenata = PacijentRepozitorijum.GetInstance.GetAll();
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

        private void MedicinskiKarton_Click(object sender, RoutedEventArgs e)
        {
            Model.Pacijent izabranPacijent = GetSelectedPacijentZaLekar();
            if (izabranPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(izabranPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }


    }
}
