using Model;
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

        public DateTime date;
        public Lekar Lekar;
        public ZdravstvenaUsluga OdabranaUsluga { get; set; }
        public ZdravstvenaUsluga AzuriranaUsluga { get; set; }

        public AzuriranjeUsluge(Lekar Lekar, ZdravstvenaUsluga OdabranaUsluga)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.Lekar = Lekar;
            TipUsluge.Text = (OdabranaUsluga.TipUsluge).ToString();
            Prostorija p = Repozitorijum.ProstorijeRepozitorijum.GetInstance.GetProstorijaById(OdabranaUsluga.IdProstorije);
            Prostorija.Text = p.BrojSprat;
            VremePocetkaUsluge.Text = (OdabranaUsluga.Termin.Pocetak).ToString("dddd, dd MMMM yyyy") + " - " + (OdabranaUsluga.Termin.Pocetak).ToString("hh:mm tt");
            VremeZavrsetkaUsluge.Text = (OdabranaUsluga.Termin.Kraj).ToString("dddd, dd MMMM yyyy") + " - " + (OdabranaUsluga.Termin.Kraj).ToString("hh:mm tt");
            RazlogZakazivanja.Text = (OdabranaUsluga.RazlogZakazivanja).ToString();
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

        private void PotvrdiAzuriranjeButton(object sender, RoutedEventArgs e)
        {
            int pocetakSati = Convert.ToInt32(VremePocetakTermina_Sat.Text);
            int pocetakMinute = Convert.ToInt32(VremePocetakTermina_Minut.Text);
            string pocetakAP = VremePocetakTermina_AM_PM.Text;

            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;


            date = datum.SelectedDate.Value;

            DateTime pocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute, 0);
            TimeSpan trajanje = new TimeSpan(0, 0, 30, 0);
            DateTime kraj = pocetak + trajanje;

            int idUsluge = OdabranaUsluga.Id;
            int idLekara = OdabranaUsluga.IdLekara;
            int idPacijenta = OdabranaUsluga.IdPacijenta;
            TipUsluge tipUsluge = OdabranaUsluga.TipUsluge;
            int idProstorije = OdabranaUsluga.IdProstorije;
            bool obavljena = OdabranaUsluga.Obavljena;
            string razlogZakazivanja = OdabranaUsluga.RazlogZakazivanja;
            string rezultat = OdabranaUsluga.RezultatUsluge;

            Termin newTermin = new Termin(pocetak, kraj);
            AzuriranaUsluga = new ZdravstvenaUsluga(newTermin, idUsluge, idLekara, idPacijenta, tipUsluge, idProstorije, obavljena, razlogZakazivanja, rezultat);
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(AzuriranaUsluga);
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(OdabranaUsluga);

        }
    }
}
