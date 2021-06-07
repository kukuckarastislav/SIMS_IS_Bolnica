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
        // LISTE
        public ObservableCollection<DTORadniKalendar> KolekcijaRadniKalendar;
        // OBJEKTI
        private ZdravstvenaUslugaKontroler ObjekatZdrastvenaUslugaKontroler;
        public DTORadniKalendar OdabranaUsluga { get; set; }
        public LekarDTO LekarDTO { get; set; }

        public RadniKalendar(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            InitializeComponent();
            ObjekatZdrastvenaUslugaKontroler = new ZdravstvenaUslugaKontroler();
            BindingRadniKalendar();
        }


        private void BindingRadniKalendar()
        {
            KolekcijaRadniKalendar = new ObservableCollection<DTORadniKalendar>();
            foreach(DTORadniKalendar dtoRadni in ObjekatZdrastvenaUslugaKontroler.getUslugeLekara(LekarDTO))
            {
                KolekcijaRadniKalendar.Add(dtoRadni);
            }
            this.RadniKalendar_danasnji.ItemsSource = KolekcijaRadniKalendar;
        }

        private void RadniKalendar_danasnji_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OdabranaUsluga = RadniKalendar_danasnji.SelectedItem as DTORadniKalendar;
        }

        private void BrisanjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }

            refBrisanjeUsluge = new view.lekar.pacijenti.BrisanjeUsluge(LekarDTO, OdabranaUsluga, KolekcijaRadniKalendar);
            NavigationService.Navigate(refBrisanjeUsluge);
        }

        private void AzuriranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
            refAzuriranjeUsluge = new view.lekar.pacijenti.AzuriranjeUsluge(LekarDTO, OdabranaUsluga, KolekcijaRadniKalendar);
            NavigationService.Navigate(refAzuriranjeUsluge);
        }

        private void EvidentiranjeUsluge_Click(object sender, RoutedEventArgs e)
        {
            if (OdabranaUsluga == null)
            {
                MessageBox.Show("Odaberite uslugu!");
                return;
            }
            refEvidentiranjeUsluge = new view.lekar.pacijenti.EvidentiranjeUsluge(LekarDTO, OdabranaUsluga, KolekcijaRadniKalendar);
            NavigationService.Navigate(refEvidentiranjeUsluge);

        }

        private void GlavniMeniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
                NavigationService.Navigate(refGlavniMeni);
            }
        }

    }
}
