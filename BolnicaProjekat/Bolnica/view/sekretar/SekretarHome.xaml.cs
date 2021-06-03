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
            RadnaPovrsina.Content = new view.sekretar.PocetnaStranica();
            btnPocetnaStranica.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }

        private void PocetnaStranica_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PocetnaStranica();
            ResetButtonColor();
            btnPocetnaStranica.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }
        private void Registracija_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.registracija.PageRegistracijaPacijentaxaml();
            ResetButtonColor();
            btnRegistracijaPacijenta.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }
        private void RegistracijaLekara_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.registracija.RegistracijaLekara();
            ResetButtonColor();
            btnRegistracijaLekara.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }

        private void ListPacijenti_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageListaPacijenata();
            ResetButtonColor();
            btnListaPacijenata.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }
        private void ListLekara_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageLekari();
            ResetButtonColor();
            btnListaLekara.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }
        private void ListObavestenja_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageObavestenja();
            ResetButtonColor();
            btnObavestenja.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }
        private void ZauzetostProstorija_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.ZauzetostProstorija();
            ResetButtonColor();
            btnZauzetostProstorija.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }

        private void ZakazaniTermini_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.sekretar.PageZakazaniTermini();
            ResetButtonColor();
            btnZakaziTermin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#ccffbd"));
        }

        private void ResetButtonColor()
        {
            btnPocetnaStranica.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnRegistracijaPacijenta.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnRegistracijaLekara.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnListaPacijenata.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnListaLekara.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnObavestenja.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnZauzetostProstorija.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
            btnZakaziTermin.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#7eca9c"));
        }
    }
}
