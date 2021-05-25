using Bolnica.view.lekar.lekovi;
using Bolnica.view.lekar.pacijenti;
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
using System.Windows.Shapes;

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for LekarHome.xaml
    /// </summary>
    public partial class LekarHome : Window
    {

        // MENU - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekar;
        private view.lekar.lekovi.Lekovi refLekovi;
        private view.lekar.Notifikacije refNotifikacije;
        private view.lekar.GlavniMeni refGlavniMeni;
        //private view.lekar.LoginPage refLoginPage;

        public Lekar Lekar;
        public LekarHome(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

            refGlavniMeni = new view.lekar.GlavniMeni(Lekar);
            main_frame.Navigate(refGlavniMeni);


        }


        private void RadniKalendarButton(object sender, RoutedEventArgs e)
        {
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(Lekar);
            main_frame.Navigate(refRadniKalendar);

        }

        private void PacijentiButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekar = new view.lekar.pacijenti.PrikazPacijenata(Lekar);
            main_frame.Navigate(refPrikazPacijenataZaLekar);
        }


        private void LekoviButton(object sender, RoutedEventArgs e)
        {
            refLekovi = new view.lekar.lekovi.Lekovi(Lekar);
            main_frame.Navigate(refLekovi);
        }


        private void NotifikacijeButton(object sender, RoutedEventArgs e)
        {
            refNotifikacije = new view.lekar.Notifikacije(Lekar);
            main_frame.Navigate(refNotifikacije);
        }

        private void LogOutButtton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void main_frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Type pageType = e.Content.GetType();

            if (pageType == typeof(RadniKalendar) || pageType == typeof(PrikazPacijenata) || pageType == typeof(Lekovi))
            {
                menu_items_panel.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                menu_items_panel.Visibility = System.Windows.Visibility.Hidden;
            }


        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
