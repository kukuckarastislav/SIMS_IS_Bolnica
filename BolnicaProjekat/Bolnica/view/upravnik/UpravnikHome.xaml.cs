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
using System.Threading;
using Kontroler;
using Servis;

namespace Bolnica.view.upravnik
{
    /// <summary>
    /// Interaction logic for UpravnikHome.xaml
    /// </summary>
    public partial class UpravnikHome : Window
    {

        Thread preraspodelaInventaraThread;
        private TerminProstorijeServis terminProstorijeServisObjekat;
        
        public UpravnikHome()
        {
            InitializeComponent();
            //RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
            /*public Upravnik(RadnoVreme radnoVreme, RadniStatus radniStatus, string korisnickoIme, string sifra, string ime,
            string prezime, Pol pol, string email, string telefon, DateTime datumRodjenja,
            string jmbg, string drzavljanstvo, string adresaStanovanja) : base(radnoVreme, radniStatus, korisnickoIme, sifra, ime, prezime, pol, email, telefon, datumRodjenja, jmbg, drzavljanstvo,
                adresaStanovanja)
             * 
             */


            //Model.RadnoVreme radnoVreme = new Model.RadnoVreme(new DateTime(2000, 1, 7, 0, 0, 0), new DateTime(2022,1,1));
            //Model.RadnoVreme radnoVreme = new Model.RadnoVreme(7.0, 17.0);
            //Model.Upravnik upravnik = new Model.Upravnik(radnoVreme, Model.RadniStatus.Aktivan, "Pera123", "SIFRA", "Peric", "peric", Model.Pol.Musko, "perica@gmail", "0658499", new DateTime(2000, 1, 7), "4932423", "Srpsko", "Novi Sad");

            terminProstorijeServisObjekat = new TerminProstorijeServis();
            preraspodelaInventaraThread = new Thread(new ThreadStart(terminProstorijeServisObjekat.ThreadPreraspodelaInventara));
            preraspodelaInventaraThread.IsBackground = true;
            preraspodelaInventaraThread.Start();
        }

        private void Prostorije_Click(object sender, RoutedEventArgs e)
        {

            RadnaPovrsina.Content = new view.upravnik.prostorije.Prostorije();
        }

        private void Inventari_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.Inventari.InventariPage();
        }

        private void Magacin_Click(object sender, RoutedEventArgs e)
        {
            RadnaPovrsina.Content = new view.upravnik.Magacin.MagacinPage();
        }
    }
}
