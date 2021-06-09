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
    /// <summary>
    /// Interaction logic for IzdavanjeRecepta.xaml
    /// </summary>
    public partial class IzdavanjeRecepta : Page
    {
        public PacijentDTO PacijentDTO { get; set; }
        public ObservableCollection<Recept> Recepti { get; set; }
        public ObservableCollection<LekDTO> odobreniLekoviKolekcija;
        public ObservableCollection<string> KolekcijaAlergeniLeka;
        public ObservableCollection<string> KolekcijaAlergeniPacijenta;
        public LekoviKontroler lekoviKontrolerObjekat;

        public PacijentKontroler PacijentKontrolerObjekat;
        public Lek OdabraniLek { get; set; }
        public LekarDTO LekarDTO;
        private view.lekar.pacijenti.PrikazMedicinskiKarton refPrikazMedicinskiKarton;
        private view.lekar.pacijenti.NacinKoriscenja refNacinKoriscenja;

        private ParametriUzimanjaTerapijeDTO dto;
        public IzdavanjeRecepta(LekarDTO LekarDTO, PacijentDTO PacijentDTO)
        {
            this.LekarDTO = LekarDTO;
            this.PacijentDTO = PacijentDTO;
            InitializeComponent();
            lekoviKontrolerObjekat = new LekoviKontroler();

            List<LekDTO> lekoviLista = lekoviKontrolerObjekat.GetOdobreniLekovi();
            foreach (LekDTO lek in lekoviLista)
            {
                this.odobreniLekoviKolekcija.Add(lek);
            }
            this.ComboBoxLek.ItemsSource = odobreniLekoviKolekcija;
            PacijentKontrolerObjekat = new PacijentKontroler();

            KolekcijaAlergeniLeka = new ObservableCollection<string>();
            KolekcijaAlergeniPacijenta = new ObservableCollection<string>();
            DataGridAlergeniLeka.Visibility = Visibility.Hidden;
            DataGridAlergeniPacijenta.Visibility = Visibility.Visible;


            UcitajPodatke();
        }

        private void UcitajPodatke()
        {

            ComboBoxLek.ItemsSource = odobreniLekoviKolekcija;
            headerIme.Text = PacijentDTO.Ime;
            headerPrezime.Text = PacijentDTO.Prezime;
            headerJMBG.Text = PacijentDTO.Jmbg;

            int idPacijenta = PacijentDTO.Id;
            

            foreach (string alergen in PacijentKontrolerObjekat.GetAlergeniPacijenta(idPacijenta))
            {
                KolekcijaAlergeniPacijenta.Add(alergen);
            }

            DataGridAlergeniPacijenta.ItemsSource = KolekcijaAlergeniPacijenta;

        }

        private void IzdavanjeReceptaButton(object sender, RoutedEventArgs e)
        {

            DateTime DatumPropisivanja = new DateTime(DateTime.Now.Year,DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


            OdabraniLek = ComboBoxLek.SelectedItem as Lek;
            string nacin_koriscenja = NacinKorsicenja.Text;
            Kontroler.ReceptKontroler ReceptKontroler = new Kontroler.ReceptKontroler();
            int idRec = ReceptKontroler.GetAll().Count + 1;
            int idLekarDTO = LekarDTO.Id;
            int idPac = PacijentDTO.Id;
            int idLeka = OdabraniLek.Id;

            Recept r = new Recept(idRec, idLekarDTO, idPac, idLeka, DatumPropisivanja, DatumPropisivanja, false, nacin_koriscenja);


           // Recept r = new Recept(2,2,1,2, DatumPropisivanja, DatumPropisivanja,false,"po zelji");
           // Servis.NotifikacijeServis.ReceptNotifikacija(r,vrijemeUzimanja);
            ReceptKontroler.DodajRecept(r);
            //Recepti = new ObservableCollection<Recept>();


        }

        private void PrikazMedicinskiKartonButton(object sender, RoutedEventArgs e)
        {
            if (PacijentDTO != null)
            {
                refPrikazMedicinskiKarton = new view.lekar.pacijenti.PrikazMedicinskiKarton(LekarDTO, PacijentDTO);
                NavigationService.Navigate(refPrikazMedicinskiKarton);
            }
        }

        private void ComboBoxLek_DropDownClosed(object sender, EventArgs e)
        {
            if (ComboBoxLek.SelectedItem != null)
            {
                OdabraniLek = (Lek)ComboBoxLek.SelectedItem;
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
                refNacinKoriscenja = new view.lekar.pacijenti.NacinKoriscenja(LekarDTO, PacijentDTO, OdabraniLek.Id);
                NavigationService.Navigate(refNacinKoriscenja);
                dto = NacinKoriscenja.dto;
            }
        }
    }
}
