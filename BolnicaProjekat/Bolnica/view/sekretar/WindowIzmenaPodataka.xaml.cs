using Bolnica.view.pacijent;
using Kontroler;
using Model;
using Repozitorijum;
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
using System.Windows.Shapes;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowIzmenaPodataka.xaml
    /// </summary>
    public partial class WindowIzmenaPodataka : Window
    {
        private Pacijent pacijent;
        private DataGrid dg;
        public WindowIzmenaPodataka(Pacijent p, DataGrid dg)
        {
            this.dg = dg;
            pacijent = p;
            InitializeComponent();
            LoadPacijentData(p);
        }

        private void LoadPacijentData(Pacijent p)
        {
            inputIme.Text = p.Ime;
            inputPrezime.Text = p.Prezime;
            //inputId.Text = p.IdPacijenta;
            
            inputTelefon.Text = p.Telefon;
            inputDatum.Text = p.DatumRodjenja.Date.ToShortDateString();
            inputDrzavljanstvo.Text = p.Drzavljanstvo;
            inputAdresa.Text = p.AdresaStanovanja;
            inputJmbg.Text = p.Jmbg;
            inputEmail.Text = p.Email;
            if(p.Pol == Pol.Musko)
            {
                rbMusko.IsChecked = true;
            }
            else {

                rbZensko.IsChecked = true;
            }
            inputGestNalog.IsChecked = p.PacijentGost;
            inputLogickoBrisanje.IsChecked = p.LogickiObrisan;
        }

        private void IzmeniPacijenta_Click(object sender, RoutedEventArgs e)
        {
            pacijent.Ime = inputIme.Text;
            pacijent.Prezime = inputPrezime.Text;
            //pacijent.IdPacijenta = inputId.Text;
            pacijent.PacijentGost = (bool)inputGestNalog.IsChecked;
            pacijent.LogickiObrisan = (bool)inputLogickoBrisanje.IsChecked;

            pacijent.Telefon = inputTelefon.Text;
            pacijent.DatumRodjenja = Convert.ToDateTime(inputDatum.Text);

            if (rbMusko.IsChecked == true)
            {
                pacijent.Pol = Pol.Musko;
            }
            else
            {

                pacijent.Pol = Pol.Zensko;
            }

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
            dg.Items.Refresh();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OcistiPolja_Click(object sender, RoutedEventArgs e)
        {
            inputIme.Clear();
            inputPrezime.Clear();
            
            inputTelefon.Clear();
            inputDrzavljanstvo.Clear();
            inputAdresa.Clear();
            inputEmail.Clear();
        }
    }
}
