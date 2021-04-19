using Model;
using Repozitorijum;
using Servis;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowZakazivanjeTermina.xaml
    /// </summary>
    public partial class WindowZakazivanjeTermina : Window
    {

        private List<Model.ZdravstvenaUsluga> PreglediList { get; set; }
        private ObservableCollection<ZdravstvenaUsluga> Pregledi { get; set; }
        private ZdravstvenaUsluga odabranaUsluga;
        private DateTime date;
        //private Lekar OdabraniLekar;

        private ObservableCollection<Model.Lekar> listaLekari;
        private Pacijent pacijent;
        public WindowZakazivanjeTermina(Pacijent pacijent)
        {
            InitializeComponent();
            /*
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            DateTime pocetak = new DateTime(2021, 4, 19, 8, 0, 00);
            DateTime kraj = new DateTime(2021, 4, 19, 16, 0, 00);
            PreglediList = ZdravstvenaUslugaServis.getAppointments(LekarRepozitorijum.GetInstance.GetById(1),pocetak,kraj);
            foreach(var usluga in PreglediList)
            {
                Pregledi.Add(usluga);
            }
            this.listaPregleda.ItemsSource = Pregledi;
            */
            datePicker.SelectedDate = DateTime.Now;
            listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
            this.pacijent = pacijent;
            rbPregled.IsChecked = true;
        }

        private void UcitajTermine_Click(object sender, RoutedEventArgs e)
        {
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            Lekar odabraniLekar = this.ComboBoxLekari.SelectedItem as Lekar;
            if (odabraniLekar == null) return;

            if (datePicker.SelectedDate == null) return;
            DateTime temp = (DateTime)datePicker.SelectedDate;
            if (temp == null) return;
            DateTime pocetak = new DateTime(temp.Year, temp.Month, temp.Day, 0, 0, 00);
            DateTime kraj = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 00);
            PreglediList = ZdravstvenaUslugaServis.getAppointments(odabraniLekar, pocetak, kraj);
            foreach (var usluga in PreglediList)
            {
                Pregledi.Add(usluga);
            }
            this.listaPregleda.ItemsSource = Pregledi;


        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            if (Pregledi == null) return;
            ZdravstvenaUsluga usluga = listaPregleda.SelectedItem as ZdravstvenaUsluga;
            usluga.IdPacijenta = pacijent.Id;
            if (rbPregled.IsChecked==true)
                usluga.TipUsluge = TipUsluge.Pregled;
            else
                usluga.TipUsluge = TipUsluge.Operacija;
            usluga.Id = ZdravstvenaUslugaRepozitorijum.GetInstance.getAll().Count + 1;
            MessageBox.Show("Termin je uspesno zauzet.");
            ZdravstvenaUslugaRepozitorijum.GetInstance.DodajUslugu(usluga);
        }
    }
}
