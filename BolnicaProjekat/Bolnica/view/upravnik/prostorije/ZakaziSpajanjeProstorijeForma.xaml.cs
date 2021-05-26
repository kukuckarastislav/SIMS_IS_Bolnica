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

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for ZakaziSpajanjeProstorijeForma.xaml
    /// </summary>
    public partial class ZakaziSpajanjeProstorijeForma : Window
    {
        public Prostorija prostorija;
        public Prostorija prostorijaB = null;
        public PrikazTerminaProstorija refPrikazTerminaProstorija;
        private TerminProstorijeKontroler terminProstorijeKontroler;

        public ObservableCollection<Termin> KolekcijaZauzetihTermina { get; set; }

        public ObservableCollection<Prostorija> KolekcijaProstorija { get; set; }
        private ProstorijeKontroler prostorijeKontroler;


        public ZakaziSpajanjeProstorijeForma(PrikazTerminaProstorija refPrikazTerminaProstorija, Prostorija prostorija)
        {
            InitializeComponent();
            this.refPrikazTerminaProstorija = refPrikazTerminaProstorija;
            this.prostorija = prostorija;
            terminProstorijeKontroler = new TerminProstorijeKontroler();
            prostorijeKontroler = new ProstorijeKontroler();

            KolekcijaProstorija = prostorijeKontroler.getProstorijeTipObservable(prostorija.TipProstorije);
            comboProstorija.ItemsSource = KolekcijaProstorija;

            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            txtBrojProstorijeA.Text = "Broj " + prostorija.Broj;
            txtSpratProstorijeA.Text = "Sprat " + prostorija.Sprat;
            txtPovrsinaProstorijeA.Text = "Povrsina " + prostorija.Povrsina;
            KolekcijaZauzetihTermina = terminProstorijeKontroler.GetTerminiByProstorijaIdObs(prostorija.Id);
            DataGridPrikazTerminaZauzetosti.ItemsSource = KolekcijaZauzetihTermina;

        }

        private void btn_odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if(prostorija.Id == prostorijaB.Id)
            {
                MessageBox.Show("Ne mozete spojiti jednu prostoriju u jednu prostoriju");
                return;
            }

            if (DatePickerPocetak.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Pocetak termina");
                return;
            }
            if (DatePickerKraj.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Kraj termina");
                return;
            }

            DateTime tempPocetak = (DateTime)DatePickerPocetak.SelectedDate;
            DateTime tempKraj = (DateTime)DatePickerKraj.SelectedDate;

            if (tempPocetak > tempKraj)
            {
                MessageBox.Show("Kraj ne moze biti pre Pocetka");
                return;
            }
            int pocetak_h = Convert.ToInt32(comboSatiPocetak.Text);
            int pocetak_m = Convert.ToInt32(comboMinutiPocetak.Text);
            DateTime pocetak = new DateTime(tempPocetak.Year, tempPocetak.Month, tempPocetak.Day, pocetak_h, pocetak_m, 0);

            int kraj_h = Convert.ToInt32(comboSatiKraj.Text);
            int kraj_m = Convert.ToInt32(comboMinutiKraj.Text);
            DateTime kraj = new DateTime(tempKraj.Year, tempKraj.Month, tempKraj.Day, kraj_h, kraj_m, 0);

            if (pocetak >= kraj)
            {
                MessageBox.Show("Kraj ne moze biti pre Pocetka");
                return;
            }


            TransformacijaProstorijeParametri transformacijaProstorije = new TransformacijaProstorijeParametri(prostorija.TipProstorije,
                                                                                                                inputBroj.Text,
                                                                                                                Convert.ToInt32(inputSprat.Text),
                                                                                                                Convert.ToDouble(inputPovrsina.Text),
                                                                                                                prostorija.TipProstorije,
                                                                                                                "",
                                                                                                                0,
                                                                                                                0);

            bool uspesno = terminProstorijeKontroler.ZakaziTerminSpajanjaProstorije(prostorija.Id, prostorijaB.Id, pocetak, kraj, transformacijaProstorije);

            if (!uspesno)
            {
                MessageBox.Show("Termin koji ste vi uneli vec je zauzet");
                return;
            }
            refPrikazTerminaProstorija.azurirajPrikaz();
            this.Close();

        }

        private void comboProstorija_DropDownClosed(object sender, EventArgs e)
        {
            prostorijaB = (Prostorija)comboProstorija.SelectedItem;

            if(prostorijaB != null)
            {
                txtBrojProstorijeB.Text = "Broj " + prostorijaB.Broj;
                txtSpratProstorijeB.Text = "Sprat " + prostorijaB.Sprat;
                txtPovrsinaProstorijeB.Text = "Povrsina " + prostorijaB.Povrsina;

                inputPovrsina.Text = Convert.ToString(prostorijaB.Povrsina + prostorija.Povrsina);
                if(prostorija.Sprat == prostorijaB.Sprat)
                {
                    inputSprat.Text = Convert.ToString(prostorija.Sprat);
                }
            }
        }
    }
}
