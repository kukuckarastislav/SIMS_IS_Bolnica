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

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Model.Bolnica bolnica = new Model.Bolnica("Zdravo bolnica","4", Model.Mesto.NoviSad);
            InitializeComponent();
        }

        private void Sekretar_Home_Click(object sender, RoutedEventArgs e)
        {
            var sekretar_home = new Bolnica.view.sekretar.SekretarHome();
            sekretar_home.Show();

        }

        private void Upravnik_Home_Click(object sender, RoutedEventArgs e)
        {
            var upravnik_home = new Bolnica.view.upravnik.UpravnikHome();
            upravnik_home.Show();
        }

        private void Lekar_Home_Click(object sender, RoutedEventArgs e)
        {
            var lekar_home = new Bolnica.view.lekar.LekarHome();
            lekar_home.Show();
        }

        private void Pacijent_Home_Click(object sender, RoutedEventArgs e)
        {
            var pacijent_home = new Bolnica.view.pacijent.PacijentHome();
            pacijent_home.Show();
        }
    }
}
