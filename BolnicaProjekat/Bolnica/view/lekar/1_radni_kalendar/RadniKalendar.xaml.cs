using Model;
using Servis;
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
using Controller;
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for RadniKalendar.xaml
    /// </summary>
    public partial class RadniKalendar : Page
    {
        // BACK - PAGES
        private view.lekar.GlavniMeni refGlavniMeni;
        // NEXT - PAGES
        private view.lekar.pacijenti.BrisanjeUsluge refBrisanjeUsluge;
        private view.lekar.pacijenti.AzuriranjeUsluge refAzuriranjeUsluge;
        private view.lekar.pacijenti.EvidentiranjeUsluge refEvidentiranjeUsluge;
        // Kolekcije
        public ObservableCollection<RadniKalendarDTO> KolekcijaDanasnjiRadniKalendar { get; set; }
        public ObservableCollection<RadniKalendarDTO> KolekcijaNedeljniRadniKalendar { get; set; }
        public ObservableCollection<RadniKalendarDTO> KolekcijaMesecniRadniKalendar { get; set; }
        // OBJEKTI
        private ZdravstvenaUslugaKontroler ObjekatZdrastvenaUslugaKontroler;
        public RadniKalendarDTO OdabranaUsluga { get; set; }
        public LekarDTO LekarDTO { get; set; }

        public RadniKalendar(LekarDTO LekarDTO)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            ObjekatZdrastvenaUslugaKontroler = new ZdravstvenaUslugaKontroler();
            BindingRadniKalendar();
            MessageBox.Show("INSTANCIRANJE - RADNI KALENDAR PAGE");
            this.RadniKalendar_danasnji.Items.Refresh();
            this.RadniKalendar_nedeljni.Items.Refresh();
            this.RadniKalendar_mesecni.Items.Refresh();
        }


        private void PokaziDugmad()
        {
            AzuriranjeUsluge.Visibility = Visibility.Visible;
            BrisanjeUsluge.Visibility = Visibility.Visible;
            EvidentiranjeUsluge.Visibility = Visibility.Visible;
        }


        public void BindingRadniKalendar()
        {
            BindingDanasnjiRadniKalendar();
            BindingNedeljniRadniKalendar();
            BindingMesecniRadniKalendar();
        }

        public void BindingDanasnjiRadniKalendar()
        {
            KolekcijaDanasnjiRadniKalendar = new ObservableCollection<RadniKalendarDTO>();
            foreach (RadniKalendarDTO dtoRadni in ObjekatZdrastvenaUslugaKontroler.DanasnjiRadniKalendarLekara(LekarDTO))
            {
                KolekcijaDanasnjiRadniKalendar.Add(dtoRadni);
            }
            this.RadniKalendar_danasnji.ItemsSource = KolekcijaDanasnjiRadniKalendar;
        }

        public void BindingNedeljniRadniKalendar()
        {
            KolekcijaNedeljniRadniKalendar = new ObservableCollection<RadniKalendarDTO>();
            foreach (RadniKalendarDTO dtoRadni in ObjekatZdrastvenaUslugaKontroler.NedeljniRadniKalendarLekara(LekarDTO))
            {
                KolekcijaNedeljniRadniKalendar.Add(dtoRadni);
            }
            this.RadniKalendar_nedeljni.ItemsSource = KolekcijaNedeljniRadniKalendar;
        }
        public void BindingMesecniRadniKalendar()
        {
            KolekcijaMesecniRadniKalendar = new ObservableCollection<RadniKalendarDTO>();
            foreach (RadniKalendarDTO dtoRadni in ObjekatZdrastvenaUslugaKontroler.MesecniRadniKalendarLekara(LekarDTO))
            {
                KolekcijaMesecniRadniKalendar.Add(dtoRadni);
            }
            this.RadniKalendar_mesecni.ItemsSource = KolekcijaMesecniRadniKalendar;
        }

        private void BrisanjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga != null)
            {
                refBrisanjeUsluge = new view.lekar.pacijenti.BrisanjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(refBrisanjeUsluge);
            }
        }

        private void AzuriranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga != null)
            {
                refAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(refAzuriranjeUsluge);
            }
        }

        private void EvidentiranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga != null)
            {
                refEvidentiranjeUsluge = new view.lekar.pacijenti.EvidentiranjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(refEvidentiranjeUsluge);
            }
        }

        private void RadniKalendar_danasnji_MouseDoubleClick(object sender, MouseButtonEventArgs e)

        {
            OdabranaUsluga = (RadniKalendarDTO)RadniKalendar_danasnji.SelectedItem;
            if (OdabranaUsluga != null)
            {
                OdabranaUsluga = RadniKalendar_danasnji.SelectedItem as RadniKalendarDTO;
                PokaziDugmad();
            }

        }

        private void RadniKalendar_nedeljni_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OdabranaUsluga = (RadniKalendarDTO)RadniKalendar_nedeljni.SelectedItem;
            if (OdabranaUsluga != null)
            {
                OdabranaUsluga = RadniKalendar_nedeljni.SelectedItem as RadniKalendarDTO;
                PokaziDugmad();
            }

        }

        private void RadniKalendar_mesecni_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OdabranaUsluga = (RadniKalendarDTO)RadniKalendar_mesecni.SelectedItem;
            if (OdabranaUsluga != null)
            {
                OdabranaUsluga = RadniKalendar_mesecni.SelectedItem as RadniKalendarDTO;
                PokaziDugmad();
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
