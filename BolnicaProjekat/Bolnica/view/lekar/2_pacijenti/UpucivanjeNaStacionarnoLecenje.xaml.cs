using Model;
using Kontroler;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for UpucivanjeNaStacionarnoLecenje.xaml
    /// </summary>
    public partial class UpucivanjeNaStacionarnoLecenje : Page
    {

        public Lekar Lekar { get; set; }
        public Pacijent IzabraniPacijent { get; set; }
        public DateTime PocetakHospitalizacije;
        public DateTime ZavrsetakHospitalizacije;
        public ObservableCollection<Prostorija> BolesnickeSobe;
        public ProstorijeKontroler objekatProstorijeKontroler;
        public DateTime AzuriranPocetak { get; set; }
        public DateTime AzuriranKraj { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;

        public UpucivanjeNaStacionarnoLecenje(Lekar Lekar, Pacijent IzabraniPacijent)
        {
            InitializeComponent();
            this.Lekar = Lekar;
            this.IzabraniPacijent = IzabraniPacijent;
            InicijalizujObjekte();
            UcitajPodatke();
        }

        public void InicijalizujObjekte()
        {
            objekatProstorijeKontroler = new ProstorijeKontroler();
            BolesnickeSobe = new ObservableCollection<Prostorija>();
            BolesnickeSobe = objekatProstorijeKontroler.getProstorijeTipObservable(TipProstorije.BolesnickaSoba);
        }
        public void UcitajPodatke()
        {
            lblHospitalizacija.Text = (IzabraniPacijent.Hospitalizovan) ? "Da" : "Ne";
            lblProstorija.Text = "N\\A";
            lblPocetkaHospitalizacije.Text = "N\\A";
            lblZavrsetkaHostpitalizacije.Text = "N\\A";
            cmbBolesnickeSobe.ItemsSource = BolesnickeSobe;

            KreirajIspravanKalendar();
        }

        private void KreirajIspravanKalendar()
        {
            CalendarDateRange proslost = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            kalPocetakHospitalizacije.BlackoutDates.Add(proslost);
            kalZavrsetakHospitalizacije.BlackoutDates.Add(proslost);
        }



        private void IspisiAzuriranoStanje()
        {
            DateTime azuriranPocetak = IzracunajPocetakHospitalizacije();
            DateTime azuriranKraj = IzracunajZavrsetakHospitalizacije();
            string vremeHospitalizacije = (NapraviStringAzuriranoVreme(azuriranPocetak, azuriranKraj));
            string prostorija = ((Prostorija)cmbBolesnickeSobe.SelectedItem).BrojSprat;
            txtAzuriranoStanje.Text = "Hospitalizacija: " + "\n" + vremeHospitalizacije + "\n     u " + prostorija + " prostoriji";

        }


        private DateTime IzracunajPocetakHospitalizacije()
        {
            int pocetakHospitalizacije_Sat = Convert.ToInt32(cmbPocetakHospitalizacije_Sat.Text);
            int pocetakHospitalizacije_Min = Convert.ToInt32(cmbPocetakHospitalizacije_Min.Text);
            DateTime pocetakSelektovanDate = kalPocetakHospitalizacije.SelectedDate.Value;
            DateTime azuriranPocetakHospitalizacije = new DateTime(pocetakSelektovanDate.Year,
                                                                   pocetakSelektovanDate.Month,
                                                                   pocetakSelektovanDate.Day,
                                                                   pocetakHospitalizacije_Sat,
                                                                   pocetakHospitalizacije_Min, 0);
            return azuriranPocetakHospitalizacije;
        }
        private DateTime IzracunajZavrsetakHospitalizacije()
        {
            int zavrsetakHospitalizacije_Sat = Convert.ToInt32(cmbZavrsetakHospitalizacije_Sat.Text);
            int zavrsetakHospitalizacije_Min = Convert.ToInt32(cmbZavrsetakHospitalizacije_Min.Text);
            DateTime zavrsetakSelektovanDate = kalZavrsetakHospitalizacije.SelectedDate.Value;
            DateTime azuriranZavrsetakHospitalizacije = new DateTime(zavrsetakSelektovanDate.Year,
                                                                     zavrsetakSelektovanDate.Month,
                                                                     zavrsetakSelektovanDate.Day,
                                                                     zavrsetakHospitalizacije_Sat,
                                                                     zavrsetakHospitalizacije_Min, 0);
            return azuriranZavrsetakHospitalizacije;

        }

        private string NapraviStringAzuriranoVreme(DateTime azuriranPocetak, DateTime azuriranKraj)
        {
            this.AzuriranPocetak = azuriranPocetak;
            this.AzuriranKraj = azuriranKraj;
            return "Od " + azuriranPocetak.ToString("MM / dd / yyyy") + " - " + azuriranPocetak.ToString("HH:mm:ss") + "\n" +
                   "Do " + azuriranKraj.ToString("MM / dd / yyyy") + " - " + azuriranKraj.ToString("HH:mm:ss");
        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(Lekar, IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private bool SveJePopunjen()
        {
            if (kalPocetakHospitalizacije.SelectedDate != null &&
                cmbPocetakHospitalizacije_Sat.SelectedItem != null &&
                cmbPocetakHospitalizacije_Min.SelectedItem != null &&

                kalZavrsetakHospitalizacije.SelectedDate != null &&
                cmbZavrsetakHospitalizacije_Sat.SelectedItem != null &&
                cmbZavrsetakHospitalizacije_Min.SelectedItem != null &&

                cmbBolesnickeSobe.SelectedItem != null)
            {
                return true;
            }
            return false;
        }

        private void kalPocetakHospitalizacije_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }

        private void cmbPocetakHospitalizacije_Sat_DropDownClosed(object sender, EventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }

        private void cmbPocetakHospitalizacije_Min_DropDownClosed(object sender, EventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }

        private void kalZavrsetakHospitalizacije_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }

        private void cmbZavrsetakHospitalizacije_Sat_DropDownClosed(object sender, EventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }

        }

        private void cmbZavrsetakHospitalizacije_Min_DropDownClosed(object sender, EventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }

        private void cmbBolesnickeSobe_DropDownClosed(object sender, EventArgs e)
        {
            if (SveJePopunjen())
            {
                IspisiAzuriranoStanje();
            }
        }
    }
}
