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
using System.Threading;
using Kontroler;
using Servis;
using DTO;

namespace Bolnica.view.upravnik
{
    public partial class UpravnikHome : Window
    {

        Thread preraspodelaInventaraThread;
        private TerminProstorijeServis terminProstorijeServisObjekat;
        
        public UpravnikHome()
        {
            InitializeComponent();
            terminProstorijeServisObjekat = new TerminProstorijeServis();
            preraspodelaInventaraThread = new Thread(new ThreadStart(terminProstorijeServisObjekat.ThreadPreraspodelaInventara));
            preraspodelaInventaraThread.IsBackground = true;
            preraspodelaInventaraThread.Start();

            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr");

            RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
        }

        private void Prostorije_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
        }

        private void Inventari_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.Inventari.InventariPage();
        }

        private void Magacin_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.Magacin.MagacinPage();
        }

        private void Lekovi_Click(object sender, RoutedEventArgs e)
        {
           RadnaPovrsina.Content = new view.upravnik.Lekovi.LekoviPage();
        }

        private void Ocene_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.Ocene.OcenePage();
        }

        private void Podesavanje_Click(object sender, RoutedEventArgs e)
        {
            LokalDTO lok = new LokalDTO(btnProstorije,btnInventar,btnMagacin,btnLekovi,btnOcene,btnIzvestaj,btnPodesavanje, btnOdjaviSe);
            RadnaPovrsina.Content = new view.upravnik.Podesavanje.PodesavanjePage(lok);
        }

        private void Odjavi_se_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Izvestaj_Click(object sender, RoutedEventArgs e)
        {
            //RadnaPovrsina.Content = new view.upravnik.Podesavanje.PodesavanjePage();
            var izvestaj = new view.upravnik.Izvestaj.IzvestajRadaLekaraWin();
            izvestaj.Show();
        }
    }
}
