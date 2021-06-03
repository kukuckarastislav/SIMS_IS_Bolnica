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
using Bolnica.Controller;
using Kontroler;
using Model;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for PageDodavanjeObavestenja.xaml
    /// </summary>
    public partial class PageDodavanjeObavestenja : Page
    {
        public PageDodavanjeObavestenja()
        {
            InitializeComponent();
        }

        private void DodajObavestenje_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjeKontroler kontroler = new ObavestenjeKontroler();
            Obavestenje ret = kontroler.DodajObavestenje(tbNaslov.Text, tbPoruka.Text);
            if (ret == null)
                MessageBox.Show("Podaci nisu oneti.");
            else
                MessageBox.Show("Obavestenje je uspesno dodato.");
        }
    }
}
