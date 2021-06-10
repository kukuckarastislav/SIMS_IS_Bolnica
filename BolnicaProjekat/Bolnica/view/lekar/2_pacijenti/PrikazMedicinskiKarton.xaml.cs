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
using Kontroler;
using DTO;

namespace Bolnica.view.lekar.pacijenti
{
    public partial class PrikazMedicinskiKarton : Page
    {

        private view.lekar.pacijenti.PrikazPacijenata refPrikazPacijenata;

        private view.lekar.pacijenti.OsnovniPodaci refOsnovniPodaci;
        private view.lekar.pacijenti.ZakazivanjeUsluge refZakazivanjeUsluge;
        private view.lekar.pacijenti.TerapijaPacijenta refTerapijaPacijenta;
        private view.lekar.pacijenti.IzdavanjeRecepta refIzdavanjeRecepta;
        private view.lekar.pacijenti.ZakazaneUslugePacijenta refZakazaneUslugePacijenta;
        private view.lekar.pacijenti.UpucivanjePacijent refUpucivanjePacijenta;
        private view.lekar.pacijenti.UpucivanjeNaStacionarnoLecenje refUpucivanjeNaStacionarnoLecenje;

        public PacijentDTO PacijentDTO { get; set; }
        public LekarDTO LekarDTO;


        public System.Collections.ArrayList preglediLista { get; set; }



        public PrikazMedicinskiKarton(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            this.PacijentDTO = PacijentDTO;
            this.LekarDTO = LekarDTO;

            InitializeComponent();

            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;

        }

        public Pacijent GetPacijentDTOa { get; set; }


        private void IzdavanjeReceptaButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refIzdavanjeRecepta = new view.lekar.pacijenti.IzdavanjeRecepta(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refIzdavanjeRecepta);
            }
        }

        private void ZakazivanjeUslugeButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refZakazivanjeUsluge = new view.lekar.pacijenti.ZakazivanjeUsluge(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refZakazivanjeUsluge);
            }

        }

        private void OsnovniPodaciButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refOsnovniPodaci = new view.lekar.pacijenti.OsnovniPodaci(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refOsnovniPodaci);
            }
        }

        private void TerapijaButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refTerapijaPacijenta = new view.lekar.pacijenti.TerapijaPacijenta(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refTerapijaPacijenta);
            }

        }

        private void ZakazaneUslugePacijentaButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refZakazaneUslugePacijenta = new view.lekar.pacijenti.ZakazaneUslugePacijenta(LekarDTO, PacijentDTO);
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
            if (PacijentDTO != null)
            {
                refUpucivanjePacijenta = new view.lekar.pacijenti.UpucivanjePacijent(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refUpucivanjePacijenta);
            }
        }

        private void UpucivanjeHospitalizacijaButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refUpucivanjeNaStacionarnoLecenje = new view.lekar.pacijenti.UpucivanjeNaStacionarnoLecenje(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refUpucivanjeNaStacionarnoLecenje);
            }
        }
    }
}
