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
using System.Windows.Shapes;
using Controller;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PrikazPregleda.xaml
    /// </summary>
    public partial class PrikazPregleda : Window
    {
        public ZdravstvenaUsluga Pregled;
        public DateTime NoviPocetak;
        public PrikazPregleda(ZdravstvenaUsluga usluga)
        {

            InitializeComponent();
            Pregled = usluga;


            datum.Text = (Pregled.Termin.Pocetak).ToString("dddd, dd MMMM yyyy");
            pocetak.Text = (Pregled.Termin.Pocetak).ToString("hh:mm tt");
            kraj.Text = (Pregled.Termin.Kraj).ToString("hh:mm tt");


            idlekara.Text = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(Pregled.IdLekara).Ime+" "+ Repozitorijum.LekarRepozitorijum.GetInstance.GetById(Pregled.IdLekara).Prezime;
          //  komentar.Text = Convert.ToString(Pregled.Komentar);
          //  soba.Text = Convert.ToString(Pregled.SobaZaPregled.Id);

        }

        private void izmjena_pregleda(object sender, RoutedEventArgs e)
        {
           this. Close();
           Pregled.RazlogZakazivanja = komentar.Text;
            //vrv treba i repozitorijum izmjena da se pozove
        }

        private void pomjeri_pregled(object sender, RoutedEventArgs e)
        {
            KorisnickaAktivnostKontroler kontroler = new KorisnickaAktivnostKontroler();

            if (!Servis.ZdravstvenaUslugaServis.PomjeranjeTerminaMoguce(Pregled, NoviPocetak))
            {
                MessageBox.Show("Izabrani termin je zauzet");
            }
            else
            {
                kontroler.DodajKorisnickuAktivnostPomjeranja(1);
                Pregled.Termin = new Termin(NoviPocetak, NoviPocetak + new TimeSpan(0, 0, 30, 0, 0));
                MessageBox.Show("Vas pregled je uspjesno pomjeren");
            }
        }

        private void SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime date = novi_datum.SelectedDate.Value;
            int pocetakSati = Convert.ToInt32(vrijeme_pocetak_sati.Text);
            int pocetakMinute = Convert.ToInt32(vrijeme_pocetak_minute.Text);
            string pocetakAP = vrijeme_pocetak_ap.Text;
            if (pocetakAP.Equals("PM"))
                pocetakSati += 12;

            NoviPocetak = new DateTime(date.Year, date.Month, date.Day, pocetakSati, pocetakMinute, 00);
            TimeSpan period = new TimeSpan(2, 0, 0, 0, 0);  // 2 dana

            if (DateTime.Compare(Pregled.Termin.Pocetak + period,NoviPocetak) < 0)
            {
                dugmePomjeriPregled.IsEnabled = false;
                MessageBox.Show("Maksimalno pomjeranje je 2 dana od originalnog termina --->" + NoviPocetak.ToString() +" izlazi iz tog okvira");
            }
            else
            {
                dugmePomjeriPregled.IsEnabled = true;
            }

        }
    }
}
