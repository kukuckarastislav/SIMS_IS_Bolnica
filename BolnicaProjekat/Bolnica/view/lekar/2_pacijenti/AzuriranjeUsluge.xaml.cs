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
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
    public partial class AzuriranjeUsluge : Page
    {

        // BACK - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;

        public LekarDTO LekarDTO { get; set; }
        public ObservableCollection<DTORadniKalendar> ListaRadniKalendar { get; set; }
        public DTORadniKalendar OdabranaUsluga { get; set; }
        public DTORadniKalendar AzuriranaUsluga { get; set; }
        public DateTime AzuriranPocetak { get; set; }
        public DateTime AzuriranKraj { get; set; }

        public AzuriranjeUsluge(LekarDTO LekarDTO, DTORadniKalendar OdabranaUsluga, ObservableCollection<DTORadniKalendar> ListaRadniKalendar)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.ListaRadniKalendar = ListaRadniKalendar;
            this.LekarDTO = LekarDTO;
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            lblImePrezimePacijenta.Text = "Pacijent: " + OdabranaUsluga.ImePacijenta.ToString();
            txtTipUsluge.Text = OdabranaUsluga.Usluga.TipUsluge.ToString();
            txtProstorija.Text = OdabranaUsluga.NazivProstorije.ToString();
            txtPocetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Pocetak.ToString("MM/dd/yyyy HH:mm:ss");
            txtZavrsetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Kraj.ToString("MM/dd/yyyy HH:mm:ss");
            txtRazlogZakazivanja.Text = OdabranaUsluga.Usluga.RazlogZakazivanja.ToString();
            KreirajIspravanKalendar();
        }

        private void KreirajIspravanKalendar()
        {
            CalendarDateRange proslost = new CalendarDateRange(DateTime.MinValue, DateTime.Today);
            kalPomeriDanUsluge.BlackoutDates.Add(proslost);
        }

        private void PotvrdiAzuriranjeButton(object sender, RoutedEventArgs e)
        {
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.AzurirajVremeUsluga(OdabranaUsluga.Usluga, AzuriranPocetak, AzuriranKraj);
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
            NavigationService.Navigate(refRadniKalendar);
        }

        private void OdustaniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
                NavigationService.Navigate(refRadniKalendar);
            }
        }

        private void IspisiAzuriranoVreme()
        {
            int sati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
            int minute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
            DateTime datum = kalPomeriDanUsluge.SelectedDate.Value;
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
            AzuriranoVreme.Text = (NapraviStringAzuriranoVreme(azuriran_pocetak, azuriran_kraj));

        }

        private string NapraviStringAzuriranoVreme(DateTime azuriran_pocetak, DateTime azuriran_kraj)
        {
            this.AzuriranPocetak = azuriran_pocetak;
            this.AzuriranKraj = azuriran_kraj;
            return  azuriran_pocetak.ToString("MM / dd / yyyy") + "\n" 
                    + "Od "+ azuriran_pocetak.ToString("HH:mm:ss") + "\n" 
                    + "Do " + azuriran_kraj.ToString("HH:mm:ss");
        }

        private void Kalendar_pomeri_dan_termina_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (VremePocetakTermina_Sat.SelectedValue != null &&
                VremePocetakTermina_Minut.SelectedValue != null &&
                kalPomeriDanUsluge.SelectedDate != null)
            {
                IspisiAzuriranoVreme();
            }
            return;
        }

        private void VremePocetakTermina_Sat_DropDownClosed(object sender, EventArgs e)
        {
            if (kalPomeriDanUsluge.SelectedDate != null)
            {
                IspisiAzuriranoVreme();
            }
            return;

        }

        private void VremePocetakTermina_Minut_DropDownClosed(object sender, EventArgs e)
        {
            if (kalPomeriDanUsluge.SelectedDate != null)
            {
                IspisiAzuriranoVreme();
            }
            return;

        }


    }
}
