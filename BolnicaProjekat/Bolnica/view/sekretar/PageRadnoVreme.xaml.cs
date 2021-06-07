using DTO;
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
using Kontroler;
using Model;
using Controller;
using System.Collections.ObjectModel;
using Bolnica.DTO;
using Bolnica.utils;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageRadnoVreme.xaml
    /// </summary>
    public partial class PageRadnoVreme : Page
    {
        private LekarDTO lekarDto;
        private ObservableCollection<GodisnjiOdmorDTO> Odmori;
        private SlobodniDaniDTO slobodniDaniLekara;
        private ObservableCollection<DateTime> slobodniDani;
        public PageRadnoVreme(LekarDTO dto)
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;
            lekarDto = dto;
            datumOdmoraPocetak.SelectedDate = DateTime.Now;
            datumOdmoraKraj.SelectedDate = DateTime.Now;
            datumSlobodnogDana.SelectedDate = DateTime.Now;
            LoadGodisnjiOdmor();
            LoadRadnoVreme();
            LoadSlobodniDani();
        }

        public void LoadGodisnjiOdmor()
        {
            GodisnjiOdmorKontroler kontroler = new GodisnjiOdmorKontroler();
            Odmori = kontroler.GetOdmoriLekara(lekarDto.Id);
            listaOdmora.ItemsSource = Odmori;
        }
        public void LoadRadnoVreme()
        {
            GodisnjiOdmorKontroler kontroler = new GodisnjiOdmorKontroler();
            RadnoVreme vreme = kontroler.GetRadnoVremeLekara(lekarDto.Id);
            cmbPocetakRadnogVremena.SelectedIndex = vreme.PocetakRadnogVremena;
            cmbKrajRadnogVremena.SelectedIndex = vreme.KrajRadnogVremena;
        }

        private void DodajOdmor_Click(object sender, RoutedEventArgs e)
        {
            GodisnjiOdmorDTO dto = new GodisnjiOdmorDTO();
            if (datumOdmoraPocetak.SelectedDate == null || datumOdmoraKraj.SelectedDate == null) return;
            if(datumOdmoraPocetak.SelectedDate >= datumOdmoraKraj.SelectedDate)
            {
                MessageBox.Show("Datum završetka odmora ne može biti pre početka odmora.");
                return;
            }
            dto.Period = new Termin((DateTime)datumOdmoraPocetak.SelectedDate, (DateTime)datumOdmoraKraj.SelectedDate);
            GodisnjiOdmorKontroler kontroler = new GodisnjiOdmorKontroler();
            Odmori.Add(kontroler.DodajGodisnjiOdmor(lekarDto.Id, dto));
        }

        private void ObrisiOdmor_Click(object sender, RoutedEventArgs e)
        {
            GodisnjiOdmorDTO odmor = listaOdmora.SelectedItem as GodisnjiOdmorDTO;
            if (odmor == null) return;

            GodisnjiOdmorKontroler kontroler = new GodisnjiOdmorKontroler();
            kontroler.ObrisiGodisnjiOdmor(odmor.Id);
            Odmori.Remove(odmor);
        }

        private void IzmeniRadnoVreme_Click(object sender, RoutedEventArgs e)
        {
            if(cmbPocetakRadnogVremena.SelectedIndex >= cmbKrajRadnogVremena.SelectedIndex)
            {
                MessageBox.Show("Pocetak radnog vremena ne može biti pre kraja radnog vremena.");
                return;
            }
            RadnoVreme vreme = new RadnoVreme(cmbPocetakRadnogVremena.SelectedIndex, cmbKrajRadnogVremena.SelectedIndex);
            GodisnjiOdmorKontroler kontroler = new GodisnjiOdmorKontroler();
            kontroler.IzmeniRadnoVremeLekara(lekarDto.Id, vreme);
            MessageBox.Show("Radno vreme je uspešno izmenjeno.");
        }

        private void DodajSlobodanDan_Click(object sender, RoutedEventArgs e)
        {
            if (datumSlobodnogDana.SelectedDate == null)
                return;
            SlobodniDaniKontroler kontroler = new SlobodniDaniKontroler();
            kontroler.DodajSlobodniDan(lekarDto.Id, (DateTime)datumSlobodnogDana.SelectedDate);
            LoadSlobodniDani();
        }

        private void LoadSlobodniDani()
        {
            slobodniDani = new ObservableCollection<DateTime>();
            SlobodniDaniKontroler kontroler = new SlobodniDaniKontroler();
            slobodniDaniLekara = kontroler.GetDaniLekara(lekarDto.Id);
            foreach(DateTime dan in slobodniDaniLekara.Dani)
            {
                slobodniDani.Add(dan);
            }
            listaSlobodnihDana.ItemsSource = slobodniDani;
        }

        private void ObrisiSlobodanDan_Click(object sender, RoutedEventArgs e)
        {
            DateTime? datum = listaSlobodnihDana.SelectedItem as DateTime?;
            if (datum == null) return;

            SlobodniDaniKontroler kontroler = new SlobodniDaniKontroler();
            kontroler.ObrisiSlobodanDan(lekarDto.Id, (DateTime)datum);
            LoadSlobodniDani();
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("RadnoVreme");

            }
        }
    }
}
