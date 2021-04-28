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

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTerminaForma.xaml
    /// </summary>
    public partial class ZakazivanjeTerminaForma : Window
    {
        public ZakazivanjeTerminaForma()
        {
            InitializeComponent();
        }

        private void btn_odustani_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
