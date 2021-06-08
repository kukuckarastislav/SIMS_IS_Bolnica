using Model;
using System;
using System.Collections.Generic;
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
using DTO;

namespace Bolnica.view.lekar
{
    public partial class GlavniMeni : Page
    {
        // NEXT - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekarDTO;
        private view.lekar.lekovi.Lekovi refLekovi;
        private view.lekar.FeedBack refFeedBack;

        // KORISNICI
        public LekarDTO LekarDTO;

        public GlavniMeni(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            InitializeComponent();
        }

        private void RadniKalendarButton(object sender, RoutedEventArgs e)
        {
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
            NavigationService.Navigate(refRadniKalendar);
        }

        private void PacijentiButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekarDTO = new view.lekar.pacijenti.PrikazPacijenata(LekarDTO);
            NavigationService.Navigate(refPrikazPacijenataZaLekarDTO);
        }

        private void LekoviButton(object sender, RoutedEventArgs e)
        {
            refLekovi = new view.lekar.lekovi.Lekovi(LekarDTO);
            NavigationService.Navigate(refLekovi);
        }

        private void btnFeedback_Click(object sender, RoutedEventArgs e)
        {
            refFeedBack = new view.lekar.FeedBack(LekarDTO);
            NavigationService.Navigate(refFeedBack);
        }
    }
}