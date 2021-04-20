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
using Bolnica;
using Bolnica.Controller;
using Controller;
using Kontroler;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowZakazivanjeTermina.xaml
    /// </summary>
    public partial class WindowZakazivanjeTermina : Window
    {

        private List<Model.ZdravstvenaUsluga> PreglediList { get; set; }
        private ObservableCollection<ZdravstvenaUsluga> Pregledi { get; set; }
        private DTOUslugaLekar StaraUsluga;
        private DateTime date;
        //private Lekar OdabraniLekar;

        private ObservableCollection<Model.Lekar> listaLekari;
        private ObservableCollection<DTOUslugaLekar> stariTermini;
        private Pacijent pacijent;
        public WindowZakazivanjeTermina(Pacijent pacijent, DTOUslugaLekar ul, ObservableCollection<DTOUslugaLekar> termini)
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
            LekarKontroler kontroler = new LekarKontroler();
            listaLekari = kontroler.GetAllObs();
            //listaLekari = Repozitorijum.LekarRepozitorijum.GetInstance.GetAllObs();
            this.ComboBoxLekari.ItemsSource = listaLekari;
            this.pacijent = pacijent;
            rbPregled.IsChecked = true;
            StaraUsluga = ul;
            stariTermini = termini;
        }

        private void UcitajTermine_Click(object sender, RoutedEventArgs e)
        {
            Pregledi = new ObservableCollection<ZdravstvenaUsluga>();
            Lekar odabraniLekar = this.ComboBoxLekari.SelectedItem as Lekar;
            if (odabraniLekar == null) return;

            if (datePicker.SelectedDate == null) return;
            DateTime temp = (DateTime)datePicker.SelectedDate;
            if (temp == null) return;
 
            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            PreglediList = kontroler.getAppointments(odabraniLekar,temp);
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

            ZdravstvenaUslugaKontroler zkontroler = new ZdravstvenaUslugaKontroler();
            ZdravstvenaUsluga novau = zkontroler.DodajUslugu(usluga);
            if (StaraUsluga != null) {
                zkontroler.OtkaziUslugu(StaraUsluga.Usluga);
                if (stariTermini != null) stariTermini.Remove(StaraUsluga);
                Lekar novil = Repozitorijum.LekarRepozitorijum.GetInstance.GetById(novau.IdLekara);
                this.stariTermini.Add(new DTOUslugaLekar(novau, novil));
            }
            MessageBox.Show("Termin je uspesno zauzet.");
            this.Close();
        }
    }
}
