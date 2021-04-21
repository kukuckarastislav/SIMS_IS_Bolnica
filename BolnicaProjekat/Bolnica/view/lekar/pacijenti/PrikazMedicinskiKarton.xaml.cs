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
    /// Interaction logic for PrikazMedicinskiKarton.xaml
    /// </summary>
    public partial class PrikazMedicinskiKarton : Page
    {
        // Back - Pages
        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenata;
        // Next - Pages
        private view.lekar.pacijenti.OsnovniPodaci refOsnovniPodaci;
        private view.lekar.pacijenti.ZakazivanjeUsluge refZakazivanjeUsluge;
        private view.lekar.pacijenti.TerapijaPacijenta refTerapijaPacijenta;
        private view.lekar.pacijenti.IzdavanjeRecepta refIzdavanjeRecepta;
        private view.lekar.pacijenti.ZakazaneUslugePacijenta refZakazaneUslugePacijenta;
        // KORISNICI
        public Pacijent IzabraniPacijent { get; set; }
        public Lekar Lekar;

        // KOLEKCIJE
        //public ObservableCollection<Pregled> preglediKolekcija { get; set; }
        public System.Collections.ArrayList preglediLista { get; set; }



        public PrikazMedicinskiKarton(Lekar Lekar, Model.Pacijent IzabraniPacijent)
        {
            this.IzabraniPacijent = IzabraniPacijent;
            this.Lekar = Lekar;

            InitializeComponent();

            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;





            //preglediLista = IzabraniPacijent.MedicinskiKarton.GetPregled();
            // preglediKolekcija = new ObservableCollection<Pregled>();

            //  foreach (Pregled p in preglediLista) { preglediKolekcija.Add(p); }
            //this.listaPregledaPacijenta.ItemsSource = preglediKolekcija;




        }

        public Pacijent GetIzabraniPacijenta { get; set; }


        private void listaPregledaPacijenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Kreiranje_Pregleda(object sender, RoutedEventArgs e)
        {
            var kreiranje_pregleda_forma = new Bolnica.view.lekar.pacijenti.KreiranjePregledaForma(IzabraniPacijent);
            kreiranje_pregleda_forma.Show();
            //  Model.Pregled kreiraniPregled = new Model.Pregled(; 
        }

        private void BrisanjePregleda(object sender, RoutedEventArgs e)
        {
            
          //  this.IzabraniPacijent.MedicinskiKarton.GetPregled().Remove(listaPregledaPacijenta.SelectedItem as Pregled);
                
        }


        // dobar kod

        private void IzdavanjeReceptaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refIzdavanjeRecepta = new view.lekar.pacijenti.IzdavanjeRecepta(Lekar,IzabraniPacijent);
                NavigationService.Navigate(refIzdavanjeRecepta);
            }
        }

        private void ZakazivanjeUslugeButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refZakazivanjeUsluge = new view.lekar.pacijenti.ZakazivanjeUsluge(Lekar,IzabraniPacijent);
                NavigationService.Navigate(refZakazivanjeUsluge);
            }

        }

        private void OsnovniPodaciButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refOsnovniPodaci = new view.lekar.pacijenti.OsnovniPodaci(IzabraniPacijent);
                NavigationService.Navigate(refOsnovniPodaci);
            }
        }

        private void TerapijaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refTerapijaPacijenta = new view.lekar.pacijenti.TerapijaPacijenta(IzabraniPacijent);
                NavigationService.Navigate(refTerapijaPacijenta);
            }

        }

        private void ZakazaneUslugePacijentaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refZakazaneUslugePacijenta = new view.lekar.pacijenti.ZakazaneUslugePacijenta(Lekar,IzabraniPacijent);
                NavigationService.Navigate(refZakazaneUslugePacijenta);
            }
        }

        private void PrikazPacijenataButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenata = new view.lekar.pacijenti.PrikazPacijenata(Lekar);
            NavigationService.Navigate(refPrikazPacijenata);

        }
    }
}
