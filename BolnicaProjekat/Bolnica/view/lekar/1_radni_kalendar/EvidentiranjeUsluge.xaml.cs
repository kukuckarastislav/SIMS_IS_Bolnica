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
    /// <summary>
    /// Interaction logic for EvidentiranjeUsluge.xaml
    /// </summary>
    public partial class EvidentiranjeUsluge : Page
    {
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;
        public LekarDTO LekarDTO { get; set; }
        public string RezultatUsluge { get; set; }
        public RadniKalendarDTO OdabranaUsluga { get; set; }

        public EvidentiranjeUsluge(LekarDTO LekarDTO, RadniKalendarDTO OdabranaUsluga)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.LekarDTO = LekarDTO;
            this.RezultatUsluge = RezultatUsluge;

            ImePacijenta.Text = "Pacijent: " + OdabranaUsluga.ImePacijenta.ToString();
            TipUsluge.Text = OdabranaUsluga.Usluga.TipUsluge.ToString();
            Prostorija.Text = OdabranaUsluga.NazivProstorije.ToString();
            VremePocetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Pocetak.ToString("MM/dd/yyyy HH:mm:ss");
            VremeZavrsetkaUsluge.Text = OdabranaUsluga.Usluga.Termin.Kraj.ToString("MM/dd/yyyy HH:mm:ss");
            RazlogZakazivanja.Text = OdabranaUsluga.Usluga.RazlogZakazivanja.ToString();

            if(DateTime.Compare(DateTime.Now,OdabranaUsluga.Usluga.Termin.Pocetak) <0)
            {
                Potvrdi.IsEnabled = false;
            }
            else
            {
                Potvrdi.IsEnabled = true;
            }

            if (OdabranaUsluga.Usluga.RezultatUsluge != null)
            {
                Anamneza.Text = OdabranaUsluga.Usluga.RezultatUsluge.ToString();
            }
            
        }

        private void EvidentirajUslugu(object sender, RoutedEventArgs e)
        {
            RezultatUsluge = Anamneza.Text;
            OdabranaUsluga.Usluga.Obavljena = true;
            Repozitorijum.ZdravstvenaUslugaRepozitorijum.GetInstance.EvidentirajUslugu(OdabranaUsluga.Usluga,RezultatUsluge);
            refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
            NavigationService.Navigate(refRadniKalendar);

        }

        private void OdustaniButton(object sender, RoutedEventArgs e)
        {
            if (this.LekarDTO != null)
            {
                refRadniKalendar = new view.lekar.pacijenti.RadniKalendar(LekarDTO);
                NavigationService.Navigate(refRadniKalendar);
            }
        }
    }
}
