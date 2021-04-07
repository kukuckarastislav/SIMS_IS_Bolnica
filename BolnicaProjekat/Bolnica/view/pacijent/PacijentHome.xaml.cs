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

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PacijentHome.xaml
    /// </summary>
    public partial class PacijentHome : Window
    {
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
        }

        private void prikazi_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.RaspoloziviPregledi();
            varr.Show();
        }

        private void prikazi_vlastite_preglede(object sender, RoutedEventArgs e)
        {
            var varr = new view.pacijent.SopstveniPregledi();
            varr.Show();

        }
    }
}
