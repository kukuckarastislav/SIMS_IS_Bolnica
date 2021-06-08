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
using DTO;

namespace Bolnica.view.lekar
{
    /// <summary>
    /// Interaction logic for LekarDTOHome.xaml
    /// </summary>
    public partial class LekarHome : Window
    {

        // MENU - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekarDTO;
        private view.lekar.lekovi.Lekovi refLekovi;
        private view.lekar.GlavniMeni refGlavniMeni;
        //private view.lekar.LoginPage refLoginPage;

        public LekarDTO LekarDTO;
        public LekarHome(LekarDTO LekarDTO)
        {
            this.LekarDTO = LekarDTO;
            InitializeComponent();

            refGlavniMeni = new view.lekar.GlavniMeni(LekarDTO);
            main_frame.Navigate(refGlavniMeni);


        }


        private void RadniKalendarButton(object sender, RoutedEventArgs e)
        {
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
            main_frame.Navigate(refRadniKalendar);

        }

        private void PacijentiButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekarDTO = new view.lekar.pacijenti.PrikazPacijenata(LekarDTO);
            main_frame.Navigate(refPrikazPacijenataZaLekarDTO);
        }


        private void LekoviButton(object sender, RoutedEventArgs e)
        {
            refLekovi = new view.lekar.lekovi.Lekovi(LekarDTO);
            main_frame.Navigate(refLekovi);
        }


        private void LogOutButtton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void main_frame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
         
            menu_items_panel.Visibility = System.Windows.Visibility.Hidden;
     
        }

        private void close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }
}
