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

        public OdabirTermina(Prostorija prostorija1,
                              Magacin.PrikazStaticke refPrikazStaticke,
                              TipOpreme tipOpreme)
        {
            prostorijeKontroler = new ProstorijeKontroler();
            InitializeComponent();
            magacin = false;
            
            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije2);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
            }

            this.tipOpreme = tipOpreme;
            this.refPrikazStaticke = refPrikazStaticke;
            this.prostorija1 = prostorija1;
            nazivProstorije1.Text = "Prostorija: " + prostorija1.BrojSprat;
        }

        private void btn_preraspodela(object sender, RoutedEventArgs e)
        {
            var preraspodelaInventara = new PreraspodelaStatickeInventara(refPrikazStaticke, null,
                                                        tipOpreme, 0, prostorija1.IdInventar);
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
                return;
            }

            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(tipProstorije2);
            comboProstorija.ItemsSource = KolekcijaProstorija;
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = KolekcijaProstorija[0];
                comboProstorija.SelectedValue = KolekcijaProstorija[0];
            }
        }

        private void comboProstorija_DropDownClosed(object sender, EventArgs e)
        {
            if (KolekcijaProstorija != null && KolekcijaProstorija.Count > 0)
            {
                prostorija2 = (Prostorija)comboProstorija.SelectedItem;
            }
        }

    }
}
