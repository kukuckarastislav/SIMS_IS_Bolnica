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
using Model;
using Kontroler;
using System.Collections.ObjectModel;

namespace Bolnica.view.lekar.lekovi
{
    /// <summary>
    /// Interaction logic for IzmenaLeka.xaml
    /// </summary>
    public partial class IzmenaLeka : Page
    {


        public LekoviKontroler lekoviKontrolerObjekat;
        public ObservableCollection<string> KolekcijaAlergeni;
        private Lek lek;
        private RevizijaLeka revizija;
        private Lekar lekar;

        public IzmenaLeka(Lek lek, Lekar lekar)
        {
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();
            this.lek = lek;
            KolekcijaAlergeni = new ObservableCollection<string>();
            RevizijaLeka tempRevizija= lek.GetRevizijaLekaByIdLekara(lekar.Id);
            revizija = new RevizijaLeka(tempRevizija.IdLekara, tempRevizija.StatusRevizije, tempRevizija.Poruka);
            this.lekar = lekar;

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

        private void Dodaj_alergen_click(object sender, RoutedEventArgs e)
        {
            string noviAlergen = inputAlergen.Text;
            if (!KolekcijaAlergeni.Contains(noviAlergen) && !string.IsNullOrWhiteSpace(noviAlergen))
            {
                KolekcijaAlergeni.Add(noviAlergen);
                AzurirajPrikazAlergena();
            }
        }

        private void AzurirajPrikazAlergena()
        {
            DataGridPrikazAlergena.ItemsSource = KolekcijaAlergeni;
        }

        private void Ukloni_alergen_click(object sender, RoutedEventArgs e)
        {
            string selektovanAlergen = (string)DataGridPrikazAlergena.SelectedItem;
            if (selektovanAlergen != null)
            {
                KolekcijaAlergeni.Remove(selektovanAlergen);
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


        private void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            List<string> alergeni = new List<string>();
            foreach (string alergen in KolekcijaAlergeni)
            {
                alergeni.Add(alergen);
            }
            revizija.Poruka = inputPoruka.Text;

            lekoviKontrolerObjekat.IzmenaLekaByLekar(lek.Id,
                                            inputNaziv.Text,
                                            inputSifra.Text,
                                            Convert.ToDouble(inputCena.Text),
                                            inputOpis.Text,
                                            revizija,
                                            alergeni
                                            );

            if (this.lekar != null)
            {
                var lekoviPage = new Lekovi(lekar);
                NavigationService.Navigate(lekoviPage);
            }
        }

    }
}
