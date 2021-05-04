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
using Model;

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for LekoviPage.xaml
    /// </summary>
    public partial class LekoviPage : Page
    {
        private Lekovi.PrikazOdobrenihLekova refPrikazOdobrenihlekova;
        private Lekovi.PrikazNeodobrenihLekova refPrikazNeodobrenihlekova;
        private Lek OdabraniLek;
        private Kontroler.LekoviKontroler Kontroler;
        public LekoviPage()
        {
            InitializeComponent();
            Kontroler = new Kontroler.LekoviKontroler();
            refPrikazOdobrenihlekova = new Lekovi.PrikazOdobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazOdobrenihlekova;

        }

        private void DodavanjeLeka_Click(object sender, RoutedEventArgs e)
        {
            var DodajLek = new DodajLek();
            DodajLek.Show();
        }

        private void Btn_prikazi_odobrene(object sender, RoutedEventArgs e)
        {
            refPrikazOdobrenihlekova = new Lekovi.PrikazOdobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazOdobrenihlekova;
            btn_revizija_leka.Visibility = Visibility.Hidden;
        }

        private void Btn_prikazi_neodobrene(object sender, RoutedEventArgs e)
        {
            btn_revizija_leka.Visibility = Visibility.Visible;
            refPrikazNeodobrenihlekova = new Lekovi.PrikazNeodobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazNeodobrenihlekova;
        }

        private void btn_izmeni_lek_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_obrisi_lek_Click(object sender, RoutedEventArgs e)
        {
            OdabraniLek = refPrikazOdobrenihlekova.OdabraniLek;
            if (OdabraniLek != null)
            {
                Kontroler.ObrisiLek(OdabraniLek);
            }
            else
            {
                OdabraniLek = refPrikazNeodobrenihlekova.OdabraniLek;
                if (OdabraniLek != null)
                {
                    Kontroler.ObrisiLek(OdabraniLek);
                }
                else
                {
                    MessageBox.Show("Niste odabrali lek");
                }
            }

        }

        private void btn_revizija_leka_Click(object sender, RoutedEventArgs e)
        {
            OdabraniLek = refPrikazNeodobrenihlekova.OdabraniLek;
            if (OdabraniLek != null)
            {
                var OdabirLekara = new OdabirLekara(OdabraniLek);
                OdabirLekara.Show();
            }
            else
            {
                MessageBox.Show("Niste odabrali lek");
            }
        }
    }
}
