using Bolnica.Controller;
using Model;
using Repozitorijum;
using Servis;
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
using System.Windows.Shapes;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for ZakazaniTermini.xaml
    /// </summary>
    public partial class ZakazaniTermini : Window
    {
        private Pacijent odabraniPacijent;
        ObservableCollection<DTOUslugaLekar> termini;
        public ZakazaniTermini(Pacijent pacijent)
        {
            InitializeComponent();
            odabraniPacijent = pacijent;
            termini = ZdravstvenaUslugaServis.getUslugePacijenta(pacijent);
            this.DataGridPrikazTermina.ItemsSource = termini;
        }

        private void OtkaziTermin_Click(object sender, RoutedEventArgs e)
        {
            DTOUslugaLekar ul = DataGridPrikazTermina.SelectedItem as DTOUslugaLekar;
            if (ul == null) return;

            ZdravstvenaUslugaRepozitorijum.GetInstance.ObrisiUslugu(ul.Usluga);

            NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            kontroler.NotifikujOtkazaniTermin(ul.Usluga);
            MessageBox.Show("Termin je uspesno otkazan.");
            //NotifikacijaKontroler kontroler = new NotifikacijaKontroler();
            //  kontroler.NotifikujZakazaniTermin(usluga);
        }
    }
}
