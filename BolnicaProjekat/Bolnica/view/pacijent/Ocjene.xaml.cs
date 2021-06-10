using System.Collections.ObjectModel;
using System.Windows;
using DTO;
using Kontroler;

namespace Bolnica.view.pacijent
{

    public partial class Ocjene : Window
    {
        private PacijentDTO Pacijent;
        private ObservableCollection<OcenaDTO> ListaOcene;
        private Controller.AnketaKontroler Kontroler;
        private ObservableCollection<LekarDTO> listaLekari;

        public Ocjene(PacijentDTO Pacijent)
        {
            Kontroler = new Controller.AnketaKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();

            ListaOcene = Kontroler.GetSveOceneLekara();
            this.listaOcjena.ItemsSource = ListaOcene;

            LekarKontroler k = new LekarKontroler();
            listaLekari = k.getAllNeobrisaniLekari();
            this.ComboBoxLekari.ItemsSource = listaLekari;
    }

        private void prikazi_ocene_lekara(object sender, RoutedEventArgs e)
        {
            LekarDTO OdabraniLekar = ComboBoxLekari.SelectedItem as LekarDTO;

            if (OdabraniLekar != null)
            {
                ListaOcene = Kontroler.GetOceneOdabranogLekara(OdabraniLekar.Id);
                this.listaOcjena.ItemsSource = ListaOcene;
            }
            else
            {
                MessageBox.Show("Niste odabrali lekara");
            }
        }

        private void MenuItem_Click_ocene_lekara(object sender, RoutedEventArgs e)
        {
            ListaOcene = Kontroler.GetSveOceneLekara();
            this.listaOcjena.ItemsSource = ListaOcene;
        }

        private void MenuItem_Click_ocene_bolnice(object sender, RoutedEventArgs e)
        {
            ListaOcene = Kontroler.GetSveOceneBolnice();
            this.listaOcjena.ItemsSource = ListaOcene;
        }

        private void MenuItem_Click_moje_ocene(object sender, RoutedEventArgs e)
        {
            ListaOcene = Kontroler.GetSveOcenePacijenta(Pacijent.Id);
            this.listaOcjena.ItemsSource = ListaOcene;
        }
    }
}
