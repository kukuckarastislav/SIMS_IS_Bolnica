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
using Kontroler;
using DTO;


namespace Bolnica.view.lekar.pacijenti
{

    public partial class PrikazPacijenata : Page
    {
        private view.lekar.GlavniMeni refGlavniMeni;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;
        private PacijentKontroler ObjekatPacijentKontroler;
        public LekarDTO LekarDTO;
        public ObservableCollection<PacijentDTO> KolekcijaPacijenata { get; set; }


        public PrikazPacijenata(LekarDTO LekarDTO)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            ObjekatPacijentKontroler = new PacijentKontroler();
            KolekcijaPacijenata = ObjekatPacijentKontroler.GetPacijentiDto();
            this.DataGridPrikazPacijenataZaLekar.ItemsSource = KolekcijaPacijenata;

        }

        public PacijentDTO GetSelectedPacijentZaLekarDTO()
        {
            PacijentDTO pacijent = DataGridPrikazPacijenataZaLekar.SelectedItem as PacijentDTO;
            return pacijent;
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            PacijentDTO IzabraniPacijent = GetSelectedPacijentZaLekarDTO();
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
