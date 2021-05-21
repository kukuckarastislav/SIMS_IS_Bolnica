using Model;
using System.Threading;
using System.Windows;
using Kontroler;

namespace Bolnica.view.pacijent
{
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
            PodsjetnikKontroler Kontroler = new PodsjetnikKontroler();
            broj_podsjetnika.Text = Kontroler.GetBrojNeprocitanihPodsjetnika(p.Id);
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

        private void prikazi_istoriju_bolesti(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.IstorijaBolesti(Pacijent);
            varr.Show();

        }

        private void prikazi_trenutnu_terapiju(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.TrenutnaTerapija(Pacijent);
            varr.Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            var varr = new MainWindow();
            this.Close();
        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {

        }


        }
    }
