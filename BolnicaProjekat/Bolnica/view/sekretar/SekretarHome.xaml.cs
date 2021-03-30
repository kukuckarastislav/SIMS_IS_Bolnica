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

        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.registracija.PageRegistracija();
        }

        private void ListPacijenti_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PagePacijenti();
        }
    }
}
