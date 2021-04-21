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
    /// Interaction logic for AzuriranjeUsluge.xaml
    /// </summary>
    public partial class AzuriranjeUsluge : Page
    {

        // BACK - PAGES
        private view.lekar.pacijenti.RadniKalendar refRadniKalendar;

        public DateTime NoviPocetak;
        public Lekar Lekar;
        public ZdravstvenaUsluga OdabranaUsluga;

        public AzuriranjeUsluge(Lekar Lekar, ZdravstvenaUsluga OdabranaUsluga)
        {
            InitializeComponent();
            this.OdabranaUsluga = OdabranaUsluga;
            this.Lekar = Lekar;

            TipUsluge.Text = (OdabranaUsluga.TipUsluge).ToString();
            Prostorija.Text = (Repozitorijum.ProstorijeRepozitorijum.GetInstance.GetProstorijaById(OdabranaUsluga.IdProstorije).BrojSprat).ToString();
            VremePocetkaUsluge.Text = (OdabranaUsluga.Termin.Pocetak).ToString("dddd, dd MMMM yyyy") + " - " + (OdabranaUsluga.Termin.Pocetak).ToString("hh:mm tt");
            VremeZavrsetkaUsluge.Text = (OdabranaUsluga.Termin.Kraj).ToString("dddd, dd MMMM yyyy") + " - " + (OdabranaUsluga.Termin.Kraj).ToString("hh:mm tt");
            RazlogZakazivanja.Text = (OdabranaUsluga.RazlogZakazivanja).ToString();
        }

    }
}
