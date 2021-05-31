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
            inputDatum.Text = pacijent.DatumRodjenja.Date.ToShortDateString();
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
            PacijentDTO pacijent = new PacijentDTO();
            pacijent.Ime = inputIme.Text;
            pacijent.Prezime = inputPrezime.Text;
            //pacijent.IdPacijenta = inputId.Text;
            
            pacijent.Telefon = inputTelefon.Text;
            pacijent.DatumRodjenja = Convert.ToDateTime(inputDatum.Text);

           

            pacijent.Drzavljanstvo = inputDrzavljanstvo.Text;
            pacijent.AdresaStanovanja = inputAdresa.Text;
            pacijent.Email = inputEmail.Text;
            bool ret = false;//Model.Bolnica.GetInstance.EditPacijent(pacijent);

            // if(ret == true)
            // { 
            MessageBox.Show("Pacijent je uspesno izmenjen!");

            //  }
            // else
            //  {
            //  MessageBox.Show("Pacijent nije izmenjen");
            //  }
            PacijentKontroler kontroler = new PacijentKontroler();
            kontroler.SaveData();
        }
    }
}
