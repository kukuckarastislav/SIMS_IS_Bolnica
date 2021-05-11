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

namespace Bolnica.view.lekar.pacijenti
{
    /// <summary>
    /// Interaction logic for ZakazivanjeUsluge.xaml
    /// </summary>
    public partial class ZakazivanjeUsluge : Page
    {


        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public ObservableCollection<Prostorija> KolekcijaSobeZaPregled { get; set; }
        public ObservableCollection<String> KolekcijaIDSobeZaPregled { get; set; }

        public DateTime date;
        public Lekar Lekar { get; set; }
        public Pacijent IzabraniPacijent { get; set; }
        public ZdravstvenaUsluga KreiranaUsluga { get; set; }
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;


        public ZakazivanjeUsluge(Lekar Lekar, Pacijent IzabraniPacijent)
        {
            this.Lekar = Lekar;
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            this.IzabraniPacijent = IzabraniPacijent;
            KolekcijaSobeZaPregled = ProstorijeKontrolerObjekat.getProstorijeTipObservable(TipProstorije.SobaZaPreglede);
            KolekcijaIDSobeZaPregled = new ObservableCollection<String>();
            foreach (Prostorija s in KolekcijaSobeZaPregled)
            {
                //KolekcijaIDSobeZaPregled.Add(s.Id.ToString());
                KolekcijaIDSobeZaPregled.Add(s.BrojSprat);
            }
            InitializeComponent();
            this.ComboBoxProstorija.ItemsSource = KolekcijaSobeZaPregled;


            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;
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
            // Termin termin, int id, int idLekara, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge
            int pocetakSati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
            int pocetakMinute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
            string pocetakAP = VremePocetakTermina_AM_PM.Text;

            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;

            DateTime pocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute,0);
            TimeSpan trajanje = new TimeSpan(0, 0, 30, 0);
            DateTime kraj = pocetak + trajanje;

            Termin termin = new Termin(pocetak, kraj);
            int idUsluge = Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.getNewId();
            int idLekara = Lekar.Id;
            int idPacijenta = IzabraniPacijent.Id;
            TipUsluge tipUsluge = TipUsluge.Pregled;
            Prostorija prostorija = (Prostorija)ComboBoxProstorija.SelectedItem;
            int idProstorije = prostorija.Id;
            bool obavljena = false;
            string razlogZakazivanja = RazlogZakazivanja.Text;
            string rezultat = " ";

            //Termin termin, int id, int idLekara, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUslug
            KreiranaUsluga = new ZdravstvenaUsluga(termin, idUsluge, idLekara, idPacijenta, tipUsluge, idProstorije, obavljena, razlogZakazivanja, rezultat);
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(KreiranaUsluga);


        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(Lekar, IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        
    }
}
