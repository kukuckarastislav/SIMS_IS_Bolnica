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
    /// Interaction logic for OsnovniPodaci.xaml
    /// </summary>
    public partial class OsnovniPodaci : Page
    {
        public Pacijent IzabraniPacijent { get; set; }
        public Lekar Lekar;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;

        public OsnovniPodaci(Model.Pacijent IzabraniPacijent)
        {
            this.Lekar = Lekar;
            this.IzabraniPacijent = IzabraniPacijent;

            InitializeComponent();



            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;


            ime.Text = IzabraniPacijent.Ime;
            prezime.Text = IzabraniPacijent.Prezime;
            pol.Text = IzabraniPacijent.Pol.ToString();
            adresa.Text = IzabraniPacijent.AdresaStanovanja;
            email.Text = IzabraniPacijent.Email;
            jmbg.Text = IzabraniPacijent.Jmbg;
            telefon.Text = IzabraniPacijent.Telefon;
            korisnickoime.Text = IzabraniPacijent.KorisnickoIme;

        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(Lekar,IzabraniPacijent);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }
    }
}
