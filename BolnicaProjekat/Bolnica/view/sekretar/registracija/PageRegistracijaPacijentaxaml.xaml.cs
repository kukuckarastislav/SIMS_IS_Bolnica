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
using Model;
using Kontroler;
using Bolnica.utils;

namespace Bolnica.view.sekretar.registracija
{
    /// <summary>
    /// Interaction logic for PageRegistracijaPacijentaxaml.xaml
    /// </summary>
    public partial class PageRegistracijaPacijentaxaml : Page
    {
        public PageRegistracijaPacijentaxaml()
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;
            rbMusko.IsChecked = true;
            inputDatumRodjenja.SelectedDate = DateTime.Now;
        }

        private void Registruj_Pacijenta(object sender, RoutedEventArgs e)
        {
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("RegistracijaPacijenta");

            }
        }
    }
}
