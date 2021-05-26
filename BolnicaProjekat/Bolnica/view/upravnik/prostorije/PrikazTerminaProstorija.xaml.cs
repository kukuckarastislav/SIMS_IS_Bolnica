using Model;
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
using DTO;
using System.Collections.ObjectModel;
using Kontroler;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for PrikazTerminaProstorija.xaml
    /// </summary>
    public partial class PrikazTerminaProstorija : Window
    {

        private ObservableCollection<TerminProstorijeDTO> kolekcijaTerminaDTO;
        public TerminProstorijeKontroler terminProstorijeKontrolerObjekat;


        private Prostorija prostorija;
        public PrikazTerminaProstorija(Prostorija prostorija)
        {
            InitializeComponent();

            this.prostorija = prostorija;
            nazivProstorije.Text = "Prostorija " + prostorija.BrojSprat;

            terminProstorijeKontrolerObjekat = new TerminProstorijeKontroler();
            kolekcijaTerminaDTO = terminProstorijeKontrolerObjekat.GetTerminiProstorijeDTOobsByProstorija(prostorija);
            DataGridPrikazZauzetihTermina.ItemsSource = kolekcijaTerminaDTO;

        }

        public void azurirajPrikaz()
        {
            kolekcijaTerminaDTO = terminProstorijeKontrolerObjekat.GetTerminiProstorijeDTOobsByProstorija(prostorija);
            DataGridPrikazZauzetihTermina.ItemsSource = kolekcijaTerminaDTO;
        }

        private void Zakazi_Termin(object sender, RoutedEventArgs e)
        {
            var zakazivanjeTerminaRenoviranja = new ZakazivanjeTerminaRenoviranjaForma(this, prostorija);
            zakazivanjeTerminaRenoviranja.Show();
        }

        private void Otkazi_Termin(object sender, RoutedEventArgs e)
        {
            TerminProstorijeDTO tpDTO = (DataGridPrikazZauzetihTermina.SelectedItem as TerminProstorijeDTO);
            if(tpDTO == null)
            {
                MessageBox.Show("Niste selektovali ni jedan termin");
                return;
            }

            if(tpDTO.terminProstorijeRef.tipTerminaProstorije != TipTerminaProstorije.Renoviranje)
            {
                MessageBox.Show("Mozete otkazati samo termine Renoviranja");
                return;
            }

            var rezultat = MessageBox.Show("Zelite da otkazete Termin Renoviranja", "Otkazivanje Termina", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rezultat == MessageBoxResult.Yes)
            {
                terminProstorijeKontrolerObjekat.OtkaziTerminProstorije(tpDTO.terminProstorijeRef);
                azurirajPrikaz();
            }
        }

        private void btn_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Spajanje_click(object sender, RoutedEventArgs e)
        {
            var zakazivanjeSpajanjaProstorijeForma = new ZakaziSpajanjeProstorijeForma(this, prostorija);
            zakazivanjeSpajanjaProstorijeForma.Show();
        }

        private void Razdvajanje_click(object sender, RoutedEventArgs e)
        {
            var zakazivanjeRazdvajanjaProstorijeForma = new ZakazivanjeRazdvajanjaProstorijeForma(this, prostorija);
            zakazivanjeRazdvajanjaProstorijeForma.Show();
        }
    }
}
