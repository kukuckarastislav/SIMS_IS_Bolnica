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
using Model;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for Ocjene.xaml
    /// </summary>
    public partial class Ocjene : Window
    {
        public Pacijent Pacijent;
        private ObservableCollection<DTO.OcenaDTO> ListaOcene;
        private Controller.AnketaKontroler Kontroler;
        public ObservableCollection<Lekar> listaLekari { get; set; }

        public Ocjene(Pacijent Pacijent)
        {
            Kontroler = new Controller.AnketaKontroler();
            this.Pacijent = Pacijent;
            InitializeComponent();
            ListaOcene = Kontroler.GetSveOceneLekara();
            this.listaOcjena.ItemsSource = ListaOcene;
            listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
    }

        private void prikazi_ocene_lekara(object sender, RoutedEventArgs e)
        {
            Lekar OdabraniLekar = ComboBoxLekari.SelectedItem as Lekar;
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
