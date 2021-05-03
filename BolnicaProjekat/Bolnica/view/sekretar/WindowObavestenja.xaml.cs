using Bolnica.Controller;
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
using Model;

namespace Bolnica.view.sekretar
{
    /// <summary>
    /// Interaction logic for WindowObavestenja.xaml
    /// </summary>
    public partial class WindowObavestenja : Window
    {
        public WindowObavestenja()
        {
            InitializeComponent();
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajObavestenje_Click(object sender, RoutedEventArgs e)
        {
            ObavestenjeKontroler kontroler = new ObavestenjeKontroler();
            Obavestenje ret = kontroler.DodajObavestenje(this.tbNaslov.Text, this.tbPoruka.Text);
            if (ret == null)
                MessageBox.Show("Podaci nisu oneti.");
            else
                MessageBox.Show("Obavestenje je uspesno dodato.");
        }
    }
}
