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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private view.lekar.GlavniMeni refGlavniMeni;
        public Lekar Lekar;
        public LoginPage(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();


        }

        private void LoginButton(object sender, RoutedEventArgs e)
        {
            refGlavniMeni = new GlavniMeni(Lekar);
            NavigationService.Navigate(refGlavniMeni);
        }
    }
}
