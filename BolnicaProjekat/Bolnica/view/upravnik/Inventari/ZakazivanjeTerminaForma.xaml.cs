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

using Model;
using Kontroler;

namespace Bolnica.view.upravnik.Inventari
{
    /// <summary>
    /// Interaction logic for ZakazivanjeTerminaForma.xaml
    /// </summary>
    public partial class ZakazivanjeTerminaForma : Window
    {

        private TerminProstorijeKontroler terminProstorijeKontroler;
        public ObservableCollection<Termin> KolekcijaZauzetihTermina { get; set; }
        public Prostorija prostorija1;
        public Prostorija prostorija2;
        private bool isMagacin;
        private OdabirTermina odabirTermina;

        public ZakazivanjeTerminaForma(OdabirTermina odabirTermina, Prostorija prostorija1, Prostorija prostorija2)
        {
            InitializeComponent();
            terminProstorijeKontroler = new TerminProstorijeKontroler();
            this.odabirTermina = odabirTermina;
            this.prostorija1 = prostorija1;
            this.prostorija2 = prostorija2;
            if(prostorija2 == null)
            {
                isMagacin = true;
                KolekcijaZauzetihTermina = terminProstorijeKontroler.GetTerminiByProstorijaIdObs(prostorija1.Id);
                txtNaziProstorije.Text = "Prostorija " + prostorija1.BrojSprat;
            }
            else
            {
                isMagacin = false;
                KolekcijaZauzetihTermina = terminProstorijeKontroler.GetUnijaTerminaByProstorijaIdObs(prostorija1.Id, prostorija2.Id);
                txtNaziProstorije.Text = "Prostorija " + prostorija1.BrojSprat + "  i  " + prostorija2.BrojSprat; 
            }

            if(KolekcijaZauzetihTermina == null)
            {
                MessageBox.Show("JOOOJ");
            }
            DataGridPrikazTerminaZauzetosti.ItemsSource = KolekcijaZauzetihTermina;



        }

        private void btn_odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_potvrdi_Click(object sender, RoutedEventArgs e)
        {
            if(DatePickerPocetak.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Pocetak termina");
                return;
            } 
            if(DatePickerKraj.SelectedDate == null)
            {
                MessageBox.Show("Niste uneli Kraj termina");
                return;
            }

            DateTime tempPocetak = (DateTime)DatePickerPocetak.SelectedDate;
            DateTime tempKraj = (DateTime)DatePickerKraj.SelectedDate;

            if(tempPocetak > tempKraj)
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

            if(pocetak >= kraj)
            {
                MessageBox.Show("Kraj ne moze biti pre Pocetka");
                return;
            }

            //MessageBox.Show(pocetak.ToString() + "    " + kraj.ToString());

            bool uspesno = false;
            if (isMagacin)
            {
                uspesno = terminProstorijeKontroler.ZakaziTerminPremestanjaProstorije(prostorija1.Id, -1, TipTerminaProstorije.PreraspodelaInventaraPiM, pocetak, kraj);
            }
            else
            {
                uspesno = terminProstorijeKontroler.ZakaziTerminPremestanjaProstorije(prostorija1.Id, prostorija2.Id, TipTerminaProstorije.PreraspodelaInventaraPiP, pocetak, kraj);
            }


            if (!uspesno)
            {
                MessageBox.Show("Termin koji ste vi uneli vec je zauzet");
                return;
            }
            odabirTermina.azurirajPrikaz();
            this.Close();

        }
    }
}
