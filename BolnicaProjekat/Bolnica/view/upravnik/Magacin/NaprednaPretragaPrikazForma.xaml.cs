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
using System.Windows.Shapes;
using Kontroler;
using DTO;
using System.Collections.ObjectModel;

namespace Bolnica.view.upravnik.Magacin
{
    /// <summary>
    /// Interaction logic for NaprednaPretragaPrikazForma.xaml
    /// </summary>
    public partial class NaprednaPretragaPrikazForma : Window
    {
        private InventariKontroler inventariKontrolerObjekat;
        private ObservableCollection<OpremaDTO> lOpremeDTO;
        private ParametriNaprednePretrageDTO parametriPretrage;
        public NaprednaPretragaPrikazForma()
        {
            InitializeComponent();
            parametriPretrage = new ParametriNaprednePretrageDTO(inputNaziv.Text, inputSifra.Text, Convert.ToDouble(inputCenaOd.Text), Convert.ToDouble(inputCenaDo.Text),
                Convert.ToInt32(inputKolicinaOd.Text), Convert.ToInt32(inputKolicinaDo.Text), 
                Convert.ToBoolean(checkMagacin.IsChecked), Convert.ToBoolean(checkBolnicka.IsChecked),
                Convert.ToBoolean(checkBolesnickaSoba.IsChecked), Convert.ToBoolean(checkOpracionaSala.IsChecked),
                Convert.ToBoolean(checkSobaZaPreglede.IsChecked),
                Convert.ToBoolean(checkStaticka.IsChecked), Convert.ToBoolean(checkDinamicka.IsChecked));

            inventariKontrolerObjekat = new InventariKontroler();
            lOpremeDTO = inventariKontrolerObjekat.GetOpremaByNaprednaPretraga(parametriPretrage);
            DataGridPrikazOpremeNapredno.ItemsSource = lOpremeDTO; 

        }

        public void azurirajPrikaz()
        {
            lOpremeDTO = inventariKontrolerObjekat.GetOpremaByNaprednaPretraga(parametriPretrage);
            DataGridPrikazOpremeNapredno.ItemsSource = lOpremeDTO;
        }

        private void Pretraga_click(object sender, RoutedEventArgs e)
        {

            parametriPretrage.PretragaNaziv = inputNaziv.Text;
            parametriPretrage.PretragaSifra = inputSifra.Text;
            try
            {
                parametriPretrage.CenaOd = Convert.ToDouble(inputCenaOd.Text);
                parametriPretrage.CenaDo = Convert.ToDouble(inputCenaDo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Molimo vas unesite broj za pretragu cene");
                return;
            }

            try
            {
                parametriPretrage.KolicinaOd = Convert.ToInt32(inputKolicinaOd.Text);
                parametriPretrage.KolicinaDo = Convert.ToInt32(inputKolicinaDo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Molimo vas unesite broj za pretragu Kolicine");
                return;
            }
            
            if(parametriPretrage.KolicinaOd > parametriPretrage.KolicinaDo)
            {
                MessageBox.Show("Kolicina od je veca od kolicine do");
                return;
            }

            if (parametriPretrage.CenaOd > parametriPretrage.CenaDo)
            {
                MessageBox.Show("Cena od je veca od cene do");
                return;
            }


            parametriPretrage.CheckMagacin = Convert.ToBoolean(checkMagacin.IsChecked);
            parametriPretrage.CheckBolnicka = Convert.ToBoolean(checkBolnicka.IsChecked);
            parametriPretrage.CheckBolesnickaSoba = Convert.ToBoolean(checkBolesnickaSoba.IsChecked);
            parametriPretrage.CheckOpracionaSala = Convert.ToBoolean(checkOpracionaSala.IsChecked);
            parametriPretrage.CheckSobaZaPreglede = Convert.ToBoolean(checkSobaZaPreglede.IsChecked);
            parametriPretrage.CheckStaticka = Convert.ToBoolean(checkStaticka.IsChecked);
            parametriPretrage.CheckDinamicka = Convert.ToBoolean(checkDinamicka.IsChecked);

            azurirajPrikaz();
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
