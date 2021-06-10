using Bolnica.utils;
using Controller;
using DTO;
using Kontroler;
using Model;
using System;
using System.Collections;
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
    /// Interaction logic for ZakazivanjeTermina.xaml
    /// </summary>
    public partial class ZakazivanjeTermina : Page
    {

        private ObservableCollection<Lekar> listaLekari;
        public ZakazivanjeTermina()
        {
            InitializeComponent();
            btnPomoc.Visibility = App.vidljivostPomoci;
            UcitajLekare();
            UcitajPacijente();
            UcitajProstorije();
            datumTermina.SelectedDate = DateTime.Now;
            rbPregled.IsChecked = true;
        }

        private void UcitajLekare()
        {
            LekarKontroler kontroler = new LekarKontroler();
            ObservableCollection<LekarDTO> lekari = kontroler.getAllNeobrisaniLekari();
            cmbLekari.ItemsSource = lekari;
        }
        private void UcitajPacijente()
        {
            PacijentKontroler kontroler = new PacijentKontroler();
            ObservableCollection<PacijentDTO> pacijeti = kontroler.GetPacijentiDto();
            cmbPacijenti.ItemsSource = pacijeti;
        }
        private void UcitajProstorije()
        {
            
            ObservableCollection<ProstorijaDTO> prostorije = new ObservableCollection<ProstorijaDTO>();
            ProstorijeKontroler kontroler = new ProstorijeKontroler();
            if (rbPregled.IsChecked==true)
            {
                foreach (ProstorijaDTO dto in kontroler.GetProstorijeDTO())
                {
                    if(dto.TipProstorije==TipProstorije.SobaZaPreglede)
                        prostorije.Add(dto);
                }
            }
            else
            {
                foreach (ProstorijaDTO dto in kontroler.GetProstorijeDTO())
                {
                    if (dto.TipProstorije == TipProstorije.OpracionaSala)
                        prostorije.Add(dto);
                }
            }
            cmbProstorije.ItemsSource = prostorije;
        }

        private void cbHitnoZakazivanje_Checked(object sender, RoutedEventArgs e)
        {
            datumTermina.IsEnabled = false;
            datumTermina.SelectedDate = DateTime.Now;
        }

        private void cbHitnoZakazivanje_Unchecked(object sender, RoutedEventArgs e)
        {
            datumTermina.SelectedDate = DateTime.Now;
            datumTermina.IsEnabled = true;
        }

        private void ZakaziTermin_Click(object sender, RoutedEventArgs e)
        {
            ZdravstvenaUslugaKontroler kontroler = new ZdravstvenaUslugaKontroler();
            
            if (ValidirajUnos())
            {
                ZakaziTetminDTO dto = GetPodaciZakazivanja();
                if (cbHitnoZakazivanje.IsChecked == true)
                {
                    dto = kontroler.HitnoZakaziUslugu(dto);
                }
                else
                {
                    dto = kontroler.ZakaziUslugu(dto);
                }
                if(dto.ZakazanTermin)
                {
                    MessageBox.Show("Termin je uspešno zakazan.");
                }
                else
                {
                    tbErrLekar.Text = dto.GreskaLekar;
                    tbErrProstorije.Text = dto.GreskaProstorija;
                    tbErrTermin.Text = dto.GreskaRadnoVreme;
                }
            }
        }

        private ZakaziTetminDTO GetPodaciZakazivanja()
        {
            ZakaziTetminDTO dto = new ZakaziTetminDTO();
            LekarDTO lekar = cmbLekari.SelectedItem as LekarDTO;
            dto.IdLekara = lekar.Id;
            PacijentDTO pacijent = cmbPacijenti.SelectedItem as PacijentDTO;
            dto.IdPacijenta = pacijent.Id;
            ProstorijaDTO prostorija = cmbProstorije.SelectedItem as ProstorijaDTO;
            dto.IdProstorije = prostorija.Id;
            if(rbPregled.IsChecked==true)
            {
                dto.TipUsluge = TipUsluge.Pregled;
            }
            else
            {
                dto.TipUsluge = TipUsluge.Operacija;
            }
            dto.Termin = GetVremeZakazivanja();

            return dto;
        }

        private Termin GetVremeZakazivanja()
        {
            int year = datumTermina.SelectedDate.Value.Year;
            int month = datumTermina.SelectedDate.Value.Month;
            int day = datumTermina.SelectedDate.Value.Day;
            int hourPocetak = cbPocetakSati.SelectedIndex;
            int hourKraj = cbKrajSati.SelectedIndex;
            int minPocetak = 0;
            int minKraj = 0;
            if (cbPocetaMinuti.SelectedIndex != 0)
                minPocetak = 30;
            if (cbKrajMinuti.SelectedIndex != 0)
                minKraj = 30;
            Termin termin = new Termin(new DateTime(year, month, day, hourPocetak, minPocetak, 0),
                                       new DateTime(year, month, day,hourKraj,minKraj,0));
            return termin;
        }

        private bool ValidirajUnos()
        {
            ResetujGreske();
            bool validanUnos = true;

            if (!ValidirajPacijenta()) validanUnos = false;
            if (!ValidirajLekara()) validanUnos = false;
            if (!ValidirajDatum()) validanUnos = false;
            if (!ValidirajVremeTermina()) validanUnos = false;
            if (!ValidirajProstoriju()) validanUnos = false;


            if (!validanUnos)
            {
                
            }
            else
            {
                
            }

            return validanUnos;
        }

        
        private void ResetujGreske()
        {
            tbErrDatumTermina.Text = "";
            tbErrLekar.Text = "";
            tbErrPacijent.Text = "";
            tbErrTermin.Text = "";
            tbErrProstorije.Text = "";
        }
        private bool ValidirajPacijenta()
        {
            if (cmbPacijenti.SelectedIndex==-1)
            {
                tbErrPacijent.Text = "Pacijent nije odabran.";
                return false;
            }
            return true;
        }
        private bool ValidirajLekara()
        {
            if (cmbLekari.SelectedIndex == -1)
            {
                tbErrLekar.Text = "Lekar nije odabran.";
                return false;
            }
            return true;
        }

        private bool ValidirajProstoriju()
        {
            if (cmbProstorije.SelectedIndex == -1)
            {
                tbErrProstorije.Text = "Prostorija nije odabrana.";
                return false;
            }
            return true;
        }

        private bool ValidirajDatum()
        {
            if(datumTermina.SelectedDate==null)
            {
                tbErrDatumTermina.Text = "Datum nije odabran";
                return false;
            }
            return true;
        }

        private bool ValidirajVremeTermina()
        {
            if(cbPocetakSati.SelectedIndex==-1 || cbPocetaMinuti.SelectedIndex==-1 
                || cbKrajSati.SelectedIndex==-1 || cbKrajMinuti.SelectedIndex==-1)
            {
                tbErrTermin.Text = "Vreme termina nije izabrano";
                return false;
            }
            if(cbPocetakSati.SelectedIndex> cbKrajSati.SelectedIndex)
            {
                tbErrTermin.Text = "Vreme završetka termina mora biti nakon pocetka.";
                return false;
            }
            if(cbPocetakSati.SelectedIndex == cbKrajSati.SelectedIndex)
            {
                if(cbPocetaMinuti.SelectedIndex >= cbKrajMinuti.SelectedIndex)
                {
                    tbErrTermin.Text = "Vreme završetka termina mora biti nakon pocetka.";
                    return false;
                }
            }
            return true;
        }

        private void cmbLekari_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbLekari.SelectedIndex!=-1)
            {
                LekarDTO dto = cmbLekari.SelectedItem as LekarDTO;

                tbRadnoVreme.Text = dto.RadnoVremeIspis;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("ZakaziTermin");

            }
        }

        private void rbPregled_Checked(object sender, RoutedEventArgs e)
        {
            UcitajProstorije();
        }

        private void rbOperacija_Checked(object sender, RoutedEventArgs e)
        {
            UcitajProstorije();
        }
    }
}
