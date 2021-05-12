using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Service;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PacijentHome.xaml
    /// </summary>
    public partial class PacijentHome : Window
    {
        public Pacijent Pacijent;
        Thread podsjetnikThread;
        private Servis.PodsjetnikServis PodsjetnikServis;
        public PacijentHome(Pacijent p)
        {

            InitializeComponent();

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            pol.Text = p.Pol.ToString();
            adresa.Text = p.AdresaStanovanja;
            email.Text = p.Email;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.Telefon;
            korisnickoime.Text = p.KorisnickoIme;

            broj_notifikacija.Text = Repozitorijum.NotifikacijaRepozitorijum.GetInstance.GetByPatientId(p.Id).Count.ToString();

            Pacijent = p;

            PodsjetnikServis = new Servis.PodsjetnikServis();
            podsjetnikThread = new Thread(new ThreadStart(PodsjetnikServis.ThreadPodsjetnik));
            podsjetnikThread.IsBackground = true;
            podsjetnikThread.Start();
        }

        private void prikazi_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.RaspoloziviPregledi();
            varr.Show();
        }

        private void prikazi_vlastite_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.SopstveniPregledi(Pacijent);
            varr.Show();

        }
        private void prikazi_notifikacije(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.NotifikacijePacijent();
            varr.Show();
        }

        private void prikazi_ocjene(object sender, RoutedEventArgs e)
        {
            var varr=new view.pacijent.Ocjene(Pacijent);
            varr.Show();
        }

        private void prikazi_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr=new view.pacijent.PodsjetnikPacijenta(Pacijent);
            varr.Show();
        }

        private void dodaj_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.NoviPodsjetnik(Pacijent);
            varr.Show();
        }
    }
}
