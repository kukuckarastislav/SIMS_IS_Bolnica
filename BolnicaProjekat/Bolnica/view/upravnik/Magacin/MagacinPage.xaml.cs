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
using Kontroler;

namespace Bolnica.view.upravnik.Magacin
{
    /// <summary>
    /// Interaction logic for MagacinPage.xaml
    /// </summary>
    public partial class MagacinPage : Page
    {

        private int aktivnaGrupa = 0;  // staticka?
        private TipOpreme tipOpreme = TipOpreme.Staticka;

        private PrikazStaticke refPrikazStaticke = null;
        private PrikazDinamicke refPrikazDinamiceke = null;

        private InventariKontroler inventarKontroler;

        public MagacinPage()
        {
            inventarKontroler = new InventariKontroler();
            InitializeComponent();
            aktiviraj(0); // staitkcu
            refPrikazStaticke = new PrikazStaticke();
            PovrsinaPrikazMagacina.Content = refPrikazStaticke;
        }

        private void aktiviraj(int akt)
        {
            aktivnaGrupa = akt;

            Btn_prikaz_staticku.Background = Brushes.White;
            Btn_prikaz_dinamicku.Background = Brushes.White;
            Btn_prikaz_lekovi.Background = Brushes.White;
            
            switch (aktivnaGrupa)
            {
                case 0:
                    tipOpreme = TipOpreme.Staticka;
                    Btn_prikaz_staticku.Background = Brushes.LightGray;
                    break;
                case 1:
                    tipOpreme = TipOpreme.Dinamicka;
                    Btn_prikaz_dinamicku.Background = Brushes.LightGray;
                    break;
                case 2:
                    Btn_prikaz_lekovi.Background = Brushes.LightGray;
                    break;

            }
        }

        private void Dodaj_u_mag(object sender, RoutedEventArgs e)
        {
            

            if (aktivnaGrupa == 0)
            {
                // dodaj staticke opreme
                var dodajOpremu = new DodajOpremuUMagForma(refPrikazStaticke, null, tipOpreme);
                dodajOpremu.Show();
            }else if(aktivnaGrupa == 1)
            {
                // dodaj dinamicku opremu
                var dodajOpremu = new DodajOpremuUMagForma(null, refPrikazDinamiceke, tipOpreme);
                dodajOpremu.Show();
            }
        }

        private void Izmeni_u_mag(object sender, RoutedEventArgs e)
        {

        }

        private void Obrisi_u_mag(object sender, RoutedEventArgs e)
        {
            Oprema op = null;
            if (aktivnaGrupa == 0) op = refPrikazStaticke.GetSelectedOprema();
            else if (aktivnaGrupa == 1) op = refPrikazDinamiceke.GetSelectedOprema();

            if (op == null)
            {
                MessageBox.Show("Niste selektovali opremu");
            }
            else
            {
                var rezultat = MessageBox.Show("Zelite da obrisete opremu " + op.Naziv, "Brisanje Prostorije", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    inventarKontroler.ObrisiOpremuInvetara(0, op, false);  // brisanje opreme op u invetaru 0 to je magacin
                    
                }
            }

            if (aktivnaGrupa == 0) refPrikazStaticke.azurirajPrikaz();
            else if (aktivnaGrupa == 1) refPrikazDinamiceke.azurirajPrikaz();
        }


        private void Btn_prikazi_staticku(object sender, RoutedEventArgs e)
        {
            aktiviraj(0);
            refPrikazStaticke = new PrikazStaticke();
            PovrsinaPrikazMagacina.Content = refPrikazStaticke;
        }

        private void Btn_prikazi_dinamicku(object sender, RoutedEventArgs e)
        {
            aktiviraj(1);
            refPrikazDinamiceke = new PrikazDinamicke();
            PovrsinaPrikazMagacina.Content = refPrikazDinamiceke;
        }

        private void Btn_prikazi_lekove(object sender, RoutedEventArgs e)
        {
            aktiviraj(2);
            
        }
    }
}
