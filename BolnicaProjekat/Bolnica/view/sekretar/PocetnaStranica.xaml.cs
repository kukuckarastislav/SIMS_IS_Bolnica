using Bolnica.utils;
using Kontroler;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PocetnaStranica.xaml
    /// </summary>
    public partial class PocetnaStranica : Page
    {
        public PocetnaStranica()
        {
            InitializeComponent();
            if (App.prikaziHelp)
                cbPomoc.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageKorisnickiNalog());
        }

        private void OcenaAplikacije_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageOcenaAplikacije());
        }

        private void cbPomoc_Click(object sender, RoutedEventArgs e)
        {
            App.prikaziHelp = (bool)cbPomoc.IsChecked;
            if(App.prikaziHelp)
            {
                App.vidljivostPomoci = Visibility.Visible;
            }else
            {
                App.vidljivostPomoci = Visibility.Hidden;
            }
        }

        private void Odjava_Click(object sender, RoutedEventArgs e)
        {
            App.glavniProzor.Visibility = Visibility.Visible;
            App.glavniProzor.resetLogin();
            App.stranicaSekretara.Close();
        }
    }
}
