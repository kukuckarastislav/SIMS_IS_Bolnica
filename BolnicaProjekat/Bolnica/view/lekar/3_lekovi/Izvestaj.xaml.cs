using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.lekar.lekovi
{
    public partial class Izvestaj : Page
    {
        public Lekar Lekar;
        public ObservableCollection<Lek> odobreniLekoviKolekcija;
        public LekoviKontroler lekoviKontrolerObjekat;
        public Izvestaj(Lekar Lekar)
        {
            this.Lekar = Lekar;
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            this.odobreniLekoviKolekcija = lekoviKontrolerObjekat.GetOdobreniLekovi();
            this.Odobreni_lekovi.ItemsSource = odobreniLekoviKolekcija;

        }


        private void Stampaj_Click(object sender, RoutedEventArgs e)
        {
            if (this.Lekar != null)
            {
                try
                {
                    this.IsEnabled = false;

                    Stampaj.Visibility = Visibility.Hidden;
                    BackButton.Visibility = Visibility.Hidden;

                    txtIzvestaj.Foreground = Brushes.Black;
                    txtTrenutnoOdobreniLekovi.Foreground = Brushes.Black;
                    Odobreni_lekovi.Foreground = Brushes.Black;

                    PrintDialog printDialog = new PrintDialog();
                    if(printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(print, "Invoice" );

                    }

                    Stampaj.Visibility = Visibility.Visible;
                    BackButton.Visibility = Visibility.Visible;
                    txtIzvestaj.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#eeebdd"));
                    txtTrenutnoOdobreniLekovi.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#eeebdd"));
                    Odobreni_lekovi.Foreground = new System.Windows.Media.SolidColorBrush((Color)ColorConverter.ConvertFromString("#eeebdd"));
                }
                finally
                {
                    this.IsEnabled = true;
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.Lekar != null)
            {
                var refLekovi = new view.lekar.lekovi.Lekovi(Lekar);
                NavigationService.Navigate(refLekovi);
            }

        }
    }
}
