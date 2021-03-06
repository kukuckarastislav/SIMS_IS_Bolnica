using Model;
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
using Kontroler;
using DTO;

namespace Bolnica.view.lekar.lekovi
{
    public partial class Lekovi : Page
    {

        private view.lekar.GlavniMeni refGlavniMeni;

        public LekarDTO LekarDTO;
        public ObservableCollection<LekDTO> odobreniLekoviKolekcija;
        public ObservableCollection<LekDTO> lekoviZaReviziju;
        public LekoviKontroler lekoviKontrolerObjekat;
        public Lekovi(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            
            List<LekDTO> lekoviLista = lekoviKontrolerObjekat.GetOdobreniLekovi();
            List<LekDTO> odobreniLekovi = lekoviKontrolerObjekat.GetOdobreniLekovi();
            LekarKontroler lekarKontroler = new LekarKontroler();
            odobreniLekoviKolekcija = new ObservableCollection<LekDTO>();
            lekoviZaReviziju= new ObservableCollection<LekDTO>();
            foreach (LekDTO lek in lekoviLista)
            {
                this.odobreniLekoviKolekcija.Add(lek);
            }
            foreach (LekDTO lek in lekarKontroler.GetLekoviZaRevizijuByIdLekara(LekarDTO.Id))
            {
                this.lekoviZaReviziju.Add(lek);
            }
            this.Odobreni_lekovi.ItemsSource = odobreniLekoviKolekcija;
            this.Lekovi_za_reviziju.ItemsSource = lekoviZaReviziju;
        }

        private void LekoviTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LekoviZaRevizijuTab.IsSelected)
            {
                PrikaziDugmad();
            }
            if (OdobreniLekoviTab.IsSelected)
            {
                SakriDugmad();
            }
        }

        private void PrikaziDugmad()
        {
            OdobravanjeLeka.Visibility = Visibility.Visible;
            OdbijanjeLeka.Visibility = Visibility.Visible;
            IzmenaLeka.Visibility = Visibility.Visible;
        }
        private void SakriDugmad()
        {
            OdobravanjeLeka.Visibility = Visibility.Collapsed;
            OdbijanjeLeka.Visibility = Visibility.Collapsed;
            IzmenaLeka.Visibility = Visibility.Collapsed;
        }


        private void GlavniMeniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
                NavigationService.Navigate(refGlavniMeni);
            }
        }



        private void IzmenaLeka_Click(object sender, RoutedEventArgs e)
        {
            LekDTO lek = (LekDTO)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var izmeniLek = new IzmenaLeka(lek, this.LekarDTO);
                NavigationService.Navigate(izmeniLek);
            }

        }

        private void OdobravanjeLeka_Click(object sender, RoutedEventArgs e)
        {
            LekDTO lek = (LekDTO)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var odobriLek = new OdobravanjeLeka(lek, this.LekarDTO);
                NavigationService.Navigate(odobriLek);
            }
        }

        private void OdbijanjeLeka_Click(object sender, RoutedEventArgs e)
        {
            LekDTO lek = (LekDTO)Lekovi_za_reviziju.SelectedItem;
            if (lek != null)
            {
                var odbijLek = new OdbijanjeLeka(lek, this.LekarDTO);
                NavigationService.Navigate(odbijLek);
            }

        }

        private void Izvestaj_Click(object sender, RoutedEventArgs e)
        {
            var izvestaj = new Izvestaj(LekarDTO);
            NavigationService.Navigate(izvestaj);

        }

        private void Statistika_Click(object sender, RoutedEventArgs e)
        {
            var statistika = new Statistika(this.LekarDTO);
            NavigationService.Navigate(statistika);
        }
    }
}
