using Bolnica.utils;
using Model;
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

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageKorisnickiNalog.xaml
    /// </summary>
    public partial class PageKorisnickiNalog : Page
    {
        public PageKorisnickiNalog()
        {
            InitializeComponent();
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            inputIme.Text = App.ulogovaniKorisnik.Ime;
            inputPrezime.Text = App.ulogovaniKorisnik.Prezime;

            inputTelefon.Text = App.ulogovaniKorisnik.Telefon;
            inputDatumRodjenja.SelectedDate = App.ulogovaniKorisnik.DatumRodjenja;
            inputDrzavljanstvo.Text = App.ulogovaniKorisnik.Drzavljanstvo;
            inputAdresa.Text = App.ulogovaniKorisnik.AdresaStanovanja;
            inputJmbg.Text = App.ulogovaniKorisnik.Jmbg;
            inputEmail.Text = App.ulogovaniKorisnik.Email;
            if (App.ulogovaniKorisnik.Pol == Pol.Musko)
            {
                rbMusko.IsChecked = true;
            }
            else
            {
                rbZensko.IsChecked = true;
            }
        }

        private void btnPomoc_Click(object sender, RoutedEventArgs e)
        {
            IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
            if (focusedControl is DependencyObject)
            {
                string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                HelpProvider.ShowHelp("KorisnickiNalog");

            }
        }
    }
}
