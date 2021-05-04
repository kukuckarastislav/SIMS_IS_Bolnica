using Kontroler;
using Repozitorijum;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PagePacijenti.xaml
    /// </summary>
    public partial class PagePacijenti : Page
    {
        public ObservableCollection<Pacijent> KolekcijaPacijenata { get; set; }
        public ObservableCollection<Pacijent> listaPacijenata;
        
        public PagePacijenti()
        {
           //KolekcijaPacijenata = PacijentRepozitorijum.GetInstance.GetAll();
            InitializeComponent();

            KolekcijaPacijenata = new ObservableCollection<Pacijent>();
            PacijentKontroler kontorler = new PacijentKontroler();
            listaPacijenata = kontorler.GetAll();

            foreach(Pacijent p in listaPacijenata)
            {

                if(!p.LogickiObrisan) KolekcijaPacijenata.Add(p);
            }

            this.DataGridPrikazPacijenata.ItemsSource = KolekcijaPacijenata;
        }

        private void IzmeniPacijenta_Click(object sender, RoutedEventArgs e)
        {

            Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Pacijent;
            if (pacijent == null) return;

            var izmeniPacijentaWindow = new Bolnica.view.sekretar.WindowIzmenaPodataka(pacijent, DataGridPrikazPacijenata);
            izmeniPacijentaWindow.Show();

        }

        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Pacijent;
            if (pacijent == null) return;

            var zakaziTerminPage = new WindowZakazivanjeTermina(pacijent,null,null);
            zakaziTerminPage.Show();


        }

        private void ObrisiPacijenta_Click(object sender, RoutedEventArgs e)
        {
            Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Pacijent;
            if (pacijent == null) return;

            PacijentKontroler kontroler = new PacijentKontroler();
            kontroler.ObrisiPacijenta(pacijent);
            KolekcijaPacijenata.Remove(pacijent);
            MessageBox.Show("Pacijent je uspesno obrisan.");
        }
        
        private void PogledajTermine_Click(object sender, RoutedEventArgs e)
        {
            Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Pacijent;
            if (pacijent == null) return;

            var zakazaniTerminiPage = new ZakazaniTermini(pacijent);
            zakazaniTerminiPage.Show();
        }

        private void OtvoriMedicinskiKarton_Click(object sender, RoutedEventArgs e)
        {
            Pacijent pacijent = DataGridPrikazPacijenata.SelectedItem as Pacijent;
            if (pacijent == null) return;

            var medicinskiKartonWindow = new KartonPacijenta(pacijent);
            medicinskiKartonWindow.Show();
        }
    }
}
