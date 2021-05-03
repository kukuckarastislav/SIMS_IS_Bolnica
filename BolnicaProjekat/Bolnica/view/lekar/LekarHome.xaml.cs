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
        private view.lekar.Notifikacije refNotifikacije;
        private view.lekar.LoginPage refLoginPage;

        public Lekar Lekar;
        public LekarHome(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();

            refLoginPage = new view.lekar.LoginPage(Lekar);
            main_frame.Navigate(refLoginPage);


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


        private void NotifikacijeButton(object sender, RoutedEventArgs e)
        {
            refNotifikacije = new view.lekar.Notifikacije(Lekar);
            main_frame.Navigate(refNotifikacije);
        }

        private void LogOutButtton(object sender, RoutedEventArgs e)
        {
            refLoginPage = new view.lekar.LoginPage(Lekar);
            main_frame.Navigate(refLoginPage);
        }

        private void main_frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            Type pageType = e.Content.GetType();

            if (pageType == typeof(LoginPage))
            {
                menu_items_panel.Visibility = System.Windows.Visibility.Hidden;
            }
            else
            {
                menu_items_panel.Visibility = System.Windows.Visibility.Visible;
            }


        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
