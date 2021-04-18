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
using System.Windows.Shapes;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for PrikazPregleda.xaml
    /// </summary>
    public partial class PrikazPregleda : Window
    {
        //public Pregled Pregled;
        public PrikazPregleda()//Pregled OdabraniPregled
        {

            InitializeComponent();

            //Pregled = OdabraniPregled;

            TimeSpan period = new TimeSpan(1,0,0,0);

           // if (Pregled.Termin.Pocetak.Subtract(DateTime.Now)< period )
            //{
            //   dugmePomjeriPregled.IsEnabled = false;
           // }

           // datum.Text = (Pregled.Termin.Pocetak).ToString("dddd, dd MMMM yyyy");
           // pocetak.Text = (Pregled.Termin.Pocetak).ToString("hh:mm tt");
           // kraj.Text = (Pregled.Termin.Kraj).ToString("hh:mm tt");


          //  idlekara.Text = Convert.ToString(Pregled.IdLekara.Ime)+" "+ Convert.ToString(Pregled.IdLekara.Prezime);
          //  komentar.Text = Convert.ToString(Pregled.Komentar);
          //  soba.Text = Convert.ToString(Pregled.SobaZaPregled.Id);

        }

        private void izmjena_pregleda(object sender, RoutedEventArgs e)
        {
           this. Close();
          // Pregled.Komentar = komentar.Text;

        }

        private void pomjeri_pregled(object sender, RoutedEventArgs e)
        {

        }
    }
}
