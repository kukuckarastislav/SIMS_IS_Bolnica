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

using Model;
using Servis;
using Kontroler;
using DTO;


namespace Bolnica.view.lekar.pacijenti
{
    public partial class BrisanjeUsluge : Page
    {
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        public LekarDTO LekarDTO { get; set; }
        public RadniKalendarDTO OdabranaUsluga { get; set; }
        public ZdravstvenaUslugaKontroler ZdravstvenaUslugaKontrolerObjekat { get; set; }

        public BrisanjeUsluge(LekarDTO LekarDTO, RadniKalendarDTO OdabranaUsluga)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.LekarDTO = LekarDTO;
            ZdravstvenaUslugaKontrolerObjekat = new ZdravstvenaUslugaKontroler();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            ImePacijenta.Text = "Pacijent: " + OdabranaUsluga.ImePacijenta.ToString();
            TipUsluge.Text = OdabranaUsluga.Usluga.TipUsluge.ToString();
            Prostorija.Text = OdabranaUsluga.NazivProstorije.ToString();
            VremePocetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Pocetak.ToString("MM/dd/yyyy HH:mm:ss");
            VremeZavrsetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Kraj.ToString("MM/dd/yyyy HH:mm:ss");
            RazlogZakazivanja.Text = OdabranaUsluga.Usluga.RazlogZakazivanja.ToString();
        }

        private void OdustaniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
                NavigationService.Navigate(refRadniKalendar);
            }
        }

        private void PotvrdiBrisanje(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                ZdravstvenaUslugaKontrolerObjekat.ObrisiUslugu(OdabranaUsluga.Usluga);
                var backRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
                NavigationService.Navigate(backRadniKalendar);
            }
        }
    }
}
