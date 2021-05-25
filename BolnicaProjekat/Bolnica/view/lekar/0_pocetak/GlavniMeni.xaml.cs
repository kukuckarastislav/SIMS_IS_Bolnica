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

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for GlavniMeni.xaml
    /// </summary>
    public partial class GlavniMeni : Page
    {
        // BACK - PAGES
        private view.lekar.LoginPage refLoginPage;
        // NEXT - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekar;
        private view.lekar.lekovi.Lekovi refLekovi;
        private view.lekar.Notifikacije refNotifikacije;

        // KORISNICI
        public Lekar Lekar;

        public GlavniMeni(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

        }

        private void RadniKalendarButton(object sender, RoutedEventArgs e)
        {
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(Lekar);
            NavigationService.Navigate(refRadniKalendar);

        }

        private void PacijentiButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekar = new view.lekar.pacijenti.PrikazPacijenata(Lekar);
            NavigationService.Navigate(refPrikazPacijenataZaLekar);
        }

        private void LekoviButton(object sender, RoutedEventArgs e)
        {
            refLekovi = new view.lekar.lekovi.Lekovi(Lekar);
            NavigationService.Navigate(refLekovi);

        }

        private void NotifikacijeButton(object sender, RoutedEventArgs e)
        {
            refNotifikacije = new view.lekar.Notifikacije(Lekar);
            NavigationService.Navigate(refNotifikacije);
        }

        private void LogOutButtton(object sender, RoutedEventArgs e)
        {
            refLoginPage = new view.lekar.LoginPage(Lekar);
            NavigationService.Navigate(refLoginPage);
        }


    }
}