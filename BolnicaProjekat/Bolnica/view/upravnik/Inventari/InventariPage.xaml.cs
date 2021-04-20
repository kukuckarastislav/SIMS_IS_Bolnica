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
using System.Collections.ObjectModel;


namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for InventariPage.xaml
    /// </summary>
    public partial class InventariPage : Page
    {

        public TipProstorije tipProstorije;
        public TipOpreme tipOpreme;
        public int aktivnaGrupa;
        public ObservableCollection<Prostorija> KolekcijaProstorija { get; set; }
        private InventariKontroler inventarKontroler;
        private ProstorijeKontroler prostorijeKontroler;

        private Magacin.PrikazStaticke refPrikazStaticke;
        private Magacin.PrikazDinamicke refPrikazDinamicke;

        private Prostorija prostorija;
        public InventariPage()
        {
            inventarKontroler = new InventariKontroler();
            prostorijeKontroler = new ProstorijeKontroler();
            InitializeComponent();
            tipProstorije = TipProstorije.Bolnicka;
            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
                aktiviraj(0);
                refPrikazStaticke = new Magacin.PrikazStaticke(prostorija.Id);
                PovrsinaPrikazInventara.Content = refPrikazStaticke;
            }
                
        }

        private void Btn_prikazi_staticku(object sender, RoutedEventArgs e)
        {
            aktiviraj(0);
            refPrikazStaticke = new Magacin.PrikazStaticke(prostorija.Id);
            PovrsinaPrikazInventara.Content = refPrikazStaticke;
        }
        private void Btn_prikazi_dinamicku(object sender, RoutedEventArgs e)
        {
            aktiviraj(1);
            refPrikazDinamicke = new Magacin.PrikazDinamicke(prostorija.Id);
            PovrsinaPrikazInventara.Content = refPrikazDinamicke;
        }

        private void Btn_prikazi_lekovi(object sender, RoutedEventArgs e)
        {
            // za sada nista
        }

        private void Preraspodela_click(object sender, RoutedEventArgs e)
        {

        }

        private void Termini_click(object sender, RoutedEventArgs e)
        {

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


        private void comboTipProstorije_DropDownClosed(object sender, EventArgs e)
        {
            //MessageBox.Show("Hej " + comboTipProstorije.Text);
            string tip = comboTipProstorije.Text;

            if (tip.Equals("Bolnicka"))
            {
                tipProstorije = TipProstorije.Bolnicka;
            }
            else if (tip.Equals("Operaciona Sala"))
            {
                tipProstorije = TipProstorije.OpracionaSala;
            }
            else if (tip.Equals("Sobe za pregled"))
            {
                tipProstorije = TipProstorije.SobaZaPreglede;
            }
            else if (tip.Equals("Bolesnicke sobe"))
            {
                tipProstorije = TipProstorije.BolesnickaSoba;
            }

            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
            }
        }

        private void comboProstorija_DropDownClosed(object sender, EventArgs e)
        {
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija = (Prostorija)comboProstorija.SelectedItem;
                //MessageBox.Show("nova prostorija je " + prostorija.BrojSprat);
            }
        }


    }
}
