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

using Model;
using Kontroler;
using System.Collections.ObjectModel;

namespace Bolnica.view.upravnik.prostorije
{
    /// <summary>
    /// Interaction logic for ZakazivanjeRazdvajanjaProstorijeForma.xaml
    /// </summary>
    public partial class ZakazivanjeRazdvajanjaProstorijeForma : Window
    {

        public Prostorija prostorija;
        public PrikazTerminaProstorija refPrikazTerminaProstorija;
        private TerminProstorijeKontroler terminProstorijeKontroler;
        public ObservableCollection<Termin> KolekcijaZauzetihTermina { get; set; }


        public ZakazivanjeRazdvajanjaProstorijeForma(PrikazTerminaProstorija refPrikazTerminaProstorija, Prostorija prostorija)
        {
            InitializeComponent();
            this.refPrikazTerminaProstorija = refPrikazTerminaProstorija;
            this.prostorija = prostorija;
            terminProstorijeKontroler = new TerminProstorijeKontroler();

            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            txtBrojProstorije.Text = "Broj " + prostorija.Broj;
            txtSpratProstorije.Text = "Sprat " + prostorija.Sprat;
            txtPovrsinaProstorije.Text = "Povrsina " + prostorija.Povrsina;
            KolekcijaZauzetihTermina = terminProstorijeKontroler.GetTerminiByProstorijaIdObs(prostorija.Id);
            DataGridPrikazTerminaZauzetosti.ItemsSource = KolekcijaZauzetihTermina;

            inputBrojA.Text = prostorija.Broj + "-A";
            inputSpratA.Text = Convert.ToString(prostorija.Sprat);
            inputPovrsinaA.Text = Convert.ToString(prostorija.Povrsina / 2);

            inputBrojB.Text = prostorija.Broj + "-B";
            inputSpratB.Text = Convert.ToString(prostorija.Sprat);
            inputPovrsinaB.Text = Convert.ToString(prostorija.Povrsina / 2);
        }

        private void btn_odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
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
                                                                                                                inputBrojA.Text,
                                                                                                                Convert.ToInt32(inputSpratA.Text),
                                                                                                                Convert.ToDouble(inputPovrsinaA.Text),
                                                                                                                prostorija.TipProstorije,
                                                                                                                inputBrojB.Text,
                                                                                                                Convert.ToInt32(inputSpratB.Text),
                                                                                                                Convert.ToDouble(inputPovrsinaB.Text));

            bool uspesno = terminProstorijeKontroler.ZakaziTerminRazdvajanjaProstorije(prostorija.Id, pocetak, kraj, transformacijaProstorije);

            if (!uspesno)
            {
                MessageBox.Show("Termin koji ste vi uneli vec je zauzet");
                return;
            }
            refPrikazTerminaProstorija.azurirajPrikaz();
            this.Close();

        }


    }
}
