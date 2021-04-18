using Model;
using Repozitorijum;
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


namespace Bolnica.view.sekretar.registracija
{
    /// <summary>
    /// Interaction logic for PageRegistracija.xaml
    /// </summary>
    public partial class PageRegistracija : Page
    {
        
        public PageRegistracija()
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
                Model.Pacijent noviPacijent = new Model.Pacijent(new MedicinskiKarton(),null,Convert.ToInt32(inputId.Text), false, false, false, inputKorisnickoIme.Text, inputSifra.Text, inputIme.Text,
                inputPrezime.Text, pol, inputEmail.Text, inputTelefon.Text, Convert.ToDateTime(inputDatum.Text),
                inputJmbg.Text, inputDrzavljanstvo.Text, inputAdresa.Text);

                PacijentRepozitorijum.GetInstance.DodajPacijenta(noviPacijent);

                //Model.Bolnica.GetInstance.AddPacijenti(noviPacijent);
                MessageBox.Show("Pacijent je uspesno dodat.");
            }catch(Exception ee)
            {
                MessageBox.Show("Podaci nisu ispravnog formata");
            }
        }
        private void HitnoRegistruj_Pacijenta(object sender, RoutedEventArgs e)
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
               // Model.Pacijent noviPacijent = new Model.Pacijent(inputJmbg.Text, false, false, false, inputJmbg.Text, inputJmbg.Text, inputIme.Text,
                //inputPrezime.Text, pol, inputEmail.Text, inputTelefon.Text, new DateTime(),
                //inputJmbg.Text, inputDrzavljanstvo.Text, inputAdresa.Text);

                //Model.Bolnica.GetInstance.AddPacijenti(noviPacijent);
                MessageBox.Show("Pacijent je uspesno dodat.");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Podaci nisu ispravnog formata");
            }

        }
        private void Ocisti_Polja(object sender, RoutedEventArgs e)
        {
            inputIme.Clear();
            inputPrezime.Clear();
            inputId.Clear();
            inputKorisnickoIme.Clear();
            inputSifra.Clear();
            inputTelefon.Clear();
            inputDatum.Clear();
            inputDrzavljanstvo.Clear();
            inputAdresa.Clear();
            inputJmbg.Clear();
            inputEmail.Clear();
           
        }


    }
}
