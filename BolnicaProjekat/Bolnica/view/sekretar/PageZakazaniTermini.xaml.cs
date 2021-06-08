using Bolnica.utils;
using Kontroler;
using DTO;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageZakazaniTermini.xaml
    /// </summary>
    public partial class PageZakazaniTermini : Page
    {
        private ObservableCollection<ZakazaniTerminiDTO> KolekcijaTermina { get; set; }
        public PageZakazaniTermini()
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;
            inputDatumPretrage.SelectedDate = DateTime.Now;
            UcitajTermine((DateTime)inputDatumPretrage.SelectedDate);
        }

        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            var terminPage = new sekretar.ZakazivanjeTermina();
            NavigationService.Navigate(terminPage);
        }
        private void OtkaziTermin_Click(object sender, RoutedEventArgs e)
        {
            ZakazaniTerminiDTO dto = tableTermini.SelectedItem as ZakazaniTerminiDTO;
            if (dto == null) return;
            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            kontroler.OtkaziUslugu(dto);
            MessageBox.Show("Termin je uspešno otkazan.");
            if (inputDatumPretrage.SelectedDate != null)
                UcitajTermine((DateTime)inputDatumPretrage.SelectedDate);
            else
                UcitajTermine(DateTime.Now);
        }

        private void UcitajTermine(DateTime datumUcitavanja)
        {
            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            KolekcijaTermina = new ObservableCollection<ZakazaniTerminiDTO>();
            List<ZakazaniTerminiDTO> listaTermina = kontroler.getAllDto(datumUcitavanja);
            foreach(ZakazaniTerminiDTO dto in listaTermina)
            {
                KolekcijaTermina.Add(dto);
            }
            tableTermini.ItemsSource = KolekcijaTermina;
        }

        private void inputDatumPretrage_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(inputDatumPretrage.SelectedDate!=null)
                UcitajTermine((DateTime)inputDatumPretrage.SelectedDate);
        }

        private void OdloziTermin_Click(object sender, RoutedEventArgs e)
        {
            ZakazaniTerminiDTO dto = tableTermini.SelectedItem as ZakazaniTerminiDTO;
            if (dto == null) return;
            MessageBox.Show("Nije moguće odložiti termin u naredna tri dana.");
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("Ime");

            }
        }
    }
}
