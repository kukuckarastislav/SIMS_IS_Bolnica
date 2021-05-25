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

namespace Bolnica.view.lekar.lekovi
{
    /// <summary>
    /// Interaction logic for OdbijanjeLeka.xaml
    /// </summary>
    public partial class OdbijanjeLeka : Page

    {

        public LekoviKontroler lekoviKontrolerObjekat;
        public ObservableCollection<string> KolekcijaAlergeni;
        private Lek lek;
        private Lekar lekar;
        private RevizijaLeka revizija;

        public OdbijanjeLeka(Lek lek, Lekar lekar)
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            KolekcijaAlergeni = new ObservableCollection<string>();
            this.lek = lek;
            this.lekar = lekar;
            RevizijaLeka tempRevizija = lek.GetRevizijaLekaByIdLekara(lekar.Id);
            revizija = new RevizijaLeka(tempRevizija.IdLekara, tempRevizija.StatusRevizije, tempRevizija.Poruka);
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            inputNaziv.Text = lek.Naziv;
            inputSifra.Text = lek.Sifra;
            inputCena.Text = Convert.ToString(lek.Cena);
            inputOpis.Text = lek.Opis;

            foreach (string alergen in lek.Alergeni)
            {
                KolekcijaAlergeni.Add(alergen);
            }
            AzurirajPrikazAlergena();

            inputPoruka.Text = revizija.Poruka;
            if (lek.JeOdobren())
            {
                statusLeka.Text = "Odobren";
            }
            else
            {
                statusLeka.Text = "Nije odobren";
            }


        }

        private void AzurirajPrikazAlergena()
        {
            DataGridPrikazAlergena.ItemsSource = KolekcijaAlergeni;
        }


        private void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            revizija.StatusRevizije = -1;
            lekoviKontrolerObjekat.LekarOdobravaLek(lek.Id, revizija);

            if (this.lekar != null)
            {
                var lekoviPage = new Lekovi(lekar);
                NavigationService.Navigate(lekoviPage);
            }
        }

        private void Odustani_click(object sender, RoutedEventArgs e)
        {
            if (this.lekar != null)
            {
                var lekoviPage = new Lekovi(lekar);
                NavigationService.Navigate(lekoviPage);
            }
        }
    }
}
