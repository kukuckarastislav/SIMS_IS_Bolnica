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
        public ObservableCollection<Prostorija> KolekcijaSobeZaPregled { get; set; }
        public DateTime VremeUsluge;
        public LekarDTO LekarDTO { get; set; }
        public PacijentDTO PacijentDTO { get; set; }
        public ZdravstvenaUsluga KreiranaUsluga { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;


        public ZakazivanjeUsluge(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();

            KolekcijaSobeZaPregled = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            ComboBoxProstorija.ItemsSource = KolekcijaSobeZaPregled;
            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;
            KalendarDanUsluge.SelectedDate = DateTime.Today;
            KreirajIspravanKalendar();
        }

        private void KreirajIspravanKalendar()
        {
            KalendarDanUsluge.DisplayDateStart = DateTime.Today;
        }


        private void CmbHitnoZakazivanje_Checked(object sender, RoutedEventArgs e)
        {
            KalendarDanUsluge.IsEnabled = false;
            ComboBoxVremeUsluge_Sat.IsEnabled = false;
            ComboBoxVremeUsluge_Minut.IsEnabled = false;
            VremeUsluge = DateTime.Now;
            KalendarDanUsluge.SelectedDate = DateTime.Today;
        }

        private void CmbHitnoZakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            KalendarDanUsluge.IsEnabled = true;
            ComboBoxVremeUsluge_Sat.IsEnabled = true;
            ComboBoxVremeUsluge_Minut.IsEnabled = true;
            
        }



        private void PotvrdiZakazanuUsluguButton(object sender, RoutedEventArgs e)
        {
            // Termin termin, int id, int idLekarDTOa, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge
            int pocetakSati = Convert.ToInt32(ComboBoxVremeUsluge_Sat.Text);
            int pocetakMinute = Convert.ToInt32(ComboBoxVremeUsluge_Minut.Text);

            DateTime pocetak = new DateTime(VremeUsluge.Year, VremeUsluge.Month, VremeUsluge.Day, pocetakSati, pocetakMinute, 0);
            TimeSpan trajanje = new TimeSpan(0, 0, 30, 0);
            DateTime kraj = pocetak + trajanje;

            Termin termin = new Termin(pocetak, kraj);
            int idUsluge = Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.getNewId();
            int idLekarDTOa = LekarDTO.Id;
            int idPacijenta = PacijentDTO.Id;
            TipUsluge tipUsluge = TipUsluge.Pregled;
            Prostorija prostorija = (Prostorija)ComboBoxProstorija.SelectedItem;
            int idProstorije = prostorija.Id;
            bool obavljena = false;
            string razlogZakazivanja = RazlogZakazivanja.Text;
            string rezultat = " ";

            //Termin termin, int id, int idLekarDTOa, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUslug
            KreiranaUsluga = new ZdravstvenaUsluga(termin, idUsluge, idLekarDTOa, idPacijenta, tipUsluge, idProstorije, obavljena, razlogZakazivanja, rezultat);
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(KreiranaUsluga);

            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }

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
        }
    }
}
