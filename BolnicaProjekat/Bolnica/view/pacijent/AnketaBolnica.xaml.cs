using System;
using System.Windows;


namespace Bolnica.view.pacijent
{

    public partial class AnketaBolnica : Window
    {
        private int idPacijenta;
        private string text;

        public AnketaBolnica(int idPacijenta)
        {
            this.idPacijenta = idPacijenta;
            InitializeComponent();
        }

        private void posalji_anketu(object sender, RoutedEventArgs e)
        {
            Controller.NotifikacijaKontroler kontrolerNotifikacija = new Controller.NotifikacijaKontroler();

            kontrolerNotifikacija.ObrisiNotifikaciju(1, 0);
            Controller.AnketaKontroler kontroler = new Controller.AnketaKontroler();
            text = sadrzaj.Text;
            int ocjena = Convert.ToInt32(ocjene.Text);
            kontroler.DodajOcenuBolnice(idPacijenta, text,ocjena);
            this.Close();
        }
    }
}
