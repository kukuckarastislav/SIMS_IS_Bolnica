using DTO;
using System.Threading;
using System.Windows;
using Kontroler;
using System.Windows.Input;
using Servis;
using Threads;

namespace Bolnica.view.pacijent
{
    public partial class PacijentHome : Window
    {
        public PacijentDTO Pacijent;
        Thread podsjetnikThread;
        Thread suspensionThread;
        private UserSuspension UserSuspension;
        private MedicationConsumption MedicationConsumption;

        public PacijentHome(PacijentDTO p)
        {

            InitializeComponent();

            ime.Text = p.Ime;
            prezime.Text = p.Prezime;
            email.Text = p.Email;
            jmbg.Text = p.Jmbg;
            telefon.Text = p.Telefon;

            broj_notifikacija.Text = Repozitorijum.NotifikacijaRepozitorijum.GetInstance.GetByPatientId(p.Id).Count.ToString();
            PodsjetnikKontroler Kontroler = new PodsjetnikKontroler();
            broj_podsjetnika.Text = Kontroler.GetBrojNeprocitanihPodsjetnika(p.Id);
            Pacijent = p;

            MedicationConsumption = new MedicationConsumption();
            MedicationConsumption.Register(new PodsjetnikServis());

            podsjetnikThread = new Thread(new ThreadStart(MedicationConsumption.ThreadPodsjetnik));
            podsjetnikThread.IsBackground = true;
            podsjetnikThread.Start();


            UserSuspension = new UserSuspension();
            UserSuspension.Register(new KorisnickaAktivnostServis());
            UserSuspension.Register(new PacijentServis());
            UserSuspension.Register(new NotifikacijeServis());

            suspensionThread = new Thread(new ThreadStart(UserSuspension.ThreadSuspension));
            suspensionThread.IsBackground = true;
            suspensionThread.Start();
        }

        private void prikazi_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.RaspoloziviPregledi();
            varr.ShowDialog();
        }

        private void prikazi_vlastite_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.SopstveniPregledi(Pacijent);
            varr.ShowDialog();

        }
        private void prikazi_notifikacije(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.NotifikacijePacijent();
            varr.ShowDialog();
        }

        private void prikazi_ocjene(object sender, RoutedEventArgs e)
        {
            var varr=new view.pacijent.Ocjene(Pacijent);
            varr.ShowDialog();
        }

        private void prikazi_podsjetnik(object sender, RoutedEventArgs e)
        {
            var varr=new view.pacijent.PodsjetnikPacijenta(Pacijent);
            varr.ShowDialog();
        }

        private void prikazi_istoriju_bolesti(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.IstorijaBolesti(Pacijent);
            varr.ShowDialog();

        }

        private void prikazi_trenutnu_terapiju(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.TrenutnaTerapija(Pacijent);
            varr.ShowDialog();
        }

        private void odjava_Click(object sender, RoutedEventArgs e)
        {
            var varr = new MainWindow();
            this.Close();
        }

        private void pomoc_Click(object sender, RoutedEventArgs e)
        {
            var varr = new PacijentHomeHelp();
            varr.ShowDialog();
        }

        private void izvjestaj_Click(object sender, RoutedEventArgs e)
        {
            var varr = new Izvjestaj(Pacijent);
            varr.ShowDialog();
        }

        private void feedback_Click(object sender, RoutedEventArgs e)
        {
            var varr = new FeedbackPacijenta(Pacijent);
            varr.ShowDialog();
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.E && Keyboard.IsKeyDown(Key.LeftCtrl))
                odjava_Click(sender, e);
            else if (e.Key == Key.H && Keyboard.IsKeyDown(Key.LeftCtrl))
                pomoc_Click(sender, e);
            else if (e.Key == Key.N && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_notifikacije(sender, e);
            else if (e.Key == Key.P && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_podsjetnik(sender, e);
            else if (e.Key == Key.A && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_preglede(sender, e);
            else if (e.Key == Key.O && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_vlastite_preglede(sender, e);
            else if (e.Key == Key.G && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_ocjene(sender, e);
            else if (e.Key == Key.I && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_istoriju_bolesti(sender, e);
            else if (e.Key == Key.T && Keyboard.IsKeyDown(Key.LeftCtrl))
                prikazi_trenutnu_terapiju(sender, e);


        }

        private void kalendar_Click(object sender, RoutedEventArgs e)
        {
            var varr = new Kalendar(Pacijent);
            varr.ShowDialog();
        }
    }
    }
