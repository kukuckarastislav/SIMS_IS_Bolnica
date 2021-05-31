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
        
    }
}
