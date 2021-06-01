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

namespace Bolnica.view.sekretar.registracija
{
    /// <summary>
    /// Interaction logic for PageRegistracijaPacijentaxaml.xaml
    /// </summary>
    public partial class PageRegistracijaPacijentaxaml : Page
    {
        public PageRegistracijaPacijentaxaml()
        {
            InitializeComponent();
            rbMusko.IsChecked = true;
        }

        private void Registruj_Pacijenta(object sender, RoutedEventArgs e)
        {
            if (!ValidirajUnos()) return;
            try
            {
                Pol pol;
                if (rbMusko.IsChecked == true)
                {
                    pol = Pol.Musko;
                }
                else
                {
                    pol = Pol.Zensko;
                }


                PacijentKontroler kontroler = new PacijentKontroler();
                kontroler.DodajPacijenta(new MedicinskiKarton(), null, 0, false, false, false, false, inputKorisnickoIme.Text, inputLozinka.Text, inputIme.Text,
                inputPrezime.Text, pol, inputEmail.Text, inputTelefon.Text, Convert.ToDateTime(inputDatum.Text),
                inputJmbg.Text, inputDrzavljanstvo.Text, inputAdresa.Text);

                MessageBox.Show("Pacijent je uspesno dodat.");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Podaci nisu ispravnog formata");
            }
        }

        private bool ValidirajUnos()
        {
            ResetujGreske();
            bool validanUnos = true;

            if (!ValidirajIme()) validanUnos = false;
            if (!ValidirajPrezime()) validanUnos = false;
            if (!ValidirajJmbg()) validanUnos = false;
            if (!ValidirajTelefon()) validanUnos = false;
            if (!ValidirajAdresu()) validanUnos = false;
            if (!ValidirajKorisnickoIme()) validanUnos = false;
            if (!ValidirajEmail()) validanUnos = false;
            if (!ValidirajDrzavljanstvo()) validanUnos = false;
            if (!ValidirajLozinku()) validanUnos = false;
            if (!ValidirajPonovljenuLozinku()) validanUnos = false;
            if (!ValidirajDatumRodjenja()) validanUnos = false;

            if (!validanUnos)
            {
                tbErrRegistracija.Text = "Greška pri unosu podataka!";
            }
            else
            {
                tbErrRegistracija.Text = "Korisnik je uspesno registrovan!";
            }

            return validanUnos;
        }
        private void ResetujGreske()
        {
            tbErrIme.Text = "";
            tbErrPrezime.Text = "";
            tbErrTelefon.Text = "";
            tbErrJMBG.Text = "";
            tbErrAdresa.Text = "";
            tbErrDatum.Text = "";
            tbErrKorisnickoIme.Text = "";
            tbErrLozinka.Text = "";
            tbErrPonovljenaLozinka.Text = "";
            tbErrEmail.Text = "";
            tbErrDrzavljanstvo.Text = "";
            tbErrRegistracija.Text = "";
        }

        private bool ValidirajIme()
        {
            if (String.IsNullOrWhiteSpace(inputIme.Text))
            {
                tbErrIme.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajPrezime()
        {
            if (String.IsNullOrWhiteSpace(inputPrezime.Text))
            {
                tbErrPrezime.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajJmbg()
        {
            if (String.IsNullOrWhiteSpace(inputJmbg.Text))
            {
                tbErrJMBG.Text = "Polje ne može biti prazno!";
                return false;
            }
            else
            {
                if (inputJmbg.Text.Length != 13)
                {
                    tbErrJMBG.Text = "Polje mora sadržati 13 cifara!";
                    return false;
                }
                else
                {
                    if(!Validator.ValidanJmbg(inputJmbg.Text))
                    {
                        tbErrJMBG.Text = "Polje mora sadržati 13 cifara!";
                        return false;
                    }
                }
            }
            return true;
        }
        private bool ValidirajTelefon()
        {
            if (String.IsNullOrWhiteSpace(inputTelefon.Text))
            {
                tbErrTelefon.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajAdresu()
        {
            if (String.IsNullOrWhiteSpace(inputAdresa.Text))
            {
                tbErrAdresa.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajKorisnickoIme()
        {
            if (String.IsNullOrWhiteSpace(inputKorisnickoIme.Text))
            {
                tbErrKorisnickoIme.Text = "Polje ne može biti prazno!";
                return false;
            }
            else
            {
                PacijentKontroler kontroler = new PacijentKontroler();
                if(kontroler.JelPostojiKorisnickoIme(inputKorisnickoIme.Text))
                {
                    tbErrKorisnickoIme.Text = "Korisničko ime je zauzeto!";
                }

            }
            return true;
        }

        private bool ValidirajEmail()
        {
            if (String.IsNullOrWhiteSpace(inputEmail.Text))
            {
                tbErrEmail.Text = "Polje ne može biti prazno!";
                return false;
            }
            else
            {
                if(!Validator.ValidanEmail(inputEmail.Text))
                {
                    tbErrEmail.Text = "Pogrešan formajt email-a!";
                    return false;
                }
            }
            return true;
        }
        private bool ValidirajDatumRodjenja()
        {
            if (String.IsNullOrWhiteSpace(inputDatum.Text))
            {
                tbErrDatum.Text = "Polje ne može biti prazno!";
                return false;
            }
            else
            {
                try
                {
                    Convert.ToDateTime(inputDatum.Text);
                }
                catch(Exception e)
                {
                    tbErrDatum.Text = "Pogresan format datuma!";
                    return false;
                }
            }
            return true;
        }
        private bool ValidirajDrzavljanstvo()
        {
            if (String.IsNullOrWhiteSpace(inputDrzavljanstvo.Text))
            {
                tbErrDrzavljanstvo.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajLozinku()
        {
            if (String.IsNullOrWhiteSpace(inputLozinka.Text))
            {
                tbErrLozinka.Text = "Polje ne može biti prazno!";
                return false;
            }
            return true;
        }
        private bool ValidirajPonovljenuLozinku()
        {
            if (String.IsNullOrWhiteSpace(inputPonovljenaLozinka.Text))
            {
                tbErrPonovljenaLozinka.Text = "Polje ne može biti prazno!";
                return false;
            }
            else
            {
                if(!inputLozinka.Text.Equals(inputPonovljenaLozinka.Text))
                {
                    tbErrPonovljenaLozinka.Text = "Nije uneta ista lozinka!";
                    return false;
                }
                
            }
            return true;
        }

    }
}
