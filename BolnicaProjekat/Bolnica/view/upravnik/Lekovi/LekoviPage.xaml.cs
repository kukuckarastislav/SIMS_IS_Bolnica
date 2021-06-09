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
using DTO;

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for LekoviPage.xaml
    /// </summary>
    public partial class LekoviPage : Page
    {
        private Lekovi.PrikazOdobrenihLekova refPrikazOdobrenihlekova;
        private Lekovi.PrikazNeodobrenihLekova refPrikazNeodobrenihlekova;
        private LekDTO OdabraniLek;
        private LekoviKontroler lekoviKontrolerObjekat;
        private int aktivnaGrupa = 0;  // odobreni
        public LekoviPage()
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new Kontroler.LekoviKontroler();
            refPrikazOdobrenihlekova = new Lekovi.PrikazOdobrenihLekova();
            refPrikazNeodobrenihlekova = new PrikazNeodobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazOdobrenihlekova;
            aktiviraj(0);

        }

        private void aktiviraj(int aktivan)
        {
            aktivnaGrupa = aktivan;

            Btn_prikaz_odobrene.Background = Brushes.White;
            Btn_prikaz_neodobrene.Background = Brushes.White;

            switch (aktivnaGrupa)
            {
                case 0:
                    Btn_prikaz_odobrene.Background = Brushes.LightGray;
                    refPrikazNeodobrenihlekova = null;
                    break;
                case 1:
                    Btn_prikaz_neodobrene.Background = Brushes.LightGray;
                    refPrikazOdobrenihlekova = null;
                    break;
            }
        }

        private void Btn_prikazi_odobrene(object sender, RoutedEventArgs e)
        {
            refPrikazOdobrenihlekova = new Lekovi.PrikazOdobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazOdobrenihlekova;
            aktiviraj(0);
        }

        private void Btn_prikazi_neodobrene(object sender, RoutedEventArgs e)
        {
            refPrikazNeodobrenihlekova = new Lekovi.PrikazNeodobrenihLekova();
            PovrsinaPrikazLekova.Content = refPrikazNeodobrenihlekova;
            aktiviraj(1);
        }

        private void Dodaj_lek_click(object sender, RoutedEventArgs e)
        {
            var DodajLek = new DodajLek(refPrikazNeodobrenihlekova);
            DodajLek.Show();
        }

        private void btn_izmeni_lek_Click(object sender, RoutedEventArgs e)
        {
            LekDTO lek = null;
            if (aktivnaGrupa == 0) lek = refPrikazOdobrenihlekova.GetSelectedLek();
            else if (aktivnaGrupa == 1) lek = refPrikazNeodobrenihlekova.GetSelectedLek();

            if (lek == null)
            {
                MessageBox.Show("Niste selektovali lek");
                return;
            }

            var IzmeniLek = new IzmeniLek(refPrikazNeodobrenihlekova, refPrikazOdobrenihlekova, lek);
            IzmeniLek.Show();
        }

        private void btn_obrisi_lek_Click(object sender, RoutedEventArgs e)
        {
            LekDTO lek = null;
            if (aktivnaGrupa == 0) lek = refPrikazOdobrenihlekova.GetSelectedLek();
            else if (aktivnaGrupa == 1) lek = refPrikazNeodobrenihlekova.GetSelectedLek();

            if (lek == null)
            {
                MessageBox.Show("Niste selektovali lek");
            }
            else
            {
                var rezultat = MessageBox.Show("Zelite da obrisete lek " + lek.Naziv, "Brisanje Leka", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (rezultat == MessageBoxResult.Yes)
                {
                    LekDTO dto = new LekDTO(lek.Id, lek.Sifra, lek.Naziv, lek.Odobren, lek.Opis, lek.Kolicina, lek.Cena, lek.Alergeni, lek.Revizije);
                    lekoviKontrolerObjekat.ObrisiLek(dto);
                }
            }

            if (aktivnaGrupa == 0) refPrikazOdobrenihlekova.AzurirajPrikaz();
            else if (aktivnaGrupa == 1) refPrikazNeodobrenihlekova.AzurirajPrikaz();
        }
    }
}
