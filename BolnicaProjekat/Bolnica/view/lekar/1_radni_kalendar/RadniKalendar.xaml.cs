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

    public partial class RadniKalendar : Page
    {


        public ObservableCollection<RadniKalendarDTO> KolekcijaDanasnjiRadniKalendar { get; set; }
        public ObservableCollection<RadniKalendarDTO> KolekcijaNedeljniRadniKalendar { get; set; }
        public ObservableCollection<RadniKalendarDTO> KolekcijaMesecniRadniKalendar { get; set; }
        private ZdravstvenaUslugaKontroler ObjekatZdrastvenaUslugaKontroler { get; set; }
        public RadniKalendarDTO OdabranaUsluga { get; set; }
        public LekarDTO LekarDTO { get; set; }

        public RadniKalendar(LekarDTO LekarDTO)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            ObjekatZdrastvenaUslugaKontroler = new ZdravstvenaUslugaKontroler();
            BindingRadniKalendar();
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
                var nextBrisanjeUsluge = new view.lekar.pacijenti.BrisanjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(nextBrisanjeUsluge);
            }
        }

        private void AzuriranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga != null)
            {
                var nextAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(nextAzuriranjeUsluge);
            }
        }

        private void EvidentiranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga != null)
            {
                var nextEvidentiranjeUsluge = new view.lekar.pacijenti.EvidentiranjeUsluge(LekarDTO, OdabranaUsluga);
                NavigationService.Navigate(nextEvidentiranjeUsluge);
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
                var backGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
                NavigationService.Navigate(backGlavniMeni);
            }
        }

    }
}
