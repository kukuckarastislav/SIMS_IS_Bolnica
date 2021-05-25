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

namespace Bolnica.view.lekar.lekovi
{
    /// <summary>
    /// Interaction logic for Lekovi.xaml
    /// </summary>
    public partial class Lekovi : Page
    {
        public Lekar Lekar;
        public Lekovi(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();



        }

        private void LekoviTab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LekoviZaRevizijuTab.IsSelected)
            {
                OdobravanjeLeka.Visibility = Visibility.Visible;
                OdbijanjeeLeka.Visibility = Visibility.Visible;
                IzmenaLeka.Visibility = Visibility.Visible;
            }
            if (OdobreniLekoviTab.IsSelected)
            {
                OdobravanjeLeka.Visibility = Visibility.Collapsed;
                OdbijanjeeLeka.Visibility = Visibility.Collapsed;
                IzmenaLeka.Visibility = Visibility.Collapsed;
            }
        }
    }
}
