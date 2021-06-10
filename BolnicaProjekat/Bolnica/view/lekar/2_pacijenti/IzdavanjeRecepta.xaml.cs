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
using Servis;
using DTO;


namespace Bolnica.view.lekar.pacijenti
{
    public partial class IzdavanjeRecepta : Page
    {
        public PacijentDTO PacijentDTO { get; set; }
        public ObservableCollection<LekDTO> odobreniLekoviKolekcija;
        public ObservableCollection<string> KolekcijaAlergeniLeka;
        public ObservableCollection<string> KolekcijaAlergeniPacijenta;

        public LekoviKontroler LekoviKontrolerObjekat;
        public PacijentKontroler PacijentKontrolerObjekat;
        public ReceptKontroler ReceptKontrolerObjekat;

        public LekDTO OdabraniLek { get; set; }
        public LekarDTO LekarDTO { get; set; }
        private ParametriUzimanjaTerapijeDTO dto;
        public IzdavanjeRecepta(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;
            InitializeComponent();
            KreirajKolekcije();
            KreirajKonrtolere();
            UcitajPodatke();

        }


        private void KreirajKolekcije()
        {
            KolekcijaAlergeniLeka = new ObservableCollection<string>();
            odobreniLekoviKolekcija = new ObservableCollection<LekDTO>();
            KolekcijaAlergeniPacijenta = new ObservableCollection<string>();
        }

        private void KreirajKonrtolere()
        {
            LekoviKontrolerObjekat = new LekoviKontroler();
            ReceptKontrolerObjekat = new ReceptKontroler();
            PacijentKontrolerObjekat = new PacijentKontroler();
        }
        private void UcitajPodatke()
        {
            UcitajOdobreneLekove();
            UcitajAlergenePacijenta();
            UcitajHeader();
            UcitajDataGridove();
        }

        private void UcitajHeader()
        {
            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;
        }

        private void UcitajAlergenePacijenta()
        {
            int idPacijenta = PacijentDTO.Id;
            foreach (string alergen in PacijentKontrolerObjekat.GetAlergeniPacijenta(idPacijenta))
            {
                KolekcijaAlergeniPacijenta.Add(alergen);
            }
            DataGridAlergeniPacijenta.ItemsSource = KolekcijaAlergeniPacijenta;

        }

        private void UcitajOdobreneLekove()
        {
            List<LekDTO> lekoviLista = LekoviKontrolerObjekat.GetOdobreniLekovi();
            foreach (LekDTO lek in lekoviLista)
            {
                this.odobreniLekoviKolekcija.Add(lek);
            }
            this.ComboBoxLek.ItemsSource = odobreniLekoviKolekcija;
        }

        private void UcitajDataGridove()
        {
            DataGridAlergeniLeka.Visibility = Visibility.Hidden;
            DataGridAlergeniPacijenta.Visibility = Visibility.Visible;
        }

        private void IzdavanjeReceptaButton(object sender, RoutedEventArgs e)
        {

            DateTime DatumPropisivanja = new DateTime();
            DateTime DatumIsteka = new DateTime();
            DatumPropisivanja = DateTime.Now;
            DatumIsteka = datum_isteka.SelectedDate.Value;
            OdabraniLek = ComboBoxLek.SelectedItem as LekDTO;
            int idRec = ReceptKontrolerObjekat.GetAll().Count + 1;
            int idLekarDTO = LekarDTO.Id;
            int idPac = PacijentDTO.Id;
            int idLeka = OdabraniLek.Id;
            string imePrezimeLekara = LekarDTO.ImePrezime();
            string nazivLeka = OdabraniLek.Naziv;
            string komentar = Komentar.Text;
            double cenaLeka = OdabraniLek.Cena;
            int kolicinaLeka = OdabraniLek.Kolicina;
            ReceptDTO r = new ReceptDTO(idRec, idLekarDTO, imePrezimeLekara, idPac, idLeka, nazivLeka, DatumPropisivanja, DatumIsteka, komentar, cenaLeka, kolicinaLeka);

            ReceptKontrolerObjekat.DodajRecept(r);

        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                var refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private void ComboBoxLek_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBoxLek.SelectedItem != null)
            {
                OdabraniLek = (LekDTO)ComboBoxLek.SelectedItem;
                DataGridAlergeniLeka.Visibility = Visibility.Visible;
                foreach (string alergen in OdabraniLek.Alergeni)
                {
                    KolekcijaAlergeniLeka.Add(alergen);
                }

                DataGridAlergeniLeka.ItemsSource = KolekcijaAlergeniLeka;
            }

            bool imaPresek = false;
            foreach (string presecniAlergen in KolekcijaAlergeniLeka)
            {
                if (KolekcijaAlergeniPacijenta.Contains(presecniAlergen) == true)
                {
                    PotvrdiRecept.IsEnabled = false;
                    ImaAlergijuTextBlock.Visibility = Visibility.Visible;
                    imaPresek = true;
                }
            }

            if (!imaPresek)
            {
                PotvrdiRecept.IsEnabled = true;
                NemaAlergijuTextBlock.Visibility = Visibility.Visible;
            }


        }

        private void NacinKorisnenjaButton_Click(object sender, RoutedEventArgs e)
        {
            if (OdabraniLek != null)
            {
                var refNacinKoriscenja = new view.lekar.pacijenti.NacinKoriscenja(LekarDTO, PacijentDTO, OdabraniLek.Id);
                NavigationService.Navigate(refNacinKoriscenja);
                dto = NacinKoriscenja.dto;
            }
        }
    }
}
