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

namespace Bolnica.view.sekretar.wizard
{
    /// <summary>
    /// Interaction logic for WizardLekari.xaml
    /// </summary>
    public partial class WizardLekari : Page
    {
        public WizardLekari()
        {
            InitializeComponent();
        }

        private void btnSledeca_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new view.sekretar.wizard.WizardTermini());
        }

        private void btnZatvori_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new view.sekretar.PocetnaStranica());
            App.jelPrvoPokretanjeAplikacije = false;
        }

        private void btnPrethodna_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new view.sekretar.wizard.WizardPacijenti());
        }
    }
}
