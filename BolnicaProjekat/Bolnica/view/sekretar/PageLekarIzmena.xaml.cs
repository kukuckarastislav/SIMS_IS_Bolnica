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
using Model;
using Kontroler;
using Bolnica.utils;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageLekarIzmena.xaml
    /// </summary>
    public partial class PageLekarIzmena : Page
    {
        private LekarDTO lekarDto;
        public PageLekarIzmena(LekarDTO dto)
        {
            InitializeComponent();
            lekarDto = dto;
            ucitajPodatkeLekara();
        }

        void ucitajPodatkeLekara()
        {
            this.inputIme.Text = lekarDto.Ime;
            this.inputPrezime.Text = lekarDto.Prezime;
            this.inputJMBG.Text = lekarDto.Jmbg;
            this.inputTelefon.Text = lekarDto.Telefon;
            this.inputAdresa.Text = lekarDto.AdresaStanovanja;
            this.inputEmail.Text = lekarDto.Email;
            this.inputDrzavljanstvo.Text = lekarDto.Drzavljanstvo;
            inputDatumRodjenja.SelectedDate = lekarDto.DatumRodjenja;
            if (lekarDto.Pol == Pol.Musko)
            {
                rbMusko.IsChecked = true;
            }
            else
            {
                rbZensko.IsChecked = true;
            }
        }

        private void SacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidirajUnos())
            {
                //MessageBox.Show("Polja nisu ispravno popunjana.");
            }
            else
            {
                LekarDTO noviLekar = new LekarDTO(lekarDto);
                noviLekar.Ime = this.inputIme.Text;
                noviLekar.Prezime = this.inputPrezime.Text;
                noviLekar.Telefon = this.inputTelefon.Text;
                noviLekar.AdresaStanovanja = this.inputAdresa.Text;
                noviLekar.Email = this.inputEmail.Text;
                noviLekar.Drzavljanstvo = this.inputDrzavljanstvo.Text;
                noviLekar.DatumRodjenja = (DateTime)inputDatumRodjenja.SelectedDate;
                noviLekar.Id = lekarDto.Id;
                noviLekar.Jmbg = lekarDto.Jmbg;
                LekarKontroler kontroler = new LekarKontroler();
                kontroler.AzurirajLekara(noviLekar);
                MessageBox.Show("Lekar je uspešno izmenjen.");
            }

        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageLekari());
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
                if (!Validator.ValidanEmail(inputEmail.Text))
                {
                    tbErrEmail.Text = "Pogrešan formajt email-a.";
                    return false;
                }
            }
            return true;
        }
        private bool ValidirajDatumRodjenja()
        {
            if (inputDatumRodjenja.SelectedDate == null)
            {
                tbErrDatumRodjenja.Text = "Polje ne može biti prazno.";
                return false;
            }
            else
            {
                if (inputDatumRodjenja.SelectedDate > DateTime.Now)
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
