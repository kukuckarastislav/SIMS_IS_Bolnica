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
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
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
        private view.lekar.pacijenti.UpucivanjePacijent refUpucivanjePacijenta;
        private view.lekar.pacijenti.UpucivanjeNaStacionarnoLecenje refUpucivanjeNaStacionarnoLecenje;
        // KORISNICI
        public Pacijent IzabraniPacijent { get; set; }
        public LekarDTO LekarDTO;

        // KOLEKCIJE
        //public ObservableCollection<Pregled> preglediKolekcija { get; set; }
        public System.Collections.ArrayList preglediLista { get; set; }



        public PrikazMedicinskiKarton(LekarDTO LekarDTO, Pacijent IzabraniPacijent)
        {
            this.IzabraniPacijent = IzabraniPacijent;
            this.LekarDTO = LekarDTO;

            InitializeComponent();

            headerIme.Text = IzabraniPacijent.Ime;
            headerPrezime.Text = IzabraniPacijent.Prezime;
            headerJMBG.Text = IzabraniPacijent.Jmbg;

        }

        public Pacijent GetIzabraniPacijenta { get; set; }


        private void listaPregledaPacijenta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
                refIzdavanjeRecepta = new view.lekar.pacijenti.IzdavanjeRecepta(LekarDTO,IzabraniPacijent);
                NavigationService.Navigate(refIzdavanjeRecepta);
            }
        }

        private void ZakazivanjeUslugeButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refZakazivanjeUsluge = new view.lekar.pacijenti.ZakazivanjeUsluge(LekarDTO,IzabraniPacijent);
                NavigationService.Navigate(refZakazivanjeUsluge);
            }

        }

        private void OsnovniPodaciButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refOsnovniPodaci = new view.lekar.pacijenti.OsnovniPodaci(LekarDTO, IzabraniPacijent);
                NavigationService.Navigate(refOsnovniPodaci);
            }
        }

        private void TerapijaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refTerapijaPacijenta = new view.lekar.pacijenti.TerapijaPacijenta(LekarDTO,IzabraniPacijent);
                NavigationService.Navigate(refTerapijaPacijenta);
            }

        }

        private void ZakazaneUslugePacijentaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refZakazaneUslugePacijenta = new view.lekar.pacijenti.ZakazaneUslugePacijenta(LekarDTO,IzabraniPacijent);
                NavigationService.Navigate(refZakazaneUslugePacijenta);
            }
        }

        private void PrikazPacijenataButton(object sender, RoutedEventArgs e)
        {
            refPrikazPacijenata = new view.lekar.pacijenti.PrikazPacijenata(LekarDTO);
            NavigationService.Navigate(refPrikazPacijenata);

        }

        private void UpucivanjeButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refUpucivanjePacijenta = new view.lekar.pacijenti.UpucivanjePacijent(LekarDTO, IzabraniPacijent);
                NavigationService.Navigate(refUpucivanjePacijenta);
            }
        }

        private void UpucivanjeHospitalizacijaButton(object sender, RoutedEventArgs e)
        {
            if (IzabraniPacijent != null)
            {
                refUpucivanjeNaStacionarnoLecenje = new view.lekar.pacijenti.UpucivanjeNaStacionarnoLecenje(LekarDTO, IzabraniPacijent);
                NavigationService.Navigate(refUpucivanjeNaStacionarnoLecenje);
            }
        }
    }
}
