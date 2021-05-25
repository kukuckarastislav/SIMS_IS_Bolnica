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
using Model;
using Kontroler;
using System.Collections.ObjectModel;
using DTO;

namespace Bolnica.view.upravnik.Lekovi
{
    /// <summary>
    /// Interaction logic for IzmeniLek.xaml
    /// </summary>
    public partial class IzmeniLek : Window
    {
        public LekarKontroler lekarKontrolerObjekat;
        public LekoviKontroler lekoviKontrolerObjekat;
        public ObservableCollection<string> KolekcijaAlergeni;
        public ObservableCollection<LekarRevizijaLekaDTO> KolekcijaLekaraCombo;
        public ObservableCollection<LekarRevizijaLekaDTO> KolekcijaLekaraDataGrid;
        public List<RevizijaLeka> RevizijeLekara;
        public PrikazNeodobrenihLekova refPrikazNeodobrenihLekova;
        public PrikazOdobrenihLekova refPrikazOdobrenihLekova;
        public Lek lek;

        public IzmeniLek(PrikazNeodobrenihLekova refPrikazNeodobrenihLekova,
                        PrikazOdobrenihLekova refPrikazOdobrenihLekova,
                        Lek lek)
        {
            InitializeComponent();

            this.lek = lek;
            this.refPrikazNeodobrenihLekova = refPrikazNeodobrenihLekova;
            this.refPrikazOdobrenihLekova = refPrikazOdobrenihLekova;
            lekarKontrolerObjekat = new LekarKontroler();
            lekoviKontrolerObjekat = new LekoviKontroler();

            KolekcijaLekaraCombo = lekarKontrolerObjekat.GetLekariDTOzaComboBox();
            ComboLekar.ItemsSource = KolekcijaLekaraCombo;

            KolekcijaLekaraDataGrid = new ObservableCollection<LekarRevizijaLekaDTO>();
            RevizijeLekara = new List<RevizijaLeka>();
            KolekcijaAlergeni = new ObservableCollection<string>();
            inputPoruka.Text = "Poruka ... ";

            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            inputNaziv.Text = lek.Naziv;
            inputSifra.Text = lek.Sifra;
            inputKolicina.Text = Convert.ToString(lek.Kolicina);
            inputCena.Text = Convert.ToString(lek.Cena);
            inputOpis.Text = lek.Opis;

            foreach(LekarRevizijaLekaDTO lekar in KolekcijaLekaraCombo)
            {
                if (lek.PostojiLekarURevizijiByID(lekar.IdLekara))
                {
                    // nov lekar??
                    KolekcijaLekaraDataGrid.Add(lekar);
                }
            }
            AzurirajPrikazDataGridLekari();
            
            
            foreach(string alergen in lek.Alergeni)
            {
                KolekcijaAlergeni.Add(alergen);
            }
            AzurirajPrikazAlergena();

            foreach(RevizijaLeka revizija in lek.Revizije)
            {
                RevizijeLekara.Add(new RevizijaLeka(revizija.IdLekara, revizija.StatusRevizije, revizija.Poruka));
            }
        }

        private void odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Potvrdi_click(object sender, RoutedEventArgs e)
        {
            List<string> alergeni = new List<string>();
            foreach (string alergen in KolekcijaAlergeni)
            {
                alergeni.Add(alergen);
            }

            foreach(RevizijaLeka rev in RevizijeLekara)
            {
                MessageBox.Show("LEKAR:" + rev.IdLekara + " status:" + rev.StatusRevizije);
            }

            foreach(RevizijaLeka r in lek.Revizije)
            {
                foreach(RevizijaLeka rev in RevizijeLekara)
                {
                    if(r.IdLekara == rev.IdLekara)
                    {
                        rev.StatusRevizije = r.StatusRevizije;
                    }
                }
            }

            lekoviKontrolerObjekat.IzmeniLek(lek.Id,
                                            inputNaziv.Text,
                                            inputSifra.Text,
                                            Convert.ToInt32(inputKolicina.Text),
                                            Convert.ToDouble(inputCena.Text),
                                            inputOpis.Text,
                                            RevizijeLekara,
                                            alergeni
                                            );

            if (refPrikazNeodobrenihLekova != null) refPrikazNeodobrenihLekova.AzurirajPrikaz();
            if (refPrikazOdobrenihLekova != null) refPrikazOdobrenihLekova.AzurirajPrikaz();
            this.Close();
        }

        private RevizijaLeka GetRevizjaLekaByIDLekara(int idLekar)
        {
            foreach (RevizijaLeka revizija in RevizijeLekara)
            {
                if (revizija.IdLekara == idLekar)
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
                selektovanLekarIzDataGrida.SetStatusRevizije(revizija.StatusRevizije);
                AzurirajPrikazDataGridLekari();
            }
        }

        private void comboLekar_DropDownClosed(object sender, EventArgs e)
        {
            // niosta za sada
        }

        private bool LekarJosNijeDodat(LekarRevizijaLekaDTO noviLekar)
        {
            foreach (LekarRevizijaLekaDTO odabranLekar in KolekcijaLekaraDataGrid)
            {
                if (odabranLekar.IdLekara == noviLekar.IdLekara)
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
            LekarRevizijaLekaDTO selektovanLekarIzComboBox = (LekarRevizijaLekaDTO)ComboLekar.SelectedItem;

            if (selektovanLekarIzComboBox != null)
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
            LekarRevizijaLekaDTO selektovanLekarIzDataGrida = (LekarRevizijaLekaDTO)DataGridPrikazLekara.SelectedItem;

            if (selektovanLekarIzDataGrida != null)
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
    }
}
