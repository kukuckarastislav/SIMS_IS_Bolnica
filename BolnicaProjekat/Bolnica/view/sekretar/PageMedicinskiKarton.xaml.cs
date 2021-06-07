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
using Bolnica.utils;
using DTO;
using Kontroler;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageMedicinskiKarton.xaml
    /// </summary>
    public partial class PageMedicinskiKarton : Page
    {
        private PacijentDTO pacijent;
        private ObservableCollection<string> lista;
        public PageMedicinskiKarton(PacijentDTO pacijent)
        {
            InitializeComponent();

            btnPomoc.Visibility = App.vidljivostPomoci;

            this.pacijent = pacijent;
            lista = new ObservableCollection<string>();
            this.tbIme.Text = pacijent.Ime;
            this.tbPrezime.Text = pacijent.Prezime;
            this.tbJmbg.Text = pacijent.Jmbg;
            UcitajAlergene();
        }

        private void DodajAlergen_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNaziv.Text)) return;
            PacijentKontroler kontroler = new PacijentKontroler();
            kontroler.DodajAlergen(pacijent.Id, textBoxNaziv.Text);
            UcitajAlergene();
        }

        private void UcitajAlergene()
        {
            PacijentKontroler kontroler = new PacijentKontroler();
            List<String> alergeni = kontroler.GetAlergeniPacijenta(pacijent.Id);
            lista = new ObservableCollection<string>();
            foreach (string alergen in alergeni)
            {
                lista.Add(alergen);
            }
            listBoxAlergeni.ItemsSource = lista;
        }

        private void ObrisiAlergen_Click(object sender, RoutedEventArgs e)
        {
            string alergen = listBoxAlergeni.SelectedItem as string;
            if (String.IsNullOrEmpty(alergen)) return;
            PacijentKontroler kontroler = new PacijentKontroler();
            kontroler.ObrisiAlergen(pacijent.Id, alergen);
            UcitajAlergene();
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
