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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for AzuriranjeUsluge.xaml
    /// </summary>
    public partial class AzuriranjeUsluge : Page
    {

        // BACK - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;

        public int h;
        public int m;
        public Lekar Lekar { get; set; }
        public ObservableCollection<DTORadniKalendar> ListaRadniKalendar { get; set; }
        public DTORadniKalendar OdabranaUsluga { get; set; }
        public DTORadniKalendar AzuriranaUsluga { get; set; }
        public DateTime azuriran_pocetak { get; set; }
        public DateTime azuriran_kraj { get; set; }

        public AzuriranjeUsluge(Lekar Lekar, DTORadniKalendar OdabranaUsluga, ObservableCollection<DTORadniKalendar> ListaRadniKalendar)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.ListaRadniKalendar = ListaRadniKalendar;
            this.Lekar = Lekar;

            ImePacijenta.Text = "Pacijent: " + OdabranaUsluga.ImePacijenta.ToString();
            TipUsluge.Text = OdabranaUsluga.Usluga.TipUsluge.ToString();
            Prostorija.Text = OdabranaUsluga.NazivProstorije.ToString();
            VremePocetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Pocetak.ToString("MM/dd/yyyy HH:mm:ss");
            VremeZavrsetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Kraj.ToString("MM/dd/yyyy HH:mm:ss");
            RazlogZakazivanja.Text = OdabranaUsluga.Usluga.RazlogZakazivanja.ToString();


            CalendarDateRange proslost = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            Kalendar_pomeri_dan_termina.BlackoutDates.Add(proslost);

        }

        private void PotvrdiAzuriranjeButton(object sender, RoutedEventArgs e)
        {
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.AzurirajVremeUsluga(OdabranaUsluga.Usluga, azuriran_pocetak, azuriran_kraj);
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(Lekar);
            NavigationService.Navigate(refRadniKalendar);


        }

        private void OdustaniButton(object sender, RoutedEventArgs e)
        {
            if (this.Lekar != null)
            {
                refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(Lekar);
                NavigationService.Navigate(refRadniKalendar);
            }
        }

        private void Kalendar_pomeri_dan_termina_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VremePocetakTermina_Sat.SelectedValue!=null && VremePocetakTermina_Minut.SelectedValue != null && Kalendar_pomeri_dan_termina.SelectedDate != null)
            {
                int sati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
                int minute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
                DateTime datum = Kalendar_pomeri_dan_termina.SelectedDate.Value;

                DateTime azuriran_pocetak = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute, 0);
                DateTime azuriran_kraj = new DateTime();
                if (minute != 30)
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute + 30, 0);
                }
                else
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati + 1, minute -30, 0);
                }


                AzuriranoVreme.Text = (azurirajVreme(azuriran_pocetak,azuriran_kraj));


            }
            return;
        }

        private string azurirajVreme(DateTime azuriran_pocetak, DateTime azuriran_kraj)
        {
            this.azuriran_pocetak = azuriran_pocetak;
            this.azuriran_kraj = azuriran_kraj;
            return azuriran_pocetak.ToString("MM / dd / yyyy") + "\n" + "Od " + azuriran_pocetak.ToString("HH:mm:ss") + "\n" + "Do " + azuriran_kraj.ToString("HH:mm:ss");
        }

        private void VremePocetakTermina_Sat_DropDownClosed(object sender, EventArgs e)
        {
            if (Kalendar_pomeri_dan_termina.SelectedDate != null)
            {
                int sati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
                int minute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
                DateTime datum = Kalendar_pomeri_dan_termina.SelectedDate.Value;

                DateTime azuriran_pocetak = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute, 0);
                DateTime azuriran_kraj = new DateTime();
                if (minute != 30)
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute + 30, 0);
                }
                else
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati + 1, minute - 30, 0);
                }

                AzuriranoVreme.Text = (azurirajVreme(azuriran_pocetak, azuriran_kraj));

            }
            return;

        }

        private void VremePocetakTermina_Minut_DropDownClosed(object sender, EventArgs e)
        {


            if (Kalendar_pomeri_dan_termina.SelectedDate != null)
            {
                int sati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
                int minute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
                DateTime datum = Kalendar_pomeri_dan_termina.SelectedDate.Value;

                DateTime azuriran_pocetak = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute, 0);
                DateTime azuriran_kraj = new DateTime();
                if (minute != 30)
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati, minute + 30, 0);
                }
                else
                {
                    azuriran_kraj = new DateTime(datum.Year, datum.Month, datum.Day, sati + 1, minute - 30, 0);
                }

                AzuriranoVreme.Text = (azurirajVreme(azuriran_pocetak, azuriran_kraj));

            }

            return;

        }
    }
}
