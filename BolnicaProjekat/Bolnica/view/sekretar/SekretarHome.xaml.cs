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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for SekretarHome.xaml
    /// </summary>
    public partial class SekretarHome : Window
    {
        public SekretarHome()
        {
            InitializeComponent();
            RadnaPovrsina.Content = new view.sekretar.PagePacijenti();
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PocetnaStranica();
        }
        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.registracija.PageRegistracija();
        }
        private void RegistracijaLekara_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.registracija.RegistracijaLekara();
        }

        private void ListPacijenti_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PagePacijenti();
        }
        private void ListLekara_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageLekari();
        }
        private void ListObavestenja_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageObavestenja();
        }
        private void ZauzetostProstorija_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.ZauzetostProstorija();
        }
    }
}
