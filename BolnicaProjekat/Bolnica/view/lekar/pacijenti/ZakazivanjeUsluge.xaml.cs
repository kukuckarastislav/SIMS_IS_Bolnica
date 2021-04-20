using Kontroler;
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
    /// Interaction logic for ZakazivanjeUsluge.xaml
    /// </summary>
    public partial class ZakazivanjeUsluge : Page
    {
        public ProstorijeKontroler ProstorijeKontrolerObjekat { get; set; }
        public ObservableCollection<Prostorija> KolekcijaSobeZaPregled { get; set; }
        public ObservableCollection<String> KolekcijaIDSobeZaPregled { get; set; }
        public ObservableCollection<Prostorija> KolekcijaOperacionaSala { get; set; }
        public ObservableCollection<String> KolekcijaIDOperacionaSala { get; set; }
        private Pacijent IzabraniPacijent;

        public ZakazivanjeUsluge(Model.Pacijent izabraniPacijent)
        {
            ProstorijeKontrolerObjekat = new ProstorijeKontroler();
            this.IzabraniPacijent = izabraniPacijent;
            



            InitializeComponent();
        }

        private void PotvrdiZakazanuUsluguButton(object sender, RoutedEventArgs e)
        {
            // Termin termin, int id, int idLekara, int idPacijenta,TipUsluge tipUsluge, int idProstorije, bool obavljena, string razlogZakazivanja, string rezultatUsluge
            ZdravstvenaUsluga kreiranaUsluga;
            if (rbPregled.IsChecked == true)
            {
               //sdf kreiranaUsluga.TipUsluge = TipUsluge.Pregled;
            }
        }
    }
}
