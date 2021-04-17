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
       // public ObservableCollection<Pregled> PreglediPacijenta { get; set; }
      //  public System.Collections.ArrayList PreglediPacijentaa { get; set; }
        public Pacijent pac;
        //public Pregled odabraniPregled;

        public SopstveniPregledi()
        {
            InitializeComponent();
           // pac = Model.Bolnica.GetInstance.GetPacijent("jmbg");
          //  PreglediPacijentaa=pac.MedicinskiKarton.GetPregled();
          //  PreglediPacijenta = new ObservableCollection<Pregled>();

           // foreach(Pregled p in PreglediPacijentaa) { PreglediPacijenta.Add(p); }
           // this.listaPregledaPacijenta.
          //      ItemsSource = PreglediPacijenta;
        }


        private void pregled_odabran(object sender, MouseButtonEventArgs e)
        {
         //   odabraniPregled = listaPregledaPacijenta.SelectedItem as Pregled;
        }


        private void otkazi_pregled(object sender, RoutedEventArgs e)
        {
          //  if (odabraniPregled == null)
           // {
             //   MessageBox.Show("Odaberite pregled");
             //   return;
           // }
           // PreglediPacijenta.Remove(odabraniPregled);
           // PreglediPacijentaa.Remove(odabraniPregled);
           // pac.OtkazivanjePregleda(odabraniPregled);
           // Model.Bolnica.GetInstance.Pregledi.Add(odabraniPregled);
        }

        private void modifikuj_pregled(object sender, RoutedEventArgs e)
        {
           // if (odabraniPregled == null)
           // {
           //     MessageBox.Show("Odaberite pregled");
           //     return;
          //  }

           // var varr = new view.pacijent.PrikazPregleda(odabraniPregled);
           // varr.Show();

            listaPregledaPacijenta.Items.Refresh();

        }

        private void zakazi_novi_pregled(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.RaspoloziviPregledi();
            varr.Show();

        }
    }
}
