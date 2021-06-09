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
using System.Windows.Shapes;
using DTO;
using Kontroler;
using System.IO;

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for DodajLek.xaml
    /// </summary>
    public partial class DodajLek : Window
    {
        public LekarKontroler lekarKontrolerObjekat;
        public LekoviKontroler lekoviKontrolerObjekat;
        public ObservableCollection<string> KolekcijaAlergeni;
        public ObservableCollection<LekarRevizijaLekaDTO> KolekcijaLekaraCombo;
        public ObservableCollection<LekarRevizijaLekaDTO> KolekcijaLekaraDataGrid;
        private List<RevizijaLeka> RevizijeLekara;
        private PrikazNeodobrenihLekova refPrikazNeodobrenihLekova;

        public DodajLek(PrikazNeodobrenihLekova refPrikazNeodobrenihLekova)
        {
            InitializeComponent();
            this.refPrikazNeodobrenihLekova = refPrikazNeodobrenihLekova;
            lekarKontrolerObjekat = new LekarKontroler();
            lekoviKontrolerObjekat = new LekoviKontroler();

            KolekcijaLekaraCombo = lekarKontrolerObjekat.GetLekariDTOzaComboBox();
            ComboLekar.ItemsSource = KolekcijaLekaraCombo;

            KolekcijaLekaraDataGrid = new ObservableCollection<LekarRevizijaLekaDTO>();
            RevizijeLekara = new List<RevizijaLeka>();
            KolekcijaAlergeni = new ObservableCollection<string>();
            inputPoruka.Text = "Poruka ... ";

        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            /*
            int id = Repozitorijum.LekoviRepozitorijum.GetInstance.GetAll().Count;
            Lek lek = new Lek(id+1,inputSifra.Text,inputNaziv.Text,false,inputOpis.Text,Convert.ToInt32(inputKolicina.Text),Convert.ToDouble(inputCena.Text));  //ovaj obj se ne pravi ovdje ali neka ga zasad
            Kontroler.LekoviKontroler Kontroler = new Kontroler.LekoviKontroler();
            Kontroler.DodajLek(lek);
            */

            List<string> alergeni = new List<string>();
            foreach(string alergen in KolekcijaAlergeni)
            {
                alergeni.Add(alergen);
            }
            LekDTO dto = new LekDTO(-1, inputSifra.Text, inputSifra.Text, false, inputOpis.Text, Convert.ToInt32(inputKolicina.Text), Convert.ToDouble(inputCena.Text), alergeni, RevizijeLekara);
            lekoviKontrolerObjekat.DodajLek(dto);


            if(refPrikazNeodobrenihLekova != null) refPrikazNeodobrenihLekova.AzurirajPrikaz();
            this.Close();
        }

        private RevizijaLeka GetRevizjaLekaByIDLekara(int idLekar)
        {
            foreach(RevizijaLeka revizija in RevizijeLekara)
            {
                if(revizija.IdLekara == idLekar)
                {
                    return revizija;
                }
            }
            return null;
        }

        private void DataGridPrikazLekara_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LekarRevizijaLekaDTO selektovanLekarIzDataGrida = (LekarRevizijaLekaDTO)DataGridPrikazLekara.SelectedItem;
            if (selektovanLekarIzDataGrida != null)
            {
                RevizijaLeka revizija = GetRevizjaLekaByIDLekara(selektovanLekarIzDataGrida.IdLekara);
                inputPoruka.Text = revizija.Poruka;
            }
        }

        private void comboLekar_DropDownClosed(object sender, EventArgs e)
        {
            // niosta za sada
        }

        private bool LekarJosNijeDodat(LekarRevizijaLekaDTO noviLekar)
        {
            foreach(LekarRevizijaLekaDTO odabranLekar in KolekcijaLekaraDataGrid)
            {
                if(odabranLekar.IdLekara == noviLekar.IdLekara)
                {
                    return false;
                }
            }
            return true;
        }

        private void AzurirajPrikazDataGridLekari()
        {
            DataGridPrikazLekara.ItemsSource = KolekcijaLekaraDataGrid;
        }

        private void Dodaj_lekara_click(object sender, RoutedEventArgs e)
        {
            LekarRevizijaLekaDTO selektovanLekarIzComboBox = (LekarRevizijaLekaDTO) ComboLekar.SelectedItem;

            if(selektovanLekarIzComboBox != null)
            {
                // dodati lekara na ovaj lek
                if (LekarJosNijeDodat(selektovanLekarIzComboBox))
                {
                    LekarRevizijaLekaDTO odabranLekarZaReviziju = new LekarRevizijaLekaDTO(selektovanLekarIzComboBox);
                    odabranLekarZaReviziju.StatusRevizije = "Na cekanju";
                    KolekcijaLekaraDataGrid.Add(odabranLekarZaReviziju);
                    RevizijeLekara.Add(new RevizijaLeka(odabranLekarZaReviziju.IdLekara, 0, "Poruka ..."));
                    AzurirajPrikazDataGridLekari();
                }
            }
        }

        private void Ukloni_lekara_click(object sender, RoutedEventArgs e)
        {
            LekarRevizijaLekaDTO selektovanLekarIzDataGrida = (LekarRevizijaLekaDTO) DataGridPrikazLekara.SelectedItem;

            if(selektovanLekarIzDataGrida != null)
            {
                RevizijaLeka revizija = GetRevizjaLekaByIDLekara(selektovanLekarIzDataGrida.IdLekara);
                RevizijeLekara.Remove(revizija);
                KolekcijaLekaraDataGrid.Remove(selektovanLekarIzDataGrida);
                inputPoruka.Text = "Poruka ... ";
            }
            AzurirajPrikazDataGridLekari();
        }

        private void Sacuvaj_poruku_click(object sender, RoutedEventArgs e)
        {
            LekarRevizijaLekaDTO selektovanLekarIzDataGrida = (LekarRevizijaLekaDTO)DataGridPrikazLekara.SelectedItem;
            if (selektovanLekarIzDataGrida != null)
            {
                RevizijaLeka revizija = GetRevizjaLekaByIDLekara(selektovanLekarIzDataGrida.IdLekara);
                revizija.Poruka = inputPoruka.Text;
            }
        }

        private void Dodaj_alergen_click(object sender, RoutedEventArgs e)
        {
            string noviAlergen = inputAlergen.Text;
            if (!KolekcijaAlergeni.Contains(noviAlergen) && !string.IsNullOrWhiteSpace(noviAlergen))
            {
                KolekcijaAlergeni.Add(noviAlergen);
                DataGridPrikazAlergena.ItemsSource = KolekcijaAlergeni;
            }
        }

        private void Ukloni_alergen_click(object sender, RoutedEventArgs e)
        {
            string selektovanAlergen = (string) DataGridPrikazAlergena.SelectedItem;
            if (selektovanAlergen != null)
            {
                KolekcijaAlergeni.Remove(selektovanAlergen);
            }
        }

    }
}
