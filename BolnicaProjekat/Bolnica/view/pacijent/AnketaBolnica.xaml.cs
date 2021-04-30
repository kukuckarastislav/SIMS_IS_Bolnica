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
using Controller;

namespace Bolnica.view.pacijent
{
    /// <summary>
    /// Interaction logic for AnketaBolnica.xaml
    /// </summary>
    public partial class AnketaBolnica : Window
    {   
        public int idPacijenta { get; set; }
        public string text { get; set; }
        public AnketaBolnica(int idPacijenta)
        {
            this.idPacijenta = idPacijenta;
            InitializeComponent();
        }

        private void posalji_anketu(object sender, RoutedEventArgs e)
        {
            Controller.AnketaKontroler kontroler = new Controller.AnketaKontroler();
            text = sadrzaj.Text;
            kontroler.DodajOcenuBolnice(idPacijenta, text);
            this.Close();
        }
    }
}
