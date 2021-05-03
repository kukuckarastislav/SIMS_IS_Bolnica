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
using Repozitorijum;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for PrikazPacijenata.xaml
    /// </summary>
    public partial class PrikazPacijenata : Page
    {

        // BACK - PAGES
        private view.lekar.GlavniMeni refGlavniMeni;
        // NEXT - PAGES
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;
        // KORISNICI
        public Lekar Lekar;
        // KOLEKCIJE
        public ObservableCollection<Model.Pacijent> KolekcijaPacijenata { get; set; }


        public PrikazPacijenata(Lekar Lekar)
        {
            this.Lekar = Lekar;
            KolekcijaPacijenata = PacijentRepozitorijum.GetInstance.GetAll();
            InitializeComponent();
            this.DataGridPrikazPacijenataZaLekar.ItemsSource = KolekcijaPacijenata;
  
        }

        public Model.Pacijent GetSelectedPacijentZaLekar() {
            Model.Pacijent pacijent = DataGridPrikazPacijenataZaLekar.SelectedItem as Model.Pacijent;
            return pacijent;
        }

        private void MedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            Model.Pacijent IzabraniPacijent = GetSelectedPacijentZaLekar();
            if ( IzabraniPacijent != null & this.Lekar !=null )
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(Lekar, IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

      private void GlavniMeniButton(object sender, RoutedEventArgs e)
        {
            if(this.Lekar!=null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(Lekar);
                NavigationService.Navigate(refGlavniMeni);
            }
        }
    }
}
