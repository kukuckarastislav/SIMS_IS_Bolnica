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
using DTO;
using Model;
using Kontroler;
using Bolnica.utils;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageIzmenaPacijenta.xaml
    /// </summary>
    public partial class PageIzmenaPacijenta : Page
    {
        private PacijentDTO pacijent;
        public PageIzmenaPacijenta(PacijentDTO pacijent)
        {
            InitializeComponent();
            this.pacijent = pacijent;
            LoadPacijentData();
        }

        private void LoadPacijentData()
        {
            inputIme.Text = pacijent.Ime;
            inputPrezime.Text = pacijent.Prezime;

            inputTelefon.Text = pacijent.Telefon;
            inputDatumRodjenja.SelectedDate = pacijent.DatumRodjenja;
            inputDrzavljanstvo.Text = pacijent.Drzavljanstvo;
            inputAdresa.Text = pacijent.AdresaStanovanja;
            inputJmbg.Text = pacijent.Jmbg;
            inputEmail.Text = pacijent.Email;
            if (pacijent.Pol == Pol.Musko)
            {
                rbMusko.IsChecked = true;
            }
            else
            {
                rbZensko.IsChecked = true;
            }

        }

        private void IzmeniPacijenta_Click(object sender, RoutedEventArgs e)
        {

            if(!ValidirajUnos())
            {
                MessageBox.Show("Polja nisu ispravno popunjana.");
            }
            else
            {
                PacijentDTO noviPodaci = new PacijentDTO(this.pacijent);
                noviPodaci.Ime = inputIme.Text;
                noviPodaci.Prezime = inputPrezime.Text;
                noviPodaci.Telefon = inputTelefon.Text;
                noviPodaci.DatumRodjenja = (DateTime)inputDatumRodjenja.SelectedDate;
                noviPodaci.Drzavljanstvo = inputDrzavljanstvo.Text;
                noviPodaci.AdresaStanovanja = inputAdresa.Text;
                noviPodaci.Email = inputEmail.Text;
                PacijentKontroler kontroler = new PacijentKontroler();
                kontroler.AzurirajPacijenta(noviPodaci);
                MessageBox.Show("Korisnik je uspesno izmenjen.");
            }
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageListaPacijenata());
        }

        private bool ValidirajUnos()
        {
            ResetujGreske();
            bool validanUnos = true;

            if (!ValidirajIme()) validanUnos = false;
            if (!ValidirajPrezime()) validanUnos = false;
            if (!ValidirajTelefon()) validanUnos = false;
            if (!ValidirajAdresu()) validanUnos = false;
            if (!ValidirajEmail()) validanUnos = false;
            if (!ValidirajDrzavljanstvo()) validanUnos = false;
            if (!ValidirajDatumRodjenja()) validanUnos = false;

            return validanUnos;
        }

        
        private void ResetujGreske()
        {
            tbErrIme.Text = "";
            tbErrPrezime.Text = "";
            tbErrTelefon.Text = "";
            tbErrJmbg.Text = "";
            tbErrAdresaStanovanja.Text = "";
            tbErrDatumRodjenja.Text = "";
            tbErrEmail.Text = "";
            tbErrDrzavljanstvo.Text = "";
        }

        private bool ValidirajIme()
        {
            if (String.IsNullOrWhiteSpace(inputIme.Text))
            {
                tbErrIme.Text = "Polje ne može biti prazno.";
                return false;
            }
            return true;
        }
        private bool ValidirajPrezime()
        {
            if (String.IsNullOrWhiteSpace(inputPrezime.Text))
            {
                tbErrPrezime.Text = "Polje ne može biti prazno.";
                return false;
            }
            return true;
        }
        
        private bool ValidirajTelefon()
        {
            if (String.IsNullOrWhiteSpace(inputTelefon.Text))
            {
                tbErrTelefon.Text = "Polje ne može biti prazno.";
                return false;
            }
            return true;
        }
        private bool ValidirajAdresu()
        {
            if (String.IsNullOrWhiteSpace(inputAdresa.Text))
            {
                tbErrAdresaStanovanja.Text = "Polje ne može biti prazno.";
                return false;
            }
            return true;
        }

        private bool ValidirajEmail()
        {
            if (String.IsNullOrWhiteSpace(inputEmail.Text))
            {
                tbErrEmail.Text = "Polje ne može biti prazno.";
                return false;
            }
            else
            {
                if(!Validator.ValidanEmail(inputEmail.Text))
                {
                    tbErrEmail.Text = "Pogrešan formajt email-a.";
                    return false;
                }
            }
            return true;
        }
        private bool ValidirajDatumRodjenja()
        {
            if(inputDatumRodjenja.SelectedDate==null)
            {
                tbErrDatumRodjenja.Text = "Polje ne može biti prazno.";
                return false;
            }
            else
            {
                if(inputDatumRodjenja.SelectedDate > DateTime.Now)
                {
                    tbErrDatumRodjenja.Text = "Datum rodjenja ne moze biti stariji od današnjeg.";
                    return false;
                }
            }
            return true;
        }
        private bool ValidirajDrzavljanstvo()
        {
            if (String.IsNullOrWhiteSpace(inputDrzavljanstvo.Text))
            {
                tbErrDrzavljanstvo.Text = "Polje ne može biti prazno.";
                return false;
            }
            return true;
        }

    }
}
