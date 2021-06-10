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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
    public partial class ZakazivanjeUsluge : Page
    {
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public ZdravstvenaUslugaKontroler ZdravstvenaUslugaKontrolerObjekat { get; set; }
        public ObservableCollection<Prostorija> KolekcijaProstorija { get; set; }
        public DateTime VremeUsluge;
        public LekarDTO LekarDTO { get; set; }
        public PacijentDTO PacijentDTO { get; set; }
        public ZdravstvenaUsluga KreiranaUsluga { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;


        public ZakazivanjeUsluge(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            ZdravstvenaUslugaKontrolerObjekat = new ZdravstvenaUslugaKontroler();
            KolekcijaProstorija = new ObservableCollection<Prostorija>();
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;




            rbOperacija.IsEnabled = LekarDTO.Specijalista;



            ComboBoxProstorija.ItemsSource = KolekcijaProstorija;
            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;

            KalendarDanUsluge.SelectedDate = DateTime.Today;
            KreirajIspravanKalendar();
        }

        private void KreirajIspravanKalendar()
        {
            KalendarDanUsluge.DisplayDateStart = DateTime.Today;

            SveJePopunjen();
        }

        private void ComboBoxProstorija_DropDownClosed(object sender, EventArgs e)
        {

            SveJePopunjen();
        }

        private void CmbHitnoZakazivanje_Checked(object sender, RoutedEventArgs e)
        {
            VremeUsluge = DateTime.Now;
            KalendarDanUsluge.SelectedDate = DateTime.Today;
            ComboBoxVremeUsluge_Sat.Text = Convert.ToString(VremeUsluge.Hour);
            ComboBoxVremeUsluge_Minut.Text = Convert.ToString(VremeUsluge.Minute - VremeUsluge.Minute % 5);

            ComboBoxVremeUsluge_Sat.IsEnabled = false;
            ComboBoxVremeUsluge_Minut.IsEnabled = false;
            KalendarDanUsluge.IsEnabled = false;
            KolekcijaProstorija = new ObservableCollection<Prostorija>();

            SveJePopunjen();

        }

        private void CmbHitnoZakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            KalendarDanUsluge.IsEnabled = true;
            KalendarDanUsluge.SelectedDate = DateTime.Today;
            ComboBoxVremeUsluge_Sat.Text = Convert.ToString(VremeUsluge.Hour);
            ComboBoxVremeUsluge_Minut.Text = Convert.ToString(VremeUsluge.Minute - VremeUsluge.Minute % 5);

            ComboBoxVremeUsluge_Sat.IsEnabled = true;
            ComboBoxVremeUsluge_Minut.IsEnabled = true;
            KalendarDanUsluge.IsEnabled = true;

            SveJePopunjen();

        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private void KalendarDanUsluge_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            VremeUsluge = KalendarDanUsluge.SelectedDate.Value;

            SveJePopunjen();

        }

        private void IspisiZakazanoVreme()
        {
            int sati = Convert.ToInt32(ComboBoxVremeUsluge_Sat.Text);
            int minute = Convert.ToInt32(ComboBoxVremeUsluge_Minut.Text);
            VremeUsluge = KalendarDanUsluge.SelectedDate.Value;
            DateTime pocetak = new DateTime(VremeUsluge.Year, VremeUsluge.Month, VremeUsluge.Day, sati, minute, 0);
            DateTime kraj = pocetak.AddMinutes(30);
            AzuriranoVreme.Text = (NapraviStringAzuriranoVreme(pocetak, kraj));
        }

        private string NapraviStringAzuriranoVreme(DateTime azuriran_pocetak, DateTime azuriran_kraj)
        {
            return azuriran_pocetak.ToString("MM / dd / yyyy") + "\n"
                    + "Od " + azuriran_pocetak.ToString("HH:mm:ss") + "\n"
                    + "Do " + azuriran_kraj.ToString("HH:mm:ss");
        }

        private void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            int pocetakSati = Convert.ToInt32(ComboBoxVremeUsluge_Sat.Text);
            int pocetakMinute = Convert.ToInt32(ComboBoxVremeUsluge_Minut.Text);

            DateTime pocetak = new DateTime(VremeUsluge.Year, VremeUsluge.Month, VremeUsluge.Day, pocetakSati, pocetakMinute, 0);
            TimeSpan trajanje = new TimeSpan(0, 0, 30, 0);
            DateTime kraj = pocetak + trajanje;

            Termin termin = new Termin(pocetak, kraj);
            int idUsluge = ZdravstvenaUslugaKontrolerObjekat.getNewId();
            int idLekarDTOa = LekarDTO.Id;
            int idPacijenta = PacijentDTO.Id;
            TipUsluge tipUsluge = TipUsluge.Pregled;
            Prostorija prostorija = (Prostorija)ComboBoxProstorija.SelectedItem;
            int idProstorije = prostorija.Id;
            bool obavljena = false;
            string razlogZakazivanja = RazlogZakazivanja.Text;
            string rezultat = " ";

            KreiranaUsluga = new ZdravstvenaUsluga(termin, idUsluge, idLekarDTOa, idPacijenta, tipUsluge, idProstorije, obavljena, razlogZakazivanja, rezultat);
            ZdravstvenaUslugaKontrolerObjekat.DodajUslugu(KreiranaUsluga);

            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private void SveJePopunjen()
        {
            Potvrdi.IsEnabled = false;
            if (KalendarDanUsluge.SelectedDate != null &&
                ComboBoxProstorija.SelectedItem != null)
            {
                IspisiZakazanoVreme();
                Potvrdi.IsEnabled = true;
            }

        }

        private void rbPregled_Checked(object sender, RoutedEventArgs e)
        {
            KolekcijaProstorija = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            ComboBoxProstorija.ItemsSource = KolekcijaProstorija;
        }

        private void rbOperacija_Checked(object sender, RoutedEventArgs e)
        {
            KolekcijaProstorija = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.OpracionaSala);
            ComboBoxProstorija.ItemsSource = KolekcijaProstorija;
        }
    }
}
