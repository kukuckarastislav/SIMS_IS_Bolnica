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

namespace Bolnica.view.upravnik
{
    /// <summary>
    /// Interaction logic for UpravnikHome.xaml
    /// </summary>
    public partial class UpravnikHome : Window
    {
        public UpravnikHome()
        {
            InitializeComponent();
            //RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
        }

        private void Prostorije_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
        }
    }
}
