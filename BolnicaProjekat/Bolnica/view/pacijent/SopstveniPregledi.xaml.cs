using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for SopstveniPregledi.xaml
    /// </summary>
    public partial class SopstveniPregledi : Window
    {

        public System.Collections.ArrayList PreglediPacijenta { get; set; }
        public Pacijent pac;
        public Pregled odabraniPregled;

        public SopstveniPregledi()
        {
            InitializeComponent();
            pac = Model.Bolnica.GetInstance.KT2Pacijent;
            PreglediPacijenta = pac.MedicinskiKarton.GetPregled();

            this.listaPregledaPacijenta.
                ItemsSource = PreglediPacijenta;
        }


        private void pregled_odabran(object sender, MouseButtonEventArgs e)
        {
            odabraniPregled = listaPregledaPacijenta.SelectedItem as Pregled;
        }


        private void otkazi_pregled(object sender, RoutedEventArgs e)
        {
            pac.OtkazivanjePregleda(odabraniPregled);
        }
    }
}
