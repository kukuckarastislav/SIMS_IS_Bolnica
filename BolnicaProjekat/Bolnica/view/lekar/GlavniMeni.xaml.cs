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
        private view.lekar.LekarHome refLekarHome;
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenataZaLekar;
        private view.lekar.Notifikacije refNotifikacije;
        public GlavniMeni(LekarHome refLekarHome)
        {
            InitializeComponent();
            this.refLekarHome = refLekarHome;

        }

        private void Pacijenti_Click(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenataZaLekar = new view.lekar.pacijenti.PrikazPacijenata();
            NavigationService.Navigate(refPrikazPacijenataZaLekar);
          //  refLekarHome.Visibility = Visibility.Visible;
        }

        private void NotifikacijeButton(object sender, RoutedEventArgs e)
        {
            refNotifikacije = new view.lekar.Notifikacije();
            NavigationService.Navigate(refNotifikacije);
        }
    }
}