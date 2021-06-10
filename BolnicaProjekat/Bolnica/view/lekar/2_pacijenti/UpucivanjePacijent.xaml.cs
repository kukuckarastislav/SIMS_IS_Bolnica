using Kontroler;
using Repozitorijum;
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

    public partial class UpucivanjePacijent : Page
    {
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public LekarKontroler LekarKontrolerObjekat { get; set; }
        public ObservableCollection<Prostorija> KolekcijaSobeZaPregled { get; set; }
        public ObservableCollection<String> KolekcijaIDSobeZaPregled { get; set; }
        public ObservableCollection<LekarDTO> KolekcijaLekarDTO { get; set; }
        public DateTime date;
        public LekarDTO LekarDTO { get; set; }
        public PacijentDTO PacijentDTO { get; set; }
        public ZdravstvenaUsluga KreiranaUsluga { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;



        public UpucivanjePacijent(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            InitializeComponent();
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;
            this.LekarKontrolerObjekat = new LekarKontroler();

            InicijalizujObjekte();
            UcitajPodatke();
        }

        private void InicijalizujObjekte()
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            KolekcijaSobeZaPregled = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            KolekcijaIDSobeZaPregled = new ObservableCollection<String>();
            KolekcijaLekarDTO = new ObservableCollection<LekarDTO>();

            foreach (LekarDTO LekarDTO in LekarKontrolerObjekat.GetAllDTO())
            {
                KolekcijaLekarDTO.Add(LekarDTO);
            }

            foreach (Prostorija s in KolekcijaSobeZaPregled)
            {
                KolekcijaIDSobeZaPregled.Add(s.BrojSprat);
            }
            date = DateTime.Now;
        }
        private void UcitajPodatke()
        {
            this.ComboBoxProstorija.ItemsSource = KolekcijaSobeZaPregled;
            this.ComboBoxLekar.ItemsSource = KolekcijaLekarDTO;

            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;
        }


        private void datum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            date = datum.SelectedDate.Value;
            if (DateTime.Compare(date, DateTime.Now) < 0)
            {
                MessageBox.Show("Moguce je izabrati samo buduce datume");
                date = DateTime.Now;
            }
        }


        private void PotvrdiZakazanuUsluguButton(object sender, RoutedEventArgs e)
        {
            // Termin termin, int id, int idLekarDTOa, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge
            int pocetakSati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
            int pocetakMinute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
            string pocetakAP = VremePocetakTermina_AM_PM.Text;

            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;


            DateTime pocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute, 0);
            TimeSpan trajanje = new TimeSpan(0, 0, 30, 0);
            DateTime kraj = pocetak + trajanje;

            Termin termin = new Termin(pocetak, kraj);
            int idUsluge = Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.getNewId();
            int idLekarDTOa = ((LekarDTO)ComboBoxLekar.SelectedItem).Id;
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


        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

    }
}
