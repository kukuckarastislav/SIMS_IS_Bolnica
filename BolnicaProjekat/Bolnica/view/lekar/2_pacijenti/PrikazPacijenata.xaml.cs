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
using DTO;


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
        public LekarDTO LekarDTO;
        // KOLEKCIJE
        public ObservableCollection<Pacijent> KolekcijaPacijenata { get; set; }


        public PrikazPacijenata(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            KolekcijaPacijenata = PacijentRepozitorijum.GetInstance.GetAll();
            InitializeComponent();
            this.DataGridPrikazPacijenataZaLekar.ItemsSource = KolekcijaPacijenata;
  
        }

        public Pacijent GetSelectedPacijentZaLekarDTO() {
            Pacijent pacijent = DataGridPrikazPacijenataZaLekar.SelectedItem as Pacijent;
            return pacijent;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            Pacijent IzabraniPacijent = GetSelectedPacijentZaLekarDTO();
            if (IzabraniPacijent != null & this.LekarDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
                NavigationService.Navigate(refGlavniMeni);
            }
        }
    }
}
