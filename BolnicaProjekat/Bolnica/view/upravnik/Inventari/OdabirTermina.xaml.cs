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
using System.Windows.Shapes;

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for OdabirTermina.xaml
    /// </summary>
    public partial class OdabirTermina : Window
    {
        private TipOpreme tipOpreme;
        private Magacin.PrikazStaticke refPrikazStaticke = null;
        private Prostorija prostorija1;
        private Prostorija prostorija2;
        private TipProstorije tipProstorije2;
        private bool magacin;
        


        public ObservableCollection<Prostorija> KolekcijaProstorija { get; set; }
        private ProstorijeKontroler prostorijeKontroler;

        public ObservableCollection<TerminProstorije> KolekcijaTermina { get; set; }
        private TerminProstorijeKontroler terminProstorijeKontrolerObjekat;

        public OdabirTermina(Prostorija prostorija1,
                              Magacin.PrikazStaticke refPrikazStaticke,
                              TipOpreme tipOpreme)
        {
            InitializeComponent();
            prostorijeKontroler = new ProstorijeKontroler();
            terminProstorijeKontrolerObjekat = new TerminProstorijeKontroler();
            
            magacin = false;
            this.tipOpreme = tipOpreme;
            this.refPrikazStaticke = refPrikazStaticke;
            this.prostorija1 = prostorija1;
            nazivProstorije1.Text = "Prostorija: " + prostorija1.BrojSprat;

            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije2);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
                KolekcijaTermina = terminProstorijeKontrolerObjekat.GetTerminiZauzetostiByProstorijaIdObs(prostorija1.Id, prostorija2.Id);
                DataGridPrikazZauzetihTermina.ItemsSource = KolekcijaTermina;
            }


        }

        private void btn_preraspodela(object sender, RoutedEventArgs e)
        {
            TerminProstorije terminProstorije = (DataGridPrikazZauzetihTermina.SelectedItem as TerminProstorije);
            if (terminProstorije == null)
            {
                MessageBox.Show("Niste selektovali ni jedan termin premestanja");
                return;
            }

            var preraspodelaInventara = new PreraspodelaStatickeInventara(terminProstorije, refPrikazStaticke, prostorija1, prostorija2);
            preraspodelaInventara.Show();
        }

        private void btn_nazad(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboTipProstorije_DropDownClosed(object sender, EventArgs e)
        {
            //MessageBox.Show("Hej " + comboTipProstorije.Text);
            string tip = comboTipProstorije.Text;

            if (tip.Equals("Bolnicka"))
            {
                tipProstorije2 = TipProstorije.Bolnicka;
                magacin = false;
                comboProstorija.Visibility = Visibility.Visible;
                txtProstorija.Visibility = Visibility.Visible;
            }
            else if (tip.Equals("Operaciona Sala"))
            {
                tipProstorije2 = TipProstorije.OpracionaSala;
                magacin = false;
                comboProstorija.Visibility = Visibility.Visible;
                txtProstorija.Visibility = Visibility.Visible;
            }
            else if (tip.Equals("Sobe za pregled"))
            {
                tipProstorije2 = TipProstorije.SobaZaPreglede;
                magacin = false;
                comboProstorija.Visibility = Visibility.Visible;
                txtProstorija.Visibility = Visibility.Visible;
            }
            else if (tip.Equals("Bolesnicke sobe"))
            {
                tipProstorije2 = TipProstorije.BolesnickaSoba;
                magacin = false;
                comboProstorija.Visibility = Visibility.Visible;
                txtProstorija.Visibility = Visibility.Visible;
            }
            else if (tip.Equals("Magacin"))
            {
                magacin = true;
                comboProstorija.Visibility = Visibility.Hidden;
                txtProstorija.Visibility = Visibility.Hidden;
                prostorija2 = null;
                azurirajPrikaz();
                return;
            }

            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije2);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
                azurirajPrikaz();
            }
        }

        private void comboProstorija_DropDownClosed(object sender, EventArgs e)
        {
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = (Prostorija)comboProstorija.SelectedItem;
            }
            azurirajPrikaz();
        }

        private void Zakazi_click(object sender, RoutedEventArgs e)
        {
            var zakazivanjeTerminaForma = new ZakazivanjeTerminaForma(this, prostorija1, prostorija2);
            zakazivanjeTerminaForma.Show();
        }

        public void azurirajPrikaz()
        {
            if(prostorija2 == null)
            {
                KolekcijaTermina = terminProstorijeKontrolerObjekat.GetTerminiZauzetostiByProstorijaIdObs(prostorija1.Id, -1);
            }
            else
            {
                KolekcijaTermina = terminProstorijeKontrolerObjekat.GetTerminiZauzetostiByProstorijaIdObs(prostorija1.Id, prostorija2.Id);
            }
            
            DataGridPrikazZauzetihTermina.ItemsSource = KolekcijaTermina;
        }

        private void Otkazi_click(object sender, RoutedEventArgs e)
        {
            TerminProstorije terminProstorije = (DataGridPrikazZauzetihTermina.SelectedItem as TerminProstorije);
            if(terminProstorije == null)
            {
                MessageBox.Show("Niste selektovali ni jedan termin premestanja");
                return;
            }

            var rezultat = MessageBox.Show("Zelite da otkazete Termin premestanja", "Otkazivanje Termina", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (rezultat == MessageBoxResult.Yes)
            {
                terminProstorijeKontrolerObjekat.OtkaziTerminProstorije(terminProstorije);
                azurirajPrikaz();
            }
        }
    }
}
