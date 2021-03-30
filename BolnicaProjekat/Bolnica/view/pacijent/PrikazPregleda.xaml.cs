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
        public Pregled Pregled;
        public PrikazPregleda(Pregled OdabraniPregled)
        {
            InitializeComponent();
            Pregled = OdabraniPregled;

            pocetak.Text = Convert.ToString(Pregled.Termin.Pocetak); ;
            kraj.Text = Convert.ToString(Pregled.Termin.Kraj);
            idlekara.Text = Convert.ToString(Pregled.IdLekara);
            komentar.Text = Convert.ToString(Pregled.Komentar);

            // this.prikazPregleda.ItemSource = Pregled;
        }

        private void izmjena_pregleda(object sender, RoutedEventArgs e)
        {
           this. Close();
           Pregled.Komentar = komentar.Text;

        }

        internal Pregled promjenjenPregled()
        {
            return Pregled;
        }
    }
}
